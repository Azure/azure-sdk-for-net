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
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;

namespace SampleDev
{
    public static class Function
    {
        private static int _numUsers = 0;
        private static ConcurrentDictionary<string, SocketContext> _store = new();

        [FunctionName("OutboundBinding")]
        public static async Task<IActionResult> OutboundBinding(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> operation,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request. {Base64UrlEncoder.Encode("abc")}");
            string userName = Guid.NewGuid().ToString();
            await operation.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { username = userName,
                message = "Hello" } }));
            log.LogInformation("Send to namespace finished.");
            return new OkObjectResult("ok");
        }

        [FunctionName("Negotiate")]
        public static async Task<IActionResult> SocketIONegotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [SocketIONegotiation(Hub = "hub")] SocketIONegotiationResult result)
        {
            return new OkObjectResult(result);
        }

        [FunctionName("TriggerBindingForConnect")]
        public static async Task<SocketIOEventHandlerResponse> TriggerBindingForConnect(
            [SocketIOTrigger("hub", "connect")] SocketIOConnectRequest request,
            ILogger log)
        {
            log.LogInformation("Running trigger for: connect");
            return new SocketIOConnectResponse();
        }

        [FunctionName("TriggerBindingForConnected")]
        public static async Task TriggerBindingForConnected(
            [SocketIOTrigger("hub", "connected")] SocketIOConnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: connected");
            if (_store.TryAdd(request.SocketId, new SocketContext()))
            {
                Interlocked.Increment(ref _numUsers);
            }
        }

        [FunctionName("TriggerBindingForDisconnected")]
        public static async Task TriggerBindingForDisconnected(
            [SocketIOTrigger("hub", "disconnected")] SocketIODisconnectedRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: disconnected");
            if (_store.TryRemove(request.SocketId, out var context))
            {
                await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("user left", new[] { new { username = context.UserName, numUsers = Interlocked.Decrement(ref _numUsers)} }, new[] {request.SocketId}));
            }
        }

        [FunctionName("TriggerBindingForNewMessage")]
        public static async Task TriggerBindingForNewMessage(
            [SocketIOTrigger("hub", "new message")] SocketIOMessageRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: new message");
            log.LogInformation($"Arguments: {string.Join(';', request.Parameters)}");

            if (_store.TryGetValue(request.SocketId, out var context))
            {
                await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("new message", new[] { new { username = context.UserName, message = request.Parameters } }, new[] { request.SocketId }));
            }
        }

        [FunctionName("TriggerBindingForAddUser")]
        public static async Task TriggerBindingForAddUser(
            [SocketIOTrigger("hub", "add user")] SocketIOMessageRequest request,
            [SocketIO(Hub = "hub")] IAsyncCollector<SocketIOAction> collector,
            ILogger log)
        {
            log.LogInformation("Running trigger for: add user");
            log.LogInformation($"Arguments: {string.Join(';', request.Parameters)}");

            var userName = request.Parameters[0].ToString();
            if (_store.TryGetValue(request.SocketId, out var context))
            {
                if (context.AddedUser)
                {
                    return;
                }
                context.AddedUser = true;
                context.UserName = userName;

                await collector.AddAsync(SocketIOAction.CreateSendToSocketAction(request.SocketId, "login", new[] { new { numUsers = _numUsers } }));
                await collector.AddAsync(SocketIOAction.CreateSendToNamespaceAction("user joined", new[] { new { username = userName, numUsers = _numUsers } }, new[] { request.SocketId }));
            }
        }

        private class SocketContext
        {
            public bool AddedUser { get; set; }
            public string UserName { get; set; }
        }
    }
}
