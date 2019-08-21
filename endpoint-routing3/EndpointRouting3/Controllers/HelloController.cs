using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting3.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        [HttpGet("")]
        public ActionResult World() => null;

        [HttpGet("Goodbye")]
        public ActionResult Goodbye() => null;

        [HttpGet("[action]")]
        public ActionResult CallMe() => null;
    }
}