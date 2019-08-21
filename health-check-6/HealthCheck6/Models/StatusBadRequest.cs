using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HealthCheck6.Models
{
    public class StatusBadRequest
    {
        public short Status { get; set; } = StatusCodes.Status400BadRequest;
    }
}
