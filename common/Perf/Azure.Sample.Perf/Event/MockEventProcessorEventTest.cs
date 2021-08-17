// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessorEventTest : EventPerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        public MockEventProcessorEventTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond,
                options.ErrorAfterSeconds.HasValue ? TimeSpan.FromSeconds(options.ErrorAfterSeconds.Value) : null);

            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
            _eventProcessor.ProcessErrorAsync += ProcessErrorAsync;
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            EventRaised();
            return Task.CompletedTask;
        }

        private Task ProcessErrorAsync(MockErrorEventArgs arg)
        {
            ErrorRaised(arg.Exception);
            return Task.CompletedTask;
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
        }
    }
}
