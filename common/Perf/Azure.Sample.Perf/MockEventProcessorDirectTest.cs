// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessorDirectTest : PerfTest<MockEventProcessorOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        private readonly int[] _eventsProcessed;
        private TimeSpan _elapsed;

        public MockEventProcessorDirectTest(MockEventProcessorOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond);
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;

            _eventsProcessed = new int[options.Partitions];
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            _eventsProcessed[arg.Partition]++;

            return Task.CompletedTask;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();

            await _eventProcessor.StartProcessingAsync();

            try
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }

            _eventProcessor.ProcessEventAsync -= ProcessEventAsync;
            sw.Stop();

            _elapsed = sw.Elapsed;
        }

        public override Task CleanupAsync()
        {
            var eventsPerSecond = ((double)_eventsProcessed.Sum()) / _elapsed.TotalSeconds;

            Console.WriteLine($"Events Processed: {_eventsProcessed.Sum():N0}, Elapsed: {_elapsed.TotalSeconds:N3}, " +
                $"Events/Second: {eventsPerSecond:N1}");
            return base.CleanupAsync();
        }
    }
}
