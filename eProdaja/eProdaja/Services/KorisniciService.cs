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

        public List<Model.Korisnici> Get()
        {
            return Context.Korisnicis.ToList().Select(x => _mapper.Map<Model.Korisnici>(x)).ToList();
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            //throw new NotImplementedException();
            throw new UserException("Lozinka nije ispravna");
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

    }
}
