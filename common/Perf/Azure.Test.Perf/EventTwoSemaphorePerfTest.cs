// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventTwoSemaphorePerfTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        private readonly SemaphoreSlim _eventProcessed = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _processNextEvent = new SemaphoreSlim(0);
        private CancellationToken _cancellationToken;

        public EventTwoSemaphorePerfTest(TOptions options) : base(options)
        {
        }

        protected Task EventRaisedAsync()
        {
            _eventProcessed.Release();
            return _processNextEvent.WaitAsync(_cancellationToken);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("EventPerfTest only supports async");
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            // Share cancellation token with EventRaisedAsync() method
            _cancellationToken = cancellationToken;

            await _eventProcessed.WaitAsync(cancellationToken);

            _processNextEvent.Release();
        }
    }
}
