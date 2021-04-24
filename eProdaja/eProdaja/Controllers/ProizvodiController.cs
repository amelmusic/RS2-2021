using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class ProizvodiController : BaseCRUDController<Model.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
    {
        public ProizvodiController(IProizvodiService service) : base(service)
        {
        }

        [AllowAnonymous]
        [HttpGet("Recommend/{id}")]
        public List<Model.Proizvodi> Recommend(int id)
        {
            return (_service as IProizvodiService).Recommend(id);
        }
    }
}
