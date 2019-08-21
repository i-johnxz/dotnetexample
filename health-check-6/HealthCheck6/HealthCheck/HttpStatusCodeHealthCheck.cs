using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck6.HealthCheck
{
    public abstract class HttpStatusCodeHealthCheck : IHealthCheck
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
                var localServer = "http://localhost:1077";

                var result = await _client.GetAsync(localServer + $"/home/fakestatus/?statusCode={_statusCode}");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return HealthCheckResult.Healthy("Everything is OK");
                }
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    context.Registration.FailureStatus = HealthStatus.Degraded;
                    return HealthCheckResult.Degraded($"Degraded: Http Status returns {result.StatusCode}");
                }
                else
                {
                    return HealthCheckResult.Unhealthy($"Fails: Http Status returns {result.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Exception {ex.Message} : {ex.StackTrace}");
            }
        }
    }
}
