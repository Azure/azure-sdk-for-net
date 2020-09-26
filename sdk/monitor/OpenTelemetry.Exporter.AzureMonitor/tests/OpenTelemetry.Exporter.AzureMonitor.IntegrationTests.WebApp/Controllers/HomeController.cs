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
        // GET api/home
        [HttpGet]
        public ActionResult Get() => StatusCode((int)HttpStatusCode.OK);
    }
}
