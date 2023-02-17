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
        public volatile int MaxCount;

        public ConcurrencyCounterPolicy(int concurrency)
        {
            _maxConcurrency = concurrency;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            ProcessNext(message, pipeline);
            //in the sync case, the number of threads running should not exceed 1
            Assert.GreaterOrEqual(1, Count);
            Interlocked.Decrement(ref Count);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Interlocked.Increment(ref Count);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            //in the async case, the number of threads running should not exceed the specified _maxConcurrency
            Assert.GreaterOrEqual(_maxConcurrency, Count);
            MaxCount = Math.Max(Count, MaxCount);
            Interlocked.Decrement(ref Count);
        }
    }
}
