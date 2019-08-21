using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCheck5.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace HealthCheck5
{
    public class ErrorHttpStatusCodeHealthCheck : HttpStatusCodeHealthCheck
    {
        public ErrorHttpStatusCodeHealthCheck(HttpClient client, IServer server, StatusInternalServerError status) 
            : base(client, server, status.Status)
        {
        }
    }
}
