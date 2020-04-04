// Copyright (c) Cingulara LLC 2019 and Tutela LLC 2019. All rights reserved.
// Licensed under the GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007 license. See LICENSE file in the project root for full license information.
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using openrmf_templates_api.Data;

namespace openrmf_templates_api.Controllers
{
    [Route("healthz")]
    public class HealthController : Controller
    {
       private readonly ILogger<HealthController> _logger;
       private readonly ITemplateRepository _TemplateRepo;

        public HealthController(ITemplateRepository TemplateRepo, ILogger<HealthController> logger)
        {
            _logger = logger;
            _TemplateRepo = TemplateRepo;
        }

        /// <summary>
        /// GET the health status of this API
        /// mainly for the K8s health check but can be used for any kind of health check.
        /// </summary>
        /// <returns>an OK if good to go, otherwise returns a bad request</returns>
        /// <response code="200">Returns a healthy status</response>
        /// <response code="400">If the health check is bad</response>
        [HttpGet]
        public ActionResult<string> Get()
        {
            try {
                _logger.LogInformation(string.Format("/healthz: healthcheck heartbeat"));
                if (_TemplateRepo.HealthStatus())
                    return Ok("ok");
                else
                    return BadRequest("database error");
            }
            catch (Exception ex){
                _logger.LogError(ex, "Healthz check failed!");
                return BadRequest("Improper API configuration"); 
            }
        }
    }
}
