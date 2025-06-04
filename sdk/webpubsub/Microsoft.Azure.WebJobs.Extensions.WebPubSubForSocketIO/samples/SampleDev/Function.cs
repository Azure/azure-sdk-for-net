// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using ExecutionContext = Microsoft.Azure.WebJobs.ExecutionContext;

namespace SampleDev
{
    public static class Function
    {
        [FunctionName("index")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req, ExecutionContext context, ILogger log)
        {
            var indexFile = Path.Combine(context.FunctionAppDirectory, "public/index.html");
            log.LogInformation($"index.html path: {indexFile}.");
            return new ContentResult
            {
                Content = File.ReadAllText(indexFile),
                ContentType = "text/html",
            };
        }

        [FunctionName("Negotiate")]
        public static IActionResult SocketIONegotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [SocketIONegotiation(Hub = "hub", UserId = "{query.userId}")] SocketIONegotiationResult result)
        {
            return new OkObjectResult(result);
        }

        [FunctionName("TriggerBindingForConnect")]
        public static SocketIOEventHandlerResponse TriggerBindingForConnect(
            [SocketIOTrigger("hub", "connect")] SocketIOConnectRequest request,
            string userId,
            ILogger log)
        {
            log.LogInformation($"Running trigger for: connect for {userId}");
            return new SocketIOConnectResponse();
        }

        [FunctionName("TriggerBindingForConnected")]
        public static async Task TriggerBindingForConnected(
            [SocketIOTrigger("hub", "connected")] SocketIOConnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            string userId,
            ILogger log)
        {
            log.LogInformation("Running trigger for: connected");
            await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { "system", $"{userId} connected" }));
        }

        [FunctionName("TriggerBindingForDisconnected")]
        public static async Task TriggerBindingForDisconnected(
            [SocketIOTrigger("hub", "disconnected")] SocketIODisconnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            string userId,
            ILogger log)
        {
            log.LogInformation("Running trigger for: disconnected");
            await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { "system", $"{userId} disconnected" }));
        }

        [FunctionName("TriggerBindingForChat")]
        public static async Task TriggerBindingForChat(
            [SocketIOTrigger("hub", "chat")] SocketIOMessageRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            SocketIOSocketContext connectionContext,
            [SocketIOParameter] string message,
            ILogger log)
        {
            log.LogInformation("Running trigger for: new message");
            log.LogInformation($"Arguments: {string.Join(';', request.Parameters)}");

            var userId = connectionContext.UserId;
            await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { userId, message }, new[] { request.SocketId }));
        }
    }
}
