// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure
{
    public abstract class LongRunningOperation<T>: IDisposable
    {
        public abstract Response Raw { get; }
        public abstract ValueTask<Response<T>> GetValueAsync(CancellationToken cancellationToken = default);
        public abstract Response<T> GetValue(CancellationToken cancellationToken = default);

        public abstract ValueTask<Response<LongRunningOperationStatus>> GetStatusAsync(CancellationToken cancellationToken = default);
        public abstract Response<LongRunningOperationStatus> GetStatus(CancellationToken cancellationToken = default);

        public abstract ValueTask<Response> CancelAsync(CancellationToken cancellationToken = default);
        public abstract Response Cancel(CancellationToken cancellationToken = default);
        public abstract void Dispose();
    }
}
