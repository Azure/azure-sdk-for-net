// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Integration.Identity.Common;

namespace Integration.Identity.Func
{
    /// <summary>
    /// Function1 is an Azure Function that demonstrates Managed Identity authentication.
    /// </summary>
    public class Function1
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the Function1 class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        /// <summary>
        /// HTTP trigger function that processes GET requests.
        /// </summary>
        /// <param name="req">The request</param>
        /// <returns></returns>
        [Function("Function1")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                ManagedIdentityTests.AuthToStorage();
                await Task.Yield();

                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteStringAsync("Successfully acquired a token from ManagedIdentityCredential").ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                var response = req.CreateResponse(HttpStatusCode.BadRequest);
                await response.WriteStringAsync(ex.ToString()).ConfigureAwait(false);
                return response;
            }
        }
    }
}
