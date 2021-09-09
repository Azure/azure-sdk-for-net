// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using ExecutionContext = Microsoft.Azure.WebJobs.Extensions.SignalRService.ExecutionContext;

namespace SignalRServiceExtension.Tests.Utils
{
    internal class TestTriggerDispatcher : ISignalRTriggerDispatcher
    {
        public Dictionary<(string, string, string), ExecutionContext> Executors { get; } =
            new Dictionary<(string, string, string), ExecutionContext>();

        public void Map((string hubName, string category, string @event) key, ExecutionContext executor)
        {
            Executors.Add(key, executor);
        }

        public Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}