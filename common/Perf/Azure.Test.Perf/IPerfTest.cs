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
    internal interface IPerfTest : IDisposable, IAsyncDisposable
    {
        // Total number of operations completed by RunAll()
        // Reset after warmup
        long CompletedOperations { get; }

        // Elapsed time between start of warmup/run and last completed operation
        // Reset after warmup
        TimeSpan LastCompletionTime { get; }

        // Elapsed time between start and end of each completed operation
        // Reset after warmup
        // Only populated if "--latency" option is enabled
        IList<TimeSpan> Latencies { get; }

        // Elapsed time between scheduled start and actual end of each completed operation
        // Reset after warmup
        // Only populated if both "--latency" and "--rate" options are enabled
        IList<TimeSpan> CorrectedLatencies { get; }

        // Channel containing the scheduled start time of each operation
        // Also includes a Stopwatch measuring elapsed time since scheduled start
        Channel<(TimeSpan Start, Stopwatch Stopwatch)> PendingOperations { get; set; }

        // Setup called once across all parallel test instances
        // Used to setup state that can be used by all test instances
        Task GlobalSetupAsync();

        // Setup called once per parallel test instance
        // Used to setup state specific to this test instance
        Task SetupAsync();

        // Post-setup called once per parallel test instance
        // Used by base classes to setup state (like test-proxy) after all derived class setup is complete
        Task PostSetupAsync();

        // Run all sync tests, including both warmup and duration
        void RunAll(CancellationToken cancellationToken);

        // Run all async tests, including both warmup and duration
        Task RunAllAsync(CancellationToken cancellationToken);

        // Pre-cleanup called once per parallel test instance
        // Used by base classes to cleanup state (like test-proxy) before all derived class cleanup runs
        Task PreCleanupAsync();

        // Cleanup called once per parallel test instance
        // Used to setup state specific to this test instance
        Task CleanupAsync();

        // Cleanup called once across all parallel test instances
        // Used to cleanup state that can be used by all test instances
        Task GlobalCleanupAsync();
    }
}
