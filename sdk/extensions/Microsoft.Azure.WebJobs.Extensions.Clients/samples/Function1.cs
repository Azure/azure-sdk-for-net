// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;
using System.Linq;

namespace Azure.Extensions.WebJobs.Sample
{
    #region Snippet:AzureClientInFunction
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [AzureClient("MyStorageConnection")] BlobServiceClient client)
        {
            return new OkObjectResult(client.GetBlobContainers().ToArray());
        }
    }
    #endregion
}
