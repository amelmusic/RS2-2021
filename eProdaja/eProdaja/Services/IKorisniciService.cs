using eProdaja.Database;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKorisniciService
    {
        IList<Model.Korisnici> GetAll(KorisniciSearchRequest search);

        Model.Korisnici GetById(int id);

        Model.Korisnici Insert(KorisniciInsertRequest korisnici);

        Model.Korisnici Update(int id, KorisniciUpdateRequest korisnici);

        Task<Model.Korisnici> Login(string username, string password);
    }
}
