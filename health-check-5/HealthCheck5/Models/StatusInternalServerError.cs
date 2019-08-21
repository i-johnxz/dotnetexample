using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HealthCheck5.Models
{
    public class StatusInternalServerError
    {
        public short Status { get; set; } = StatusCodes.Status500InternalServerError;
    }
}
