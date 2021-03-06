using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Controllers;

namespace eProdaja.Services
{
    public interface IProizvodService
    {
        IEnumerable<Proizvod> Get();
        public Proizvod GetById(int id);
        public Proizvod Insert(Proizvod proizvod);

        public Proizvod Update(int id, Proizvod proizvod);
    }
}
