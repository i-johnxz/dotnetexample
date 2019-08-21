using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCheck5.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace HealthCheck5
{
    public class OKHttpStatusCodeHealthCheck : HttpStatusCodeHealthCheck
    {
        public OKHttpStatusCodeHealthCheck(HttpClient client, IServer server, StatusOK status) 
            : base(client, server, status.Status)
        {
        }
    }
}
