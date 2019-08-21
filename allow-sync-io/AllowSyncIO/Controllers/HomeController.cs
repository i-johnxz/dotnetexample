using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AllowSyncIO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <p>
                    In this sample we do not allow Synchronous IO in the web system when running on Kestrel.
                </p>
                <p>
                    Sync IO is bad because it can create thread starvation.Disallowing it makes sures that you don't have such code in your request pipeline.
               </p>
               <p>
               <a href=""/Home/Sync"">Click on this link</a> and it will generate an exception because the middleware before this process will try to use synchronous IO. 
               </p>
               <p>
               <a href=""/Home/Async"">Click on this link</a> and it will work properly because the middleware uses async IO.
               </p>
               
               </body></html>
                ",
                ContentType = "text/html"
            };
        }

        public ActionResult Sync()
        {
            var message = HttpContext.Items["Message"];
            return new ContentResult
            {
                Content = $@"
                <html><body>
                <p>If you set AllowSynchronousIO == true, you will see a greeting message. If you set AllowSynchronousIO == false, you will see an exception message</p>
                    Message from middleware : {message}.
               </body></html> ",
                ContentType = "text/html"
            };
        }

        public ActionResult Async()
        {
            var message = HttpContext.Items["Message"];
            return new ContentResult
            {
                Content = $@"
<html><body>
                    Message from middleware : {message}.
               </body></html>
",
                ContentType = "text/html"
            };
        }
        
    
    }
}