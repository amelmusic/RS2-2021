using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class VrsteProizvodumService : BaseReadService<Model.VrsteProizvodum, Database.VrsteProizvodum, object>, IVrsteProizvodumService
    {
 
        public VrsteProizvodumService(eProdajaContext context, IMapper mapper)
            :base(context, mapper)
        {
        }
    }
}
