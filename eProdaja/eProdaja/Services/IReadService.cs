using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IReadService<T, TSearch> where T: class where TSearch: class
    {
        IEnumerable<T> Get(TSearch search = null);
        public T GetById(int id);
    }
}
