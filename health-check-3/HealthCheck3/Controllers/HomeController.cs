using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <h1>Health Check - Failed check</h1>
                This <a href=""/IsUp"">/IsUp</a> always fails.
                </body></html> ",
                ContentType = "text/html"
            };
        }
    }
}