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
        void Run(CancellationToken cancellationToken);
        Task RunAsync(CancellationToken cancellationToken);
        Task CleanupAsync();
        Task GlobalCleanupAsync();
    }
}
