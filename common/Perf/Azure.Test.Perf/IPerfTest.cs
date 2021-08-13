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
        long CompletedOperations { get; }
        TimeSpan LastCompletionTime { get; }

        IList<TimeSpan> Latencies { get; }

        IList<TimeSpan> CorrectedLatencies { get; }
        Channel<(TimeSpan Start, Stopwatch Stopwatch)> PendingOperations { get; set; }

        Task GlobalSetupAsync();
        Task SetupAsync();
        Task PostSetupAsync();
        void RunAll(CancellationToken cancellationToken);
        Task RunAllAsync(CancellationToken cancellationToken);
        Task PreCleanupAsync();
        Task CleanupAsync();
        Task GlobalCleanupAsync();
    }
}
