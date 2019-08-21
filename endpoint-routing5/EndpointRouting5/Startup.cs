using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace EndpointRouting5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            app.Use(async (context, next) =>
            {
                var linkGenerator = context.RequestServices.GetService<LinkGenerator>();

                var url = linkGenerator.GetPathByAction(context,
                    "World",
                    "Hello",
                    new {name = "hello"});

                var url2 = linkGenerator.GetPathByAction(context,
                    "Goodbye",
                    "Hello",
                    new {age = 40});

                var url3 = linkGenerator.GetPathByAction(context,
                    "CallMe",
                    "Hello");

                var url4 = linkGenerator.GetPathByAction(context,
                    "Index",
                    "Greet",
                    new
                    {
                        isNice = true
                    });

                var url5 = linkGenerator.GetPathByAction(context,
                    "Away",
                    "Wave",
                    new
                    {
                        danger = "real danger",
                        ahead = "5 km ahead"
                    });

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($@"Generated Url: 
{url} 
{url2}  
{url3} 
{url4}  
{url5}");

            });

            app.UseMvc();
        }
    }
}
