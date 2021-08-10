// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventOneSemaphorePerfTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        private SemaphoreSlim _eventsQueued = new SemaphoreSlim(0);

        public EventOneSemaphorePerfTest(TOptions options) : base(options)
        {
        }

        protected void EventRaisedAsync()
        {
            _eventsQueued.Release();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("EventQueuePerfTest only supports async");
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _eventsQueued.WaitAsync();
        }
    }
}
