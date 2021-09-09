// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Xunit;
using static Microsoft.Azure.Webjobs.Extensions.SignalRService.E2ETests.Utils;
using Client = Microsoft.Azure.Webjobs.Extensions.SignalRService.E2ETests.ExternalRoutingClient;

namespace Microsoft.Azure.Webjobs.Extensions.SignalRService.E2ETests
{
    public class ExternalRoutingTests
    {
        private const string Section = "ExternalRouting";

        public static readonly IEnumerable<object[]> FunctionUrls = GetFunctionUrls(Section);

        /// <summary>
        /// Set up two connections, each of which connects to a different endpoint.
        /// Trigger the function to send a message to endpoint[0]. The parameter is the endpoint itself. Validate the endpoint status in the connection[0].
        /// Repeat last step to the endpoint[1].
        /// </summary>
        [MemberData(nameof(FunctionUrls))]
        [SkipIfFunctionAbsent(Section)]
        public async Task RoutingTest(string key, string url)
        {
            var target = nameof(RoutingTest) + key;
            const int count = 2;
            var users = GenerateRandomUsers(count).ToArray();
            var completionSources = new ConcurrentDictionary<string, TaskCompletionSource>();
            var tasks = Enumerable.Range(0, count).Zip(users).Select(async (pair) =>
            {
                var (endpointId, user) = pair;
                var connectionInfo = await Client.Negotiate(user, url, endpointId);
                var connection = CreateHubConnection(connectionInfo.Url, connectionInfo.AccessToken);
                var taskCompleSource = new TaskCompletionSource();
                completionSources.TryAdd(user, taskCompleSource);
                connection.On(target, (LiteServiceEndpoint endpoint) =>
                {
                    var expectedHost = new Uri(connectionInfo.Url).Host;
                    var actualHost = new Uri(endpoint.Endpoint).Host;
                    if (expectedHost.Equals(actualHost) && endpoint.Online)
                    {
                        completionSources[user].SetResult();
                    }
                    else
                    {
                        completionSources[user].SetException(new Exception($"Expected host:{expectedHost}, Actual host:{actualHost}"));
                    }
                });
                await connection.StartAsync();
                return connection;
            }).ToArray();
            var connections = await Task.WhenAll(tasks);

            // send a message to endpoint[0]
            await Client.Send(url, 0, target);
            await Task.WhenAny(completionSources.Values.Select(s => s.Task.OrTimeout()));

            // received the correct messsage
            Assert.True(completionSources[users[0]].Task.IsCompletedSuccessfully);
            // not received messages yet
            Assert.False(completionSources[users[1]].Task.IsCompleted);

            //reset
            foreach (var user in users)
            {
                completionSources[user] = new TaskCompletionSource();
            }

            // send a message to endpoint[1]
            await Client.Send(url, 1, target);
            await Task.WhenAny(completionSources.Values.Select(s => s.Task.OrTimeout()));
            Assert.True(completionSources[users[1]].Task.IsCompletedSuccessfully);
            Assert.False(completionSources[users[0]].Task.IsCompleted);
        }
    }
}