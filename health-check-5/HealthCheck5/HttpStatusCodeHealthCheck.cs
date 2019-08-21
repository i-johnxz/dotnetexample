using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck5
{
    public abstract class HttpStatusCodeHealthCheck: IHealthCheck
    {
        private readonly HttpClient _client;
        private readonly IServer _server;
        private readonly short _statusCode;

        protected HttpStatusCodeHealthCheck(HttpClient client, IServer server, short statusCode)
        {
            _client = client;
            _server = server;
            _statusCode = statusCode;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var localServer = "http://localhost:23535";

                var result = await _client.GetAsync(localServer + $"/home/fakestatus/?statusCode={_statusCode}");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return HealthCheckResult.Healthy("Everything is Ok");
                }
                else
                {
                    return HealthCheckResult.Degraded($"Fails: Http Status returns {result.StatusCode}");
                }
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy($"Exception {e.Message} : {e.StackTrace}");
            }
        }
    }
}
