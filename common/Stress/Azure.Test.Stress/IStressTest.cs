// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Stress
{
    internal interface IStressTest : IDisposable, IAsyncDisposable
    {
        Task SetupAsync();
        Task RunAsync(CancellationToken cancellationToken);
        Task CleanupAsync();
    }
}
