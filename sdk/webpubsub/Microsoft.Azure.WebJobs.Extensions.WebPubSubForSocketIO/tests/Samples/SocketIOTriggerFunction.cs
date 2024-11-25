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
    #region Snippet:SocketIOTriggerFunction
    public static class SocketIOTriggerFunction
    {
        [FunctionName("TriggerBindingForConnect")]
        public static SocketIOEventHandlerResponse TriggerBindingForConnect(
            [SocketIOTrigger("hub", "connect")] SocketIOConnectRequest request,
            ILogger log)
        {
            log.LogInformation("Running trigger for: connect");
            return new SocketIOConnectResponse();
        }

        [FunctionName("TriggerBindingForConnected")]
        public static void TriggerBindingForConnected(
            [SocketIOTrigger("hub", "connected")] SocketIOConnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: connected");
        }

        [FunctionName("TriggerBindingForDisconnected")]
        public static void TriggerBindingForDisconnected(
            [SocketIOTrigger("hub", "disconnected")] SocketIODisconnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: disconnected");
        }

        [FunctionName("TriggerBindingForNewMessage")]
        public static async Task TriggerBindingForNewMessage(
            [SocketIOTrigger("hub", "new message")] SocketIOMessageRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: new message");
            await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { message = request.Parameters } }, new[] { request.SocketId }));
        }
    }
    #endregion
}
