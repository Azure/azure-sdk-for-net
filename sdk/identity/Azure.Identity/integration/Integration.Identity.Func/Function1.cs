// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Integration.Identity.Common;

namespace Integration.Identity.Func
{
    /// <summary>
    /// Function1 is an Azure Function that demonstrates Managed Identity authentication.
    /// </summary>
    public static class Function1
    {
        /// <summary>
        /// HTTP trigger function that processes GET requests.
        /// </summary>
        /// <param name="req">The request</param>
        /// <param name="log">The logger</param>
        /// <returns></returns>
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                ManagedIdentityTests.AuthToStorage();
                await Task.Yield();
                return new OkObjectResult("Successfully acquired a token from ManagedIdentityCredential");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.ToString());
            }
        }
    }
}
