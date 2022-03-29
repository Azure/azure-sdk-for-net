// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public Dictionary<(string Item1, string Item2, string Item3), ExecutionContext> Executors { get; } =
            new Dictionary<(string, string, string), ExecutionContext>();

        public void Map((string HubName, string Category, string @Event) key, ExecutionContext executor)
        {
            Executors.Add(key, executor);
        }

        public Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}