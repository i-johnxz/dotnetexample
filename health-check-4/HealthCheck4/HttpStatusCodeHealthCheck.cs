using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck4
{
    public class HttpStatusCodeHealthCheck : IHealthCheck
    {
        private readonly HttpClient _client;
        private readonly IServer _server;

        public HttpStatusCodeHealthCheck(HttpClient client, IServer server)
        {
            _client = client;
            _server = server;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                //var serverAddress = _server.Features.Get<IServerAddressesFeature>();
                //var localServer = serverAddress.Addresses.First();
                var localServer = "http://localhost:25723";

                var result = await _client.GetAsync(localServer + "/home/fakestatus/?statusCode=500");

                if (result.StatusCode == HttpStatusCode.OK)
                    return HealthCheckResult.Healthy("Everything is OK");
                else
                    return HealthCheckResult.Degraded($"Fails: Http Status returns {result.StatusCode}");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Exception {ex.Message} : {ex.StackTrace}");
            }
        }
    }
}
