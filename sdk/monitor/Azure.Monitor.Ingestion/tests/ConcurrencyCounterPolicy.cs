// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Ingestion.Tests
{
    internal class ConcurrencyCounterPolicy : HttpPipelinePolicy
    {
        public volatile int Count;
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            ProcessNext(message, pipeline);
            Interlocked.Decrement(ref Count);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            Interlocked.Decrement(ref Count);
        }
    }
}
