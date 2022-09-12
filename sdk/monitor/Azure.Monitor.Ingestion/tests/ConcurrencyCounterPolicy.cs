// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.Ingestion.Tests
{
    internal class ConcurrencyCounterPolicy : HttpPipelinePolicy
    {
        public volatile int count;
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref count);
            ProcessNext(message, pipeline);
            Interlocked.Decrement(ref count);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref count);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            Interlocked.Decrement(ref count);
        }
    }
}
