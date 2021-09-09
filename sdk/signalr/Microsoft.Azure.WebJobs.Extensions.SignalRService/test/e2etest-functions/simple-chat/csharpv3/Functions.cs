// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Newtonsoft.Json;

namespace SimpleChat
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "simplechat", UserId = "{query.userid}")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("send")]
        public static async Task Send(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalR(HubName = "simplechat")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            using (var rd = new StreamReader(req.Body))
            {
                var message = JsonConvert.DeserializeObject<SignalRMessage>(await rd.ReadToEndAsync());
                await signalRMessages.AddAsync(message);
            }
        }

        [FunctionName("group")]
        public static async Task Group(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalR(HubName = "simplechat")] IAsyncCollector<SignalRGroupAction> signalRGroupActions)
        {
            using (var rd = new StreamReader(req.Body))
            {
                var message = JsonConvert.DeserializeObject<SignalRGroupAction>(await rd.ReadToEndAsync());
                await signalRGroupActions.AddAsync(message);
            }
        }
    }
}