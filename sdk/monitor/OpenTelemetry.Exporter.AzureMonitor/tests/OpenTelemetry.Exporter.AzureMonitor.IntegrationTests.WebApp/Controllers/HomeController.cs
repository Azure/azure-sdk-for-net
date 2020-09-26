// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;

using Microsoft.AspNetCore.Mvc;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
#pragma warning disable IDE0060 // Remove unused parameter
        /// <summary>
        /// This URI will always return 200.
        /// </summary>
        /// <param name="id">Set this value to a random value and use this value to distinguish requests in any unit tests.</param>
        /// <returns></returns>
        // GET api/home/{id?}
        [HttpGet("{id?}")]
        public ActionResult<string> Get(int id = 0) => StatusCode((int)HttpStatusCode.OK);
#pragma warning restore IDE0060 // Remove unused parameter
    }
}
