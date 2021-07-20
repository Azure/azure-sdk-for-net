// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public abstract class EventBasedPerfTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        private readonly SemaphoreSlim _eventProcessed = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _processNextEvent = new SemaphoreSlim(0);

        public EventBasedPerfTest(TOptions options) : base(options)
        {
        }

        protected async Task EventRaised()
        {
            _eventProcessed.Release();
            await _processNextEvent.WaitAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _eventProcessed.WaitAsync(cancellationToken);
            _processNextEvent.Release();
        }
    }
}
