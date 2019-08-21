using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting4.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        [HttpGet("{name}")]
        public IActionResult World(string name) => null;


        [HttpGet("Goodbye/{age:int}")]
        public IActionResult Goodbye(int age) => null;

        [HttpGet("[action]/{byYourName?}")]
        public IActionResult CallMe(string byYourName) => null;
    }
}