// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessorEventYieldTest : EventYieldPerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        public MockEventProcessorEventYieldTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond);
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            EventRaisedAsync();
            return Task.CompletedTask;
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
        }
    }
}
