using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting5.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        [HttpGet("{name}")]
        public ActionResult World(string name) => null;

        [HttpGet("Goodbye/{age:int}")]
        public ActionResult Goodbye(int age) => null;

        [HttpGet("[action]/{byYourName?}")]
        public ActionResult CallMe(string byYourName) => null;
    }
}