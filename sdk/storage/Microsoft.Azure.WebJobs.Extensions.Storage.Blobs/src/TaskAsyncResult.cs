// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal sealed class TaskAsyncResult : IAsyncResult, IDisposable
    {
        private readonly Task _task;
        private readonly object _state;
        private readonly bool _completedSynchronously;
        private readonly AsyncCallback _callback;

        private bool _disposed;

        public TaskAsyncResult(Task task, AsyncCallback callback, object state)
        {
            _task = task;
            _state = state;
            _completedSynchronously = _task.IsCompleted;

            if (callback != null)
            {
                _callback = callback;

                // Because ContinueWith/ExecuteSynchronously will run immediately for a completed task, ensure this is
                // the last line of the constructor (all other state should be initialized before invoking the
                // callback).
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
                _ = _task.ContinueWith(InvokeCallback, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
            }
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
                return ((IAsyncResult)_task).AsyncWaitHandle;
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                ThrowIfDisposed();
                return _completedSynchronously;
            }
        }

        public bool IsCompleted
        {
            get
            {
                ThrowIfDisposed();
                return _task.IsCompleted;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _task.Dispose();

                _disposed = true;
            }
        }

        public void End()
        {
            ThrowIfDisposed();
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            _task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void InvokeCallback(Task ignore)
        {
            Debug.Assert(_callback != null);
            _callback.Invoke(this);
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
