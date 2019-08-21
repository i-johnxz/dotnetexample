using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck4.Controllers
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
                This <a href=""/IsUp"">/IsUp</a> always fails at the moment. If you want to see it works, change the following code
                <pre>
                    var result = await _client.GetAsync(localServer + ""/home/fakestatus/?statusCode=500"");
                </pre> 
                to
                <pre>
                    var result = await _client.GetAsync(localServer + ""/home/fakestatus/?statusCode=200"");
                </pre> 
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