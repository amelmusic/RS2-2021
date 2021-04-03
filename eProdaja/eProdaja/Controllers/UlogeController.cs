using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UlogeController : BaseReadController<Model.Uloge, object>
    {
        public UlogeController(IReadService<Uloge, object> service)
            : base(service)
        {
        }

    }
}
