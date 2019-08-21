using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting3.Controllers
{
    public class WaveController : Controller
    {
        [Route("Wave-Away")]
        public ActionResult Away() => null;
    }
}