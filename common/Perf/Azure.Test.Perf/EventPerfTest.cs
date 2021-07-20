// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventPerfTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        private readonly SemaphoreSlim _eventProcessed = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _processNextEvent = new SemaphoreSlim(0);
        private CancellationToken _cancellationToken;

        public EventPerfTest(TOptions options) : base(options)
        {
        }

        protected async Task EventRaised()
        {
            _eventProcessed.Release();

            await _processNextEvent.WaitAsync(_cancellationToken);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Event-based perf tests only support async");
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            // Share cancellation token with EventRaised() method
            _cancellationToken = cancellationToken;

            await _eventProcessed.WaitAsync(cancellationToken);

            _processNextEvent.Release();
        }
    }
}
