// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Integration.Identity.Common;

namespace WebApp.Controllers
{
    /// <summary>
    /// Controller to test Managed Identity authentication.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Endpoint to test Managed Identity authentication.
        /// </summary>
        [HttpGet(Name = "GetTest")]
        public IActionResult Get()
        {
            try
            {
                ManagedIdentityTests.AuthToStorage();
                return Ok("Successfully acquired a token from ManagedIdentityCredential");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
