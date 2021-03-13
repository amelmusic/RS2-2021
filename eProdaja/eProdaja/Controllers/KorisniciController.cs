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
        public IList<Model.Korisnici> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public Model.Korisnici Insert([FromBody] KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
