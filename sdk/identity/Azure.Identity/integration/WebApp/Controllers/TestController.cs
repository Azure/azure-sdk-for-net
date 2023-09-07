using System;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Integration.Identity.Common;

namespace WebApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

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
