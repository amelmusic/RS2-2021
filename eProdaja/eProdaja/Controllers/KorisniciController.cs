using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Database;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Model.Korisnici> GetAll([FromQuery] KorisniciSearchRequest request)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest korisnici)
        {
            return _service.Insert(korisnici);
        }

        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, [FromBody] KorisniciUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
