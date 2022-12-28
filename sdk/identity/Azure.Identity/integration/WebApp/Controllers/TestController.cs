using System;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet(Name = "GetTest")]
        public IActionResult Get()
        {
            string resourceId = Environment.GetEnvironmentVariable("IDENTITY_WEBAPP_USER_DEFINED_IDENTITY")!;
            string account1 = Environment.GetEnvironmentVariable("IDENTITY_STORAGE_NAME_1")!;
            string account2 = Environment.GetEnvironmentVariable("IDENTITY_STORAGE_NAME_2")!;

            var credential1 = new ManagedIdentityCredential();
            var credential2 = new ManagedIdentityCredential(new ResourceIdentifier(resourceId));
            var client1 = new BlobServiceClient(new Uri($"https://{account1}.blob.core.windows.net/"), credential1);
            var client2 = new BlobServiceClient(new Uri($"https://{account2}.blob.core.windows.net/"), credential2);
            try
            {
                var results = client1.GetBlobContainers().ToList();
                results = client2.GetBlobContainers().ToList();
                return Ok("Successfully acquired a token from ManagedIdentityCredential");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
