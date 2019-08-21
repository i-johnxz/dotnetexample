using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParameterTransformer.Controllers
{
    [Route("[controller]")]
    public class GetThisOffersNowController : Controller
    {
        public ActionResult TheNameOfThisActionDoesNotMatterBecauseThisIsTheOnlyOneInThisController()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                    <h2>Get This Offers Now</h2>
                    This is an example where the transformation applied to the [controller] token.
                </ul>
                </body></html> ",
                ContentType = "text/html"
            };
        }
    }
}