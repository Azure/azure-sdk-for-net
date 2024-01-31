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

        private Exception _error;
        private CancellationTokenSource _errorCancellationTokenSource = new CancellationTokenSource();

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

        protected void ErrorRaised(Exception e)
        {
            _error = e;
            _errorCancellationTokenSource.Cancel();
        }

        public sealed override Task PostSetupAsync()
        {
            return Task.CompletedTask;
        }

        public sealed override void RunAll(CancellationToken cancellationToken)
        {
            RunAllAsync(cancellationToken).Wait();
        }

        public sealed override async Task RunAllAsync(CancellationToken cancellationToken)
        {
            // Must restart stopwatch before resetting LastCompletionTime, to avoid a race condition where an
            // event would use the stopwatch from Warmup at the start of Run.  The results of Warmup have already
            // been printed, so the reverse race condition is not a problem.
            _stopwatch.Restart();

            Interlocked.Exchange(ref _completedOperations, 0);
            LastCompletionTime = default;

            // Cancel when requested by perf framework or when ErrorRaised() is called
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _errorCancellationTokenSource.Token))
            {
                try
                {
                    await Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
                }
                catch (TaskCanceledException)
                {
                    if (_error != null)
                    {
                        throw _error;
                    }
                }
            }
        }

        public sealed override Task PreCleanupAsync()
        {
            return Task.CompletedTask;
        }

        // https://learn.microsoft.com/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _errorCancellationTokenSource?.Dispose();
            }
            _errorCancellationTokenSource = null;

            base.Dispose(disposing);
        }

        public override async ValueTask DisposeAsyncCore()
        {
            if (_errorCancellationTokenSource is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                _errorCancellationTokenSource?.Dispose();
            }
            _errorCancellationTokenSource = null;

            await base.DisposeAsyncCore();
        }
    }
}
