// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal interface ISignalRTriggerDispatcher
    {
        void Map((string hubName, string category, string @event) key, ExecutionContext executor);

        Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default);
    }
}