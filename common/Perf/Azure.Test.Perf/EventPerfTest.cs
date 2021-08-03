// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class EventPerfTest<TOptions> : IPerfTest where TOptions : PerfOptions
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        protected TOptions Options { get; private set; }

        private int _completedOperations;
        public int CompletedOperations
        {
            get
            {
                return _completedOperations;
            }
            set
            {
                Interlocked.Exchange(ref _completedOperations, value);
            }
        }

        public TimeSpan LastCompletionTime { get; set; }

        public EventPerfTest(TOptions options)
        {
            Options = options;
        }

        public virtual Task GlobalSetupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        protected void EventRaised()
        {
            Interlocked.Increment(ref _completedOperations);
            LastCompletionTime = _stopwatch.Elapsed;
        }

        public void RunAll(CancellationToken cancellationToken)
        {
            _stopwatch.Restart();
            Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken).Wait();
        }

        public Task RunAllAsync(CancellationToken cancellationToken)
        {
            _stopwatch.Restart();
            return Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        public virtual Task CleanupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task GlobalCleanupAsync()
        {
            return Task.CompletedTask;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
        }

        public virtual ValueTask DisposeAsyncCore()
        {
            return default;
        }

        protected static string GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Undefined environment variable {name}");
            }
            return value;
        }

        public Task RecordAndStartPlayback()
        {
            throw new NotImplementedException();
        }

        public Task StopPlayback()
        {
            throw new NotImplementedException();
        }
    }
}
