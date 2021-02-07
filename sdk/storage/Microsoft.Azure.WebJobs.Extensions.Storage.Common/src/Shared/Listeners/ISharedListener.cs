// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal interface ISharedListener : IDisposable
    {
        void EnsureAllCanceled();

        Task EnsureAllStartedAsync(CancellationToken cancellationToken);

        Task EnsureAllStoppedAsync(CancellationToken cancellationToken);

        void EnsureAllDisposed();
    }
}
