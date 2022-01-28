// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface ISignalRTriggerDispatcher
    {
        void Map((string HubName, string Category, string @Event) key, ExecutionContext executor);

        Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default);
    }
}