using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <h1>Health Check - Failed/Success check</h1>
                <a href=""/isup"">Check Status</a>
                </body></html>",
                ContentType = "text/html"
            };
        }

        public ActionResult FakeStatus(int statusCode)
        {
            return StatusCode(statusCode);
        }
    }
}