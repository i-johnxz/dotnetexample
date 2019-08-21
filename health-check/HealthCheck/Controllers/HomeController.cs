using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <h1>Health Check</h1>
                The health check service checks on this url <a href=""/WhatsUp"">/WhatsUp</a>. 
                </body></html> ",
                ContentType = "text/html"
            };
        }
    }
}