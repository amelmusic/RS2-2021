using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Korisnici = eProdaja.Model.Korisnici;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;

        public KorisniciService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }


        public IList<Korisnici> GetAll(KorisniciSearchRequest search)
        {
            var query = Context.Korisnicis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeFilter))
            {
                query = query.Where(x => x.Prezime == search.PrezimeFilter);
            }

            var entities = query.ToList();
            //List<Model.Korisnici> result = new List<Model.Korisnici>();
            //entities
            //    .Where(x  => !string.IsNullOrEmpty(x.Email)).ToList()
            //    .ForEach(x => result.Add(new Model.Korisnici()
            //{
            //    Email = x.Email,
            //    Ime = x.Ime,
            //    KorisnickoIme = x.KorisnickoIme,
            //    KorisnikId = x.KorisnikId,
            //    Prezime = x.Ime,
            //    Status = x.Status,
            //    Telefon = x.Telefon,
            //    Index = 1000
            //}));

            var result = _mapper.Map<IList<Model.Korisnici>>(entities);


            return result;
        }

        public Korisnici GetById(int id)
        {
            var entity = Context.Korisnicis.Find(id);

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);
            Context.Add(entity);
            if (request.Password != request.PasswordPotvrda)
            {
                //throw new NotImplementedException();
                throw new UserException("Lozinka nije ispravna");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            Context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                Context.KorisniciUloges.Add(korisniciUloge);
            }

            Context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);

        }

        public Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = Context.Korisnicis.Find(id);
            _mapper.Map(request, entity);

            Context.SaveChanges();
            return _mapper.Map<Model.Korisnici>(entity);
        }

        //GetById

        //private Model.Korisnici ToModel(Korisnici entity)
        //{
        //    return new Model.Korisnici()
        //    {
        //        KorisnikId = entity.KorisnikId,
        //        Ime = entity.Ime,
        //        Prezime = entity.Prezime,
        //        KorisnickoIme = entity.Ime,
        //        Email = entity.Email,
        //        Telefon = entity.Telefon
        //    };
        //}

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public async Task<Model.Korisnici> Login(string username, string password)
        {
            var entity = await Context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<Model.Korisnici>(entity);
        }

    }
}
