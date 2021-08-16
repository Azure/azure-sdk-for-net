// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventPerfTest<TOptions> : PerfTestBase<TOptions> where TOptions : PerfOptions
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private long _completedOperations;
        public sealed override long CompletedOperations => _completedOperations;

        public sealed override IList<TimeSpan> Latencies =>
            throw new InvalidOperationException("EventPerfTest does not support Latencies");

        public sealed override IList<TimeSpan> CorrectedLatencies =>
            throw new InvalidOperationException("EventPerfTest does not support CorrectedLatencies");

        public EventPerfTest(TOptions options) : base(options)
        {
            if (options.Latency)
            {
                throw new InvalidOperationException("EventPerfTest does not support the '--latency' option");
            }

            if (options.Rate.HasValue)
            {
                throw new InvalidOperationException("EventPerfTest does not support the '--rate' option");
            }
        }

        protected void EventRaised()
        {
            Interlocked.Increment(ref _completedOperations);
            LastCompletionTime = _stopwatch.Elapsed;
        }

        public sealed override Task PostSetupAsync()
        {
            return Task.CompletedTask;
        }

        public sealed override void RunAll(CancellationToken cancellationToken)
        {
            // Must restart stopwatch before resetting LastCompletionTime, to avoid a race condition where an
            // event would use the stopwatch from Warmup at the start of Run.  The results of Warmup have already
            // been printed, so the reverse race condition is not a problem.
            _stopwatch.Restart();

            Interlocked.Exchange(ref _completedOperations, 0);
            LastCompletionTime = default;

            Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken).Wait();
        }

        public sealed override Task RunAllAsync(CancellationToken cancellationToken)
        {
            // Must restart stopwatch before resetting LastCompletionTime, to avoid a race condition where an
            // event would use the stopwatch from Warmup at the start of Run.  The results of Warmup have already
            // been printed, so the reverse race condition is not a problem.
            _stopwatch.Restart();

            Interlocked.Exchange(ref _completedOperations, 0);
            LastCompletionTime = default;

            return Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        public sealed override Task PreCleanupAsync()
        {
            return Task.CompletedTask;
        }
    }
}
