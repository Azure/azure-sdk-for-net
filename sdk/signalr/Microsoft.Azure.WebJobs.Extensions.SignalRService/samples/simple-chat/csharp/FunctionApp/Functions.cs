// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FunctionApp
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "simplechat", UserId = "{headers.x-ms-signalr-userid}")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        //// Each function must have a unique name, you can uncomment this one and comment the above GetSignalRInfo() function to have a try.
        //// This "negotiate" function shows how to utilize ServiceManager to generate access token and client url to Azure SignalR service.
        //[FunctionName("negotiate")]
        //public static SignalRConnectionInfo GetSignalRInfo(
        //    [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req)
        //{
        //    var userId = req.Query["userid"];
        //    var hubName = req.Query["hubname"];
        //    var connectionInfo = new SignalRConnectionInfo();
        //    var serviceManager = StaticServiceHubContextStore.Get().ServiceManager;
        //    connectionInfo.AccessToken = serviceManager
        //        .GenerateClientAccessToken(
        //            hubName,
        //            userId,
        //            new List<Claim> { new Claim("claimType", "claimValue") });
        //    connectionInfo.Url = serviceManager.GetClientEndpoint(hubName);
        //    return connectionInfo;
        //}

        [FunctionName("broadcast")]
        public static async Task Broadcast(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req,
            [SignalR(HubName = "simplechat")]IAsyncCollector<SignalRMessage> signalRMessages)
        {
            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(req.Body)));
            var serviceHubContext = await StaticServiceHubContextStore.Get().GetAsync("simplechat");
            await serviceHubContext.Clients.All.SendAsync("newMessage", message);
        }

        [FunctionName("messages")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req,
            [SignalR(HubName = "simplechat")]IAsyncCollector<SignalRMessage> signalRMessages)
        {
            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(req.Body)));

            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    UserId = message.Recipient,
                    GroupName = message.Groupname,
                    Target = "newMessage",
                    Arguments = new[] { message }
                });
        }

        [FunctionName("addToGroup")]
        public static Task AddToGroup(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req,
            [SignalR(HubName = "simplechat")]IAsyncCollector<SignalRGroupAction> signalRGroupActions)
        {

            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(req.Body)));

            var decodedfConnectionId = GetBase64DecodedString(message.ConnectionId);

            return signalRGroupActions.AddAsync(
                new SignalRGroupAction
                {
                    ConnectionId = decodedfConnectionId,
                    UserId = message.Recipient,
                    GroupName = message.Groupname,
                    Action = GroupAction.Add
                });
        }

        [FunctionName("removeFromGroup")]
        public static Task RemoveFromGroup(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req,
            [SignalR(HubName = "simplechat")]IAsyncCollector<SignalRGroupAction> signalRGroupActions)
        {

            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(req.Body)));

            var decodedfConnectionId = GetBase64DecodedString(message.ConnectionId);

            return signalRGroupActions.AddAsync(
                new SignalRGroupAction
                {
                    ConnectionId = message.ConnectionId,
                    UserId = message.Recipient,
                    GroupName = message.Groupname,
                    Action = GroupAction.Remove
                });
        }

        private static string GetBase64EncodedString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        private static string GetBase64DecodedString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(source));
        }


        public static class EventGridTriggerCSharp
        {
            [FunctionName("onConnection")]
            public static Task EventGridTest([EventGridTrigger]EventGridEvent eventGridEvent,
                [SignalR(HubName = "simplechat")]IAsyncCollector<SignalRMessage> signalRMessages)
            {
                if (eventGridEvent.EventType == "Microsoft.SignalRService.ClientConnectionConnected")
                {
                    var message = ((JObject)eventGridEvent.Data).ToObject<SignalREvent>();

                    return signalRMessages.AddAsync(
                        new SignalRMessage
                        {
                            ConnectionId = message.ConnectionId,
                            Target = "newConnection",
                            Arguments = new[] { new ChatMessage
                            {
                                // ConnectionId is not recommand to send to client directly.
                                // Here's a simple encryption for an easier sample.
                                ConnectionId = GetBase64EncodedString(message.ConnectionId),
                            }}
                        });
                }

                return Task.CompletedTask;
            }
        }

        public class ChatMessage
        {
            public string Sender { get; set; }
            public string Text { get; set; }
            public string Groupname { get; set; }
            public string Recipient { get; set; }
            public string ConnectionId { get; set; }
            public bool IsPrivate { get; set; }
        }

        public class SignalREvent
        {
            public DateTime Timestamp { get; set; }
            public string HubName { get; set; }
            public string ConnectionId { get; set; }
            public string UserId { get; set; }
        }
    }
}
