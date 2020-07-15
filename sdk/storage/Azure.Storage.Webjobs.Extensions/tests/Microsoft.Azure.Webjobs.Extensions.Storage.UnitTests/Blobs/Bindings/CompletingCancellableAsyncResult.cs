﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    internal sealed class CompletingCancellableAsyncResult : IAsyncResult, IDisposable
    {
        private readonly AsyncCallback _callback;
        private readonly object _state;

        private bool _canceled;
        private bool _completed;
        private bool _disposed;
        private EventWaitHandle _waitHandle;
        private object _waitHandleLock = new object();

        public CompletingCancellableAsyncResult(AsyncCallback callback, object state)
        {
            _callback = callback;
            _state = state;
        }

        public object AsyncState
        {
            get
            {
                ThrowIfDisposed();
                return _state;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                ThrowIfDisposed();

                // Lazily allocate
                lock (_waitHandleLock)
                {
                    if (_waitHandle == null)
                    {
                        _waitHandle = new ManualResetEvent(initialState: _completed);
                    }
                }

                return _waitHandle;
            }
        }

        public bool Canceled
        {
            get
            {
                ThrowIfDisposed();
                return _canceled;
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                ThrowIfDisposed();
                return false;
            }
        }

        public bool IsCompleted
        {
            get
            {
                ThrowIfDisposed();
                return _completed;
            }
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _canceled = true;
        }

        public void Complete()
        {
            ThrowIfDisposed();

            lock (_waitHandleLock)
            {
                _completed = true;

                if (_waitHandle != null)
                {
                    _waitHandle.Set();
                }
            }

            if (_callback != null)
            {
                _callback.Invoke(this);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                lock (_waitHandleLock)
                {
                    if (_waitHandle != null)
                    {
                        _waitHandle.Dispose();
                    }
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
