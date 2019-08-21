using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting5.Controllers
{
    public class WaveController : Controller
    {
        [Route("Wave-Away/{danger:required}/{ahead:required}")]
        public ActionResult Away(string danger, string ahead) => null;
    }
}