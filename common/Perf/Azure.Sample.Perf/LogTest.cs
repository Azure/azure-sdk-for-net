// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    // Used for logging every step and property of the perf test
    public class LogTest : PerfTest<PerfOptions>
    {
        private static readonly Stopwatch _elapsed = Stopwatch.StartNew();

        private static int _globalCompletedOperations = 0;
        private int _completedOperations = 0;

        private TimeSpan Delay => TimeSpan.FromSeconds(1.0 / (ParallelIndex + 1));

        public LogTest(PerfOptions options) : base(options)
        {
            Log("LogTest()");
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            Log("GlobalSetupAsync()");
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            Log("SetupAsync()");
        }

        public override void Run(CancellationToken cancellationToken)
        {
            Thread.Sleep(Delay);

            _completedOperations++;
            Interlocked.Increment(ref _globalCompletedOperations);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(Delay);

            _completedOperations++;
            Interlocked.Increment(ref _globalCompletedOperations);
        }

        public override async Task CleanupAsync()
        {
            await base.CleanupAsync();
            Log($"CleanupAsync() - Completed Operations: {_completedOperations}");
        }

        public override async Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();
            Log($"GlobalCleanupAsync() - Global Completed Operations: {_globalCompletedOperations}");
        }

        public override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Log($"Dispose(disposing: {disposing})");
        }

        public override async ValueTask DisposeAsyncCore()
        {
            await base.DisposeAsyncCore();
            Log("DisposeAsyncCore()");
        }

        private void Log(string message)
        {
            Console.WriteLine($"[{_elapsed.Elapsed.TotalSeconds:F3}] [{ParallelIndex}] {message}");
        }
    }
}
