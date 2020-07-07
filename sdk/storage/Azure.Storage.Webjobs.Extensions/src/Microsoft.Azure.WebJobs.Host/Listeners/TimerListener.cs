// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal sealed class TimerListener : IListener
    {
        private readonly ITaskSeriesTimer _timer;

        private bool _disposed;

        public TimerListener(ITaskSeriesTimer timer)
        {
            _timer = timer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            _timer.Start();
            return Task.FromResult(0);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            return _timer.StopAsync(cancellationToken);
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _timer.Cancel();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _timer.Dispose();
                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }
    }
}
