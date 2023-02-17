// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal sealed class SharedBlobQueueListener : ISharedListener, IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly IListener _listener;
        private readonly BlobQueueTriggerExecutor _executor;

        private bool _started;
        private bool _disposed;

        public SharedBlobQueueListener(IListener listener, BlobQueueTriggerExecutor executor)
        {
            _listener = listener;
            _executor = executor;
        }

        public void Register(string functionId, BlobQueueRegistration registration)
        {
            if (_started)
            {
                throw new InvalidOperationException("Registrations may not be added while the shared listener is running.");
            }

            _executor.Register(functionId, registration);
        }

        public async Task EnsureAllStartedAsync(CancellationToken cancellationToken)
        {
            if (!_started)
            {
                await _listener.StartAsync(cancellationToken).ConfigureAwait(false);
                _started = true;
            }
        }

        public async Task EnsureAllStoppedAsync(CancellationToken cancellationToken)
        {
            if (_started)
            {
                await _listener.StopAsync(cancellationToken).ConfigureAwait(false);
                _started = false;
            }
        }

        public void EnsureAllCanceled()
        {
            _listener.Cancel();
        }

        public void EnsureAllDisposed()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _listener.Dispose();
                _disposed = true;
            }
        }

        public IScaleMonitor GetMonitor()
        {
            return ((IScaleMonitorProvider)_listener).GetMonitor();
        }

        public ITargetScaler GetTargetScaler()
        {
            return ((ITargetScalerProvider)_listener).GetTargetScaler();
        }
    }
}
