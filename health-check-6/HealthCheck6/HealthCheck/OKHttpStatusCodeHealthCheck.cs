using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCheck6.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace HealthCheck6.HealthCheck
{
    public class OKHttpStatusCodeHealthCheck : HttpStatusCodeHealthCheck
    {
        public OKHttpStatusCodeHealthCheck(HttpClient client, IServer server, StatusOK status) 
            : base(client, server, status.Status)
        {
        }
    }
}
