// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    internal interface IPerfTest : IDisposable, IAsyncDisposable
    {
        int CompletedOperations { get; set; }
        TimeSpan LastCompletionTime { get; set; }

        Task GlobalSetupAsync();
        Task SetupAsync();
        Task RecordAndStartPlayback();
        void RunAll(CancellationToken cancellationToken);
        Task RunAllAsync(CancellationToken cancellationToken);
        Task StopPlayback();
        Task CleanupAsync();
        Task GlobalCleanupAsync();
    }
}
