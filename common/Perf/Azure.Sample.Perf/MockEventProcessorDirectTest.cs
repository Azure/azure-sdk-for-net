// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class MockEventProcessorDirectTest : PerfTest<PerfOptions>
    {
        private readonly MockEventProcessor _eventProcessor;

        private int _eventsProcessed;
        private TimeSpan _elapsed;

        public MockEventProcessorDirectTest(PerfOptions options) : base(options)
        {
            _eventProcessor = new MockEventProcessor();
            _eventProcessor.ProcessEventAsync += ProcessEventAsync;
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            Interlocked.Increment(ref _eventsProcessed);
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

            await _eventProcessor.StopProcessingAsync();

            sw.Stop();

            _elapsed = sw.Elapsed;
        }

        public override Task CleanupAsync()
        {
            var eventsPerSecond = ((double)_eventsProcessed) / _elapsed.TotalSeconds;

            Console.WriteLine($"Events Processed: {_eventsProcessed:N0}, Elapsed: {_elapsed.TotalSeconds:N3}, " +
                $"Events/Second: {eventsPerSecond:N1}");
            return base.CleanupAsync();
        }
    }
}
