// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventPerfTest<TOptions> : PerfTestBase<TOptions> where TOptions : PerfOptionsBase
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private long _completedOperations;
        public override long CompletedOperations => _completedOperations;

        public EventPerfTest(TOptions options) : base(options)
        {
        }

        protected void EventRaised()
        {
            Interlocked.Increment(ref _completedOperations);
            LastCompletionTime = _stopwatch.Elapsed;
        }

        public override void Reset()
        {
            Interlocked.Exchange(ref _completedOperations, 0);
            LastCompletionTime = default;
        }

        public override void RunAll(CancellationToken cancellationToken)
        {
            _stopwatch.Restart();
            Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken).Wait();
        }

        public override Task RunAllAsync(CancellationToken cancellationToken)
        {
            _stopwatch.Restart();
            return Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }
    }
}
