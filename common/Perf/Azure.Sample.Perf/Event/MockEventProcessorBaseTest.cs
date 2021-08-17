// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessorBaseTest : PerfTestBase<MockEventProcessorOptions>
    {
        private readonly Stopwatch _stopwatch;
        private readonly MockEventProcessor _eventProcessor;

        private long[] _eventsProcessed;
        public override long CompletedOperations => _eventsProcessed.Sum();

        public override IList<TimeSpan> Latencies => throw new NotImplementedException();
        public override IList<TimeSpan> CorrectedLatencies => throw new NotImplementedException();

        public MockEventProcessorBaseTest(MockEventProcessorOptions options) : base(options)
        {
            _stopwatch = new Stopwatch();

            _eventProcessor = new MockEventProcessor(options.Partitions, options.MaxEventsPerSecond,
                options.ErrorAfterSeconds.HasValue ? TimeSpan.FromSeconds(options.ErrorAfterSeconds.Value) : null);

            _eventProcessor.ProcessEventAsync += ProcessEventAsync;

            _eventsProcessed = new long[options.Partitions];
        }

        private Task ProcessEventAsync(MockEventArgs arg)
        {
            Interlocked.Increment(ref _eventsProcessed[arg.Partition]);
            LastCompletionTime = _stopwatch.Elapsed;

            return Task.CompletedTask;
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _eventProcessor.StartProcessingAsync();
        }

        public override void RunAll(CancellationToken cancellationToken)
        {
            for (var i = 0; i < _eventsProcessed.Length; i++)
            {
                Interlocked.Exchange(ref _eventsProcessed[i], 0);
            }
            LastCompletionTime = default;

            RunAllAsync(cancellationToken).Wait();
        }

        public override async Task RunAllAsync(CancellationToken cancellationToken)
        {
            for (var i = 0; i < _eventsProcessed.Length; i++)
            {
                Interlocked.Exchange(ref _eventsProcessed[i], 0);
            }
            LastCompletionTime = default;

            _stopwatch.Restart();

            try
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}
