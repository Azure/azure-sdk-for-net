// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests.Samples
{
    #region Snippet:SocketIOOutputBindingFunction
    public static class SocketIOOutputBindingFunction
    {
        [FunctionName("SocketIOOutputBinding")]
        public static async Task<IActionResult> OutboundBinding(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> operation,
            ILogger log)
        {
            string userName = Guid.NewGuid().ToString();
            await operation.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { username = userName, message = "Hello" } }));
            log.LogInformation("Send to namespace finished.");
            return new OkObjectResult("ok");
        }
    }
    #endregion
}
