// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal interface ISharedListener : IDisposable
    {
        void EnsureAllCanceled();

        Task EnsureAllStartedAsync(CancellationToken cancellationToken);

        Task EnsureAllStoppedAsync(CancellationToken cancellationToken);

        void EnsureAllDisposed();
    }
}
