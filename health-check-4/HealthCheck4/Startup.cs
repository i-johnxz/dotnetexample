using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddHttpClient<HttpStatusCodeHealthCheck>();

            services.AddHealthChecks()
                .AddCheck<HttpStatusCodeHealthCheck>("HttpStatusCheck");

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecks("/IsUp", new HealthCheckOptions
            {
                ResponseWriter = async (context, health) =>
                {
                    if (health.Status == HealthStatus.Healthy)
                        await context.Response.WriteAsync("Everything is good");
                    else
                    {
                        foreach (var h in health.Entries)
                        {
                            await context.Response.WriteAsync($"{h.Key} {h.Value.Description}");
                        }
                    }
                }
            });
            app.UseMvcWithDefaultRoute();
        }
    }
}
