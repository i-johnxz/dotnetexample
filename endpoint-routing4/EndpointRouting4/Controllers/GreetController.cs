using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting4.Controllers
{
    [Route("Greet/{isNice:bool}")]
    public class GreetController : Controller
    {
        public IActionResult Index() => null;
    }
}