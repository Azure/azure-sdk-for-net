// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal sealed class CompositeListener : IListener, IEnumerable<IListener>
    {
        private readonly IEnumerable<IListener> _listeners;

        private bool _disposed;

        public CompositeListener(params IListener[] listeners)
            : this((IEnumerable<IListener>)listeners)
        {
        }

        public CompositeListener(IEnumerable<IListener> listeners)
        {
            _listeners = listeners;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            // start all listeners in parallel
            List<Task> tasks = new List<Task>();
            foreach (IListener listener in _listeners)
            {
                tasks.Add(listener.StartAsync(cancellationToken));
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            // stop all listeners in parallel
            List<Task> tasks = new List<Task>();
            foreach (IListener listener in _listeners)
            {
                tasks.Add(listener.StopAsync(cancellationToken));
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        public void Cancel()
        {
            ThrowIfDisposed();

            foreach (IListener listener in _listeners)
            {
                listener.Cancel();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                foreach (IListener listener in _listeners)
                {
                    listener.Dispose();
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

        public IEnumerator<IListener> GetEnumerator()
        {
            return _listeners.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IListener>)this).GetEnumerator();
        }
    }
}
