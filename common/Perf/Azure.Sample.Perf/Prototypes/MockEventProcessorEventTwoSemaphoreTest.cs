// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessorEventTwoSemaphoreTest : EventTwoSemaphorePerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        public MockEventProcessorEventTwoSemaphoreTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond);
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
        }

        private async Task ProcessEventAsync(MockEventArgs arg)
        {
            await EventRaisedAsync();
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
        }
    }
}
