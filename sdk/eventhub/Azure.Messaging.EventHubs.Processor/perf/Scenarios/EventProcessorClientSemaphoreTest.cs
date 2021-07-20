// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Perf.Infrastructure;

namespace Azure.Messaging.EventHubs.Processor.Perf.Scenarios
{
    public class EventProcessorClientSemaphoreTest : EventProcessorClientTest<EventProcessorClientPerfOptions>
    {
        private readonly SemaphoreSlim _eventProcessed = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _processNextEvent = new SemaphoreSlim(0);

        public EventProcessorClientSemaphoreTest(EventProcessorClientPerfOptions options) : base(options)
        {
            EventProcessorClient.ProcessEventAsync += ProcessEventAsync;
            EventProcessorClient.ProcessErrorAsync += ProcessErrorAsync;
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            throw arg.Exception;
        }

        private async Task ProcessEventAsync(ProcessEventArgs arg)
        {
            _eventProcessed.Release();
            await _processNextEvent.WaitAsync();
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await EventProcessorClient.StartProcessingAsync();
        }

        public override async Task CleanupAsync()
        {
            await EventProcessorClient.StopProcessingAsync();
            await base.CleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _eventProcessed.WaitAsync(cancellationToken);
            _processNextEvent.Release();

            if (Options.DelayMilliseconds > 0)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(Options.DelayMilliseconds));
            }
        }
    }
}
