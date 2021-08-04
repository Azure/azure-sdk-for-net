// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubOutputBindingFunction
    public static class WebPubSubOutputBindingFunction
    {
        [FunctionName("WebPubSubOutputBindingFunction")]
        public static async Task RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            [WebPubSub(Hub = "hub")] IAsyncCollector<WebPubSubOperation> operation)
        {
            await operation.AddAsync(new SendToAll
            {
                Message = BinaryData.FromString("Hello Web PubSub"),
                DataType = MessageDataType.Text
            });
        }
    }
    #endregion
}
