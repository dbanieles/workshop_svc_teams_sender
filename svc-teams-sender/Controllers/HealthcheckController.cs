using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using svc_teams_sender.Models;

namespace svc_teams_sender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthcheckController : ControllerBase
    {

        private readonly ILogger<HealthcheckController> _logger;

        public HealthcheckController(ILogger<HealthcheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Healthcheck healthcheck()
        {
            return new Healthcheck("svc-teams-sender","OK", DateTime.Now);           
        }
    }
}
