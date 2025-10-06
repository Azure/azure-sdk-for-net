// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests.Samples
{
    #region Snippet:SocketIOBindingFunction
    public static class SocketIOBindingFunction
    {
        [FunctionName("SocketIOInputBinding")]
        public static IActionResult SocketInputBinding(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [SocketIONegotiation(Hub = "hub", UserId = "uid")] SocketIONegotiationResult result)
        {
            return new OkObjectResult(result);
        }
    }
    #endregion
}
