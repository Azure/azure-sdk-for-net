// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Dispatch;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class ListenerFactoryListener : IListener
    {
        private readonly IListenerFactory _factory;
        private readonly SharedQueueHandler _sharedQueue;
        private readonly CancellationTokenSource _cancellationSource;

        private IListener _listener;
        private CancellationTokenRegistration _cancellationRegistration;
        private bool _disposed;

        public ListenerFactoryListener(IListenerFactory factory, SharedQueueHandler sharedQueue)
        {
            _factory = factory;
            _sharedQueue = sharedQueue;
            _cancellationSource = new CancellationTokenSource();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_listener != null)
            {
                throw new InvalidOperationException("The listener has already been started.");
            }

            return StartAsyncCore(cancellationToken);
        }

        private async Task StartAsyncCore(CancellationToken cancellationToken)
        {
            // create sharedQueue so that once the listener started, they can enqueue
            await _sharedQueue.InitializeAsync(cancellationToken);
            _listener = await _factory.CreateAsync(cancellationToken);
            _cancellationRegistration = _cancellationSource.Token.Register(_listener.Cancel);
            await _listener.StartAsync(cancellationToken); // composite listener, startAsync in parallel
            // start sharedQueue after other listeners
            await _sharedQueue.StartQueueAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_listener == null)
            {
                throw new InvalidOperationException("The listener has not been started.");
            }

            await _listener.StopAsync(cancellationToken);
            // technically we should stop the SharedQueue after others
            // if we stop SharedQueue before, other listeners cannot write to it
            await _sharedQueue.StopQueueAsync(cancellationToken);
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _cancellationSource.Cancel();
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_cancellationSource")]
        public void Dispose()
        {
            if (!_disposed)
            {
                _cancellationRegistration.Dispose();

                // StartAsync might still be using this cancellation token.
                // Mark it canceled but don't dispose of the source while the callers are running.
                // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
                // For now, rely on finalization to clean up _shutdownTokenSource's wait handle (if allocated).
                _cancellationSource.Cancel();

                if (_listener != null)
                {
                    _listener.Dispose();
                }

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
