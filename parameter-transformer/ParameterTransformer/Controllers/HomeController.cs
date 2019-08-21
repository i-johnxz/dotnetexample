using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParameterTransformer.Controllers
{
    [Route("")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <h1>Parameter Transformer</h1>
                <p>
                    Now all your PascalCase action becomes kebab-case, e.g. AboutUs becomes about-us. Remember that the transformation happens only on the token replacement [controller] and [action].
                </p> 
                <ul>
                    <li><a href=""/"">/</a></li>
                    <li><a href=""/home/about-us"">/home/about-us</a </li>
                    <li><a href=""/home/order-items-now"">/home/order-items-now</a></li>
                    <li><a href=""/WeAreAmazing"">/WeAreAmazing</a></li>
                    <li><a href=""/get-this-offers-now"">/get-this-offers-now</a></li>
                </ul>
                </body></html> ",
                ContentType = "text/html"
            };
        }

        public ActionResult AboutUs()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                    <h2>About Us</h2>
                </ul>
                </body></html> ",
                ContentType = "text/html"
            };
        }

        public ActionResult OrderItemsNow()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                    <h2>Order Items Now</h2>
                </ul>
                </body></html> ",
                ContentType = "text/html"
            };
        }

        [Route("WeAreAmazing")]
        public ActionResult Random()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                    <h2>We are Amazing</h2>
                </ul>
                </body></html> ",
                ContentType = "text/html"
            };
        }
    }
}