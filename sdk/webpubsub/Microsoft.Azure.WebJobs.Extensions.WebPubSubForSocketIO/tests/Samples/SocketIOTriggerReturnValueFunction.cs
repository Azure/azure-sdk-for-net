// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests.Samples
{
    #region Snippet:SocketIOTriggerReturnValueFunction
    public static class SocketIOTriggerReturnValueFunction
    {
        [FunctionName("TriggerBindingForNewMessageAndAck")]
        public static async Task<SocketIOMessageResponse> TriggerBindingForNewMessageAndAck(
            [SocketIOTrigger("hub", "new message")] SocketIOMessageRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: new message");
            await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { message = request.Parameters } }, new[] { request.SocketId }));
            return new SocketIOMessageResponse(new[] {"ackValue"});
        }
    }
    #endregion
}
