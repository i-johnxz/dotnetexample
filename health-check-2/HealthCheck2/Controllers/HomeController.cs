using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <h1>Health Check - custom message</h1>
                The health check service checks on this url <a href=""/isup"">/isup</a>. It will return  `Mucho Bien` thanks to the customized health message.
                </body></html> ",
                ContentType = "text/html"
            };
        }
    }
}