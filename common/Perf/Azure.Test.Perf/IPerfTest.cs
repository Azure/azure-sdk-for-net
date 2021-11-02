// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    internal interface IPerfTest : IDisposable, IAsyncDisposable
    {
        Task GlobalSetupAsync();
        Task SetupAsync();
        Task RecordAndStartPlayback();
        void Run(CancellationToken cancellationToken);
        Task RunAsync(CancellationToken cancellationToken);
        Task StopPlayback();
        Task CleanupAsync();
        Task GlobalCleanupAsync();
    }
}
