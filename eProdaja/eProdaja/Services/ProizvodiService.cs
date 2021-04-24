using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, Database.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
         
        public override IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject search = null)
        {
            var entity = Context.Set<Database.Proizvodi>().AsQueryable();

            //WARNING: NEVER DO THIS. EXECUTES QUERY ON DB
            //entity = entity.ToList();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search.JedinicaMjereId.HasValue)
            {
                entity = entity.Where(x => x.JedinicaMjereId == search.JedinicaMjereId);
            }

            if (search.VrstaId.HasValue)
            {
                entity = entity.Where(x => x.VrstaId == search.VrstaId);
            }

            if (search?.IncludeJedinicaMjere == true)
            {
                entity = entity.Include(x => x.JedinicaMjere);
            }

            if (search?.IncludeList?.Length > 0)
            {
                foreach(var item in search.IncludeList)
                {
                    entity = entity.Include(item);
                }
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Proizvodi>>(list);
        }

        //BAD---
        //public IEnumerable<Model.Proizvodi> GetByName(string name)
        //{
        //    return base.Get().Where(x=>x.Naziv.Contains(name)).ToList();
        //}

        //public IEnumerable<Model.Proizvodi> GetByVrstaId(int vrstaId)
        //{
        //    return base.Get().Where(x => x.VrstaId == vrstaId).ToList();
        //}

        //public IEnumerable<Model.Proizvodi> GetByVrstaIdAndNaziv(int vrstaId, string name)
        //{
        //    return base.Get()
        //        .Where(x => x.VrstaId == vrstaId && x.Naziv.Contains(name)).ToList();
        //}
        private static MLContext mlContext = null;
        private static ITransformer model = null;

        public List<Model.Proizvodi> Recommend(int id)
        {
            if (mlContext == null)
            {
                mlContext = new MLContext();

                var tmpData = Context.Narudzbes.Include("NarudzbaStavkes").ToList();
                var data = new List<ProductEntry>();

                foreach (var x in tmpData)
                {
                    if (x.NarudzbaStavkes.Count > 1)
                    {
                        var distinctItemId = x.NarudzbaStavkes.Select(y => y.ProizvodId).ToList();
                        distinctItemId.ForEach(y =>
                        {
                            var relatedItems = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);

                            foreach (var z in relatedItems)
                            {
                                data.Add(new ProductEntry()
                                {
                                    ProductID = (uint)y,
                                    CoPurchaseProductID = (uint)z.ProizvodId
                                });
                            }
                        });
                    }
                }

                //# Directed graph (each unordered pair of nodes is saved once): Amazon0302.txt 
                //# Amazon product co-purchaisng network from March 02 2003
                //# Nodes: 262111 Edges: 1234877
                //# ProductId	Copurchased productid
                //                0   7
                //                0   2
                //                0   3
                //                0   4
                //                0   5
                //                1   0
                //                1   2
                //                1   4
                //                1   5
                //                1   15
                //                2   0

                var traindata = mlContext.Data.LoadFromEnumerable(data);

                //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                // For better results use the following parameters
                options.NumberOfIterations = 100;
                options.C = 0.00001;

                //Step 4: Call the MatrixFactorization trainer by passing options.
                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                model = est.Fit(traindata);

            }

            var allItems = Context.Proizvodis.Where(x => x.ProizvodId != id);

            var predictionResult = new List<Tuple<Database.Proizvodi, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine =
                    mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);

                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.ProizvodId
                });

                predictionResult.Add(new Tuple<Database.Proizvodi, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.Proizvodi>>(finalResult);
        }
    }


    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
