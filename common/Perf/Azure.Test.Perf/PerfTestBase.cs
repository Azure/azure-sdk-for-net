// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public abstract class PerfTestBase<TOptions> : IPerfTest where TOptions : PerfOptions
    {
        protected TOptions Options { get; private set; }

        private static int _globalParallelIndex;
        protected int ParallelIndex { get; }

        public abstract long CompletedOperations { get; }
        public TimeSpan LastCompletionTime { get; set; }

        public abstract IList<TimeSpan> Latencies { get; }

        public abstract IList<TimeSpan> CorrectedLatencies { get; }
        public Channel<(TimeSpan Start, Stopwatch Stopwatch)> PendingOperations { get; set; }

        public PerfTestBase(TOptions options)
        {
            Options = options;
            ParallelIndex = Interlocked.Increment(ref _globalParallelIndex) - 1;
        }

        public virtual Task GlobalSetupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task PostSetupAsync()
        {
            return Task.CompletedTask;
        }

        public abstract void RunAll(CancellationToken cancellationToken);

        public abstract Task RunAllAsync(CancellationToken cancellationToken);

        public virtual Task PreCleanupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task CleanupAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task GlobalCleanupAsync()
        {
            return Task.CompletedTask;
        }

        // https://learn.microsoft.com/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns
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
    }
}
