// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessorEventTest : EventPerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        public MockEventProcessorEventTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond);
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            EventRaised();
            return Task.CompletedTask;
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
        }
    }
}
