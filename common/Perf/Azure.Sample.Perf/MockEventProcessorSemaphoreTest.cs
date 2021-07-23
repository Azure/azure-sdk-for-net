// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessorSemaphoreTest : PerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;
        private readonly SemaphoreSlim _eventProcessed = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _processNextEvent = new SemaphoreSlim(0);

        public MockEventProcessorSemaphoreTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond);
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
        }

        private async Task ProcessEventAsync(MockEventArgs arg)
        {
            _eventProcessed.Release();
            await _processNextEvent.WaitAsync();
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
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
