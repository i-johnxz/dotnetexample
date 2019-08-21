using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EndpointRouting2.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult World()
        {
            return null;
        }
    }
}