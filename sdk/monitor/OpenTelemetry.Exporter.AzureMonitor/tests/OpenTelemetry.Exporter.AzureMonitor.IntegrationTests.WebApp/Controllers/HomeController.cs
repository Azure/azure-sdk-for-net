// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;

using Microsoft.AspNetCore.Mvc;

namespace OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.WebApp.Controllers
{
    /// <summary>
    /// This controller is used to verify that the IntegrationTests project can send requests to this WebApp and receive responses.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
#pragma warning disable IDE0060 // Remove unused parameter
        /// <summary>
        /// This URI will always return <see cref="HttpStatusCode.OK"/>.
        /// <code>GET api/home/{id?}</code>
        /// </summary>
        /// <param name="id">Set this value to a random value and use this value to distinguish requests in any unit tests.</param>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public ActionResult<string> Get(string id = null) => StatusCode((int)HttpStatusCode.OK);
#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// This URI will return the <see cref="HttpStatusCode"/> matching the provided value.
        /// <code>GET api/home/statuscode/{id}</code>
        /// </summary>
        /// <param name="id">The value of <see cref="HttpStatusCode"/> to return.</param>
        /// <returns></returns>
        [HttpGet("statuscode/{id}")]
        public ActionResult GetStatusCode(int id) => StatusCode(id);
    }
}
