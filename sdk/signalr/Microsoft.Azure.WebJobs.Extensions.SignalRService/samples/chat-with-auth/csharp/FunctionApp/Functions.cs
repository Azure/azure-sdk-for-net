// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FunctionApp
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous)]HttpRequest req, 
            [SignalRConnectionInfo(HubName = "authchat", UserId = "{headers.x-ms-client-principal-name}", IdToken = "{headers.X-MS-TOKEN-AAD-ID-TOKEN}", ClaimTypeList = new string[] { "email" })]
                SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("messages")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req, 
            [SignalR(HubName = "authchat")]IAsyncCollector<SignalRMessage> signalRMessages)
        {
            var message = DeserializeFromStream<ChatMessage>(req.Body);
            req.Headers.TryGetValue("x-ms-client-principal-name", out var sender);

            if (!string.IsNullOrEmpty(sender))
            {
                message.sender = sender;
            }

            string userId = null;
            message.isPrivate = !string.IsNullOrEmpty(message.recipient);
            if (message.isPrivate)
            {
                userId = message.recipient;
            }

            return signalRMessages.AddAsync(
                new SignalRMessage 
                {
                    UserId = userId,
                    Target = "newMessage", 
                    Arguments = new [] { message } 
                });
        }

        private static T DeserializeFromStream<T>(Stream stream)
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }

        public class ChatMessage
        {
            public string sender { get; set; }
            public string text { get; set; }
            public string recipient { get; set; }
            public bool isPrivate { get; set; }
        }
    }
}
