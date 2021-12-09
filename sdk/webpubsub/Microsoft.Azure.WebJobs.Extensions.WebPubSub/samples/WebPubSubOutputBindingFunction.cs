// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubOutputBindingFunction
    public static class WebPubSubOutputBindingFunction
    {
        [FunctionName("WebPubSubOutputBindingFunction")]
        public static async Task RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            [WebPubSub(Hub = "hub", Connection = "<connection-string>")] IAsyncCollector<WebPubSubAction> action)
        {
            await action.AddAsync(WebPubSubAction.CreateSendToAllAction("Hello Web PubSub!", WebPubSubDataType.Text));
        }
    }
    #endregion
}
