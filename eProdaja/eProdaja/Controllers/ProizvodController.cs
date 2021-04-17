using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController : ControllerBase
    {
        public IProizvodService _proizvodService { get; set; }
        private ILogger<ProizvodController> _logger;
        public ProizvodController(IProizvodService proizvodService, ILogger<ProizvodController> logger)
        {
            _proizvodService = proizvodService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Proizvod> Get()
        {
            _logger.LogInformation("Moja testna poruka");
            _logger.LogError("Testna greška!");

            return _proizvodService.Get();
        }

        [HttpGet("{id}")]
        public Proizvod GetById(int id)
        {
            return _proizvodService.GetById(id);
        }

        [HttpPost]
        public Proizvod Insert(Proizvod proizvod)
        {
            return _proizvodService.Insert(proizvod);
        }

        [HttpPut("{id}")]
        public Proizvod Update(int id, Proizvod proizvod)
        {
            return _proizvodService.Update(id, proizvod);
        }
    }


    public class Proizvod
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
