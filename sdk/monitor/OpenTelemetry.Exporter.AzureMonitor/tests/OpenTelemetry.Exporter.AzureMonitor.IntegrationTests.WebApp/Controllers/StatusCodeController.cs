// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests.WebApp.Controllers
{
    /// <summary>
    /// This controller is used to verify that the IntegrationTests can send requests to this WebApp and receive responses.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCodeController : ControllerBase
    {
        // GET api/statuscode/{id}
        [HttpGet("{id}")]
        public ActionResult GetStatusCode(int id) => StatusCode(id);
    }
}
