// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    internal class ConcurrencyCounterPolicy : HttpPipelinePolicy
    {
        public volatile int Count;
        private int _maxConcurrency;

        public ConcurrencyCounterPolicy(int concurrency)
        {
            _maxConcurrency = concurrency;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            ProcessNext(message, pipeline);
            Assert.GreaterOrEqual(1, Count); //in the sync case, the number of threads running should not exceed 1
            Interlocked.Decrement(ref Count);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            Assert.GreaterOrEqual(_maxConcurrency, Count); //in the async case, the number of threads running should not exceed the specified _maxConcurrency
            Interlocked.Decrement(ref Count);
        }
    }
}
