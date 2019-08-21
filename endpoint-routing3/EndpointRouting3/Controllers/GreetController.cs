using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting3.Controllers
{
    [Route("Greet")]
    public class GreetController : Controller
    {
        public ActionResult Index() => null;
    }
}