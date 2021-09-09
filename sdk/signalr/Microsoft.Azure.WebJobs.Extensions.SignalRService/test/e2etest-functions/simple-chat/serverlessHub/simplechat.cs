// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Newtonsoft.Json;

namespace serverlessHub
{
    public class simplechat : ServerlessHub
    {
        [FunctionName("negotiate")]
        public Task<SignalRConnectionInfo> Negotiate([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req)
        {
            return NegotiateAsync(new NegotiationOptions
            {
                UserId = req.Query["userid"].Single()
            });
        }

        [FunctionName("send")]
        public async Task Send([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            using (var rd = new StreamReader(req.Body))
            {
                var message = JsonConvert.DeserializeObject<SignalRMessage>(await rd.ReadToEndAsync());
                if (!string.IsNullOrEmpty(message.ConnectionId))
                {
                    await Clients.Client(message.ConnectionId).SendCoreAsync(message.Target, message.Arguments);
                }
                else if (!string.IsNullOrEmpty(message.UserId))
                {
                    await Clients.User(message.UserId).SendCoreAsync(message.Target, message.Arguments);
                }
                else if (!string.IsNullOrEmpty(message.GroupName))
                {
                    await Clients.Group(message.GroupName).SendCoreAsync(message.Target, message.Arguments);
                }
                else
                {
                    await Clients.All.SendCoreAsync(message.Target, message.Arguments);
                }
            }
        }

        [FunctionName("group")]
        public async Task Group([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            using (var rd = new StreamReader(req.Body))
            {
                var groupAction = JsonConvert.DeserializeObject<SignalRGroupAction>(await rd.ReadToEndAsync());
                if (!string.IsNullOrEmpty(groupAction.ConnectionId))
                {
                    switch (groupAction.Action)
                    {
                        case GroupAction.Add:
                            await Groups.AddToGroupAsync(groupAction.ConnectionId, groupAction.GroupName);
                            break;

                        case GroupAction.Remove:
                            await Groups.RemoveFromGroupAsync(groupAction.ConnectionId, groupAction.GroupName);
                            break;
                    }
                }
                else if (!string.IsNullOrEmpty(groupAction.UserId))
                {
                    switch (groupAction.Action)
                    {
                        case GroupAction.Add:
                            await UserGroups.AddToGroupAsync(groupAction.UserId, groupAction.GroupName);
                            break;

                        case GroupAction.Remove:
                            await UserGroups.RemoveFromGroupAsync(groupAction.UserId, groupAction.GroupName);
                            break;

                        case GroupAction.RemoveAll:
                            await UserGroups.RemoveFromAllGroupsAsync(groupAction.UserId);
                            break;
                    }
                }
            }
        }

    }
}