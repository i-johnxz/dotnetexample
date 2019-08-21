using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AllowSyncIO
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
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path == "/home/sync")
                {
                    try
                    {
                        using (var streamReader = new StreamReader(ctx.Request.Body, Encoding.UTF8))
                        {
                            string body = streamReader.ReadToEnd();
                        }

                        ctx.Request.HttpContext.Items["Message"] = "Hello world";
                    }
                    catch (Exception ex)
                    {
                        ctx.Request.HttpContext.Items["Message"] = "Exception message " + ex.Message;
                    }
                }

                await next();
            });


            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path == "/home/async")
                {
                    try
                    {
                        using (var streamReader = new StreamReader(ctx.Request.Body, Encoding.UTF8))
                        {
                            string body = await streamReader.ReadToEndAsync();
                        }

                        ctx.Request.HttpContext.Items["Message"] = "Hello world";
                    }
                    catch (Exception ex)
                    {
                        ctx.Request.HttpContext.Items["Message"] = "Exception message" + ex.Message;
                    }
                }

                await next();
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
