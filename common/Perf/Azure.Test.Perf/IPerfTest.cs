// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    internal interface IPerfTest : IDisposable, IAsyncDisposable
    {
        long CompletedOperations { get; }
        TimeSpan LastCompletionTime { get; }

        Task GlobalSetupAsync();
        Task SetupAsync();
        Task PostSetupAsync();
        void Reset();
        void RunAll(CancellationToken cancellationToken);
        Task RunAllAsync(CancellationToken cancellationToken);
        Task PreCleanupAsync();
        Task CleanupAsync();
        Task GlobalCleanupAsync();
    }
}
