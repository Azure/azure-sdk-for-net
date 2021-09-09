// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Microsoft.Azure.Webjobs.Extensions.SignalRService.E2ETests
{
    internal class ExternalRoutingClient
    {
        private static readonly HttpClient HttpClient = new();

        public static async Task<SignalRConnectionInfo> Negotiate(string userId, string url, int endpointId)
        {
            const string path = "negotiate";
            var connectionInfo = await HttpClient.GetFromJsonAsync<SignalRConnectionInfo>($"{url}/api/{path}?userId={userId}&endpointId={endpointId}");
            return connectionInfo;
        }

        public static async Task Send(string url, int endpointId, string target)
        {
            const string SendPath = "send";
            await HttpClient.GetAsync($"{url}/api/{SendPath}?endpointId={endpointId}&target={target}");
        }
    }
}