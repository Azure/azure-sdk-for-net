// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.PerfStress;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Stress
{
    public abstract class StressTest<TOptions, TMetrics> : IStressTest where TOptions : StressOptions where TMetrics : StressMetrics
    {
        protected TOptions Options { get; private set; }
        protected TMetrics Metrics { get; private set; }

        // Convenient source of randomness for base classes
        protected Random Random { get; } = new Random();

        public StressTest(TOptions options, TMetrics metrics)
        {
            Options = options;
            Metrics = metrics;
        }

        public virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        public abstract Task RunAsync(CancellationToken cancellationToken);

        public virtual Task CleanupAsync()
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

        // Helpers
        protected static bool ContainsOperationCanceledException(Exception e) => PerfStressUtilities.ContainsOperationCanceledException(e);

        protected static Task DelayUntil(Func<bool> predicate, CancellationToken token = default) => DelayUntil(predicate, TimeSpan.FromMilliseconds(50), token);

        protected static async Task DelayUntil(Func<bool> predicate, TimeSpan interval, CancellationToken token = default)
        {
            while (!predicate())
            {
                await Task.Delay(interval, token);
            }
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
