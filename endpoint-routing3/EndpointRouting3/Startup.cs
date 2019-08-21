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

namespace EndpointRouting3
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

                var url = linkGenerator.GetUriByAction(context,
                    "World",
                    "Hello");

                var url2 = linkGenerator.GetUriByAction(context,
                    "Goodbye",
                    "Hello");

                var url3 = linkGenerator.GetUriByAction(context,
                    "CallMe",
                    "Hello");

                var url4 = linkGenerator.GetUriByAction(context,
                    "Index",
                    "Greet");

                var url5 = linkGenerator.GetUriByAction(context,
                    "Away",
                    "Wave");

                var url6 = linkGenerator.GetUriByAction(context,
                    "YYYY",
                    "XXXX");

                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync($@"Generated Url: 
{url}  
{url2}  
{url3}  
{url4}  
{url5}  
{url6}(It won't produce any link if it cannot figure out controller and action information)");
            });

            app.UseMvc();
        }
    }
}
