// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrackOne
{
    // Code based on http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266988.aspx

    /// <summary>
    /// Used as an asynchronous semaphore for internal Event Hubs operations.
    /// </summary>
    internal class AsyncLock : IDisposable
    {
        private readonly SemaphoreSlim _asyncSemaphore = new SemaphoreSlim(1);
        private readonly Task<LockRelease> _lockRelease;
        private bool _disposed;

        /// <summary>
        /// Returns a new AsyncLock.
        /// </summary>
        public AsyncLock()
        {
            _lockRelease = Task.FromResult(new LockRelease(this));
        }

        /// <summary>
        /// Sets a lock.
        /// </summary>
        /// <returns>An asynchronous operation</returns>
        public Task<LockRelease> LockAsync()
        {
            return LockAsync(CancellationToken.None);
        }

        /// <summary>
        /// Sets a lock, which allows for cancellation, using a <see cref="CancellationToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> which can be used to cancel the lock</param>
        /// <returns>An asynchronous operation</returns>
        public Task<LockRelease> LockAsync(CancellationToken cancellationToken)
        {
            Task waitTask = _asyncSemaphore.WaitAsync(cancellationToken);
            if (waitTask.IsCompleted)
            {
                // Avoid an allocation in the non-contention case.
                return _lockRelease;
            }

            return waitTask.ContinueWith(
                (_, state) => new LockRelease((AsyncLock)state),
                this,
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Closes and releases any resources associated with the AsyncLock.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _asyncSemaphore.Dispose();
                    (_lockRelease as IDisposable)?.Dispose();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Used coordinate lock releases.
        /// </summary>
        public struct LockRelease : IDisposable
        {
            private readonly AsyncLock _asyncLockRelease;

            internal LockRelease(AsyncLock release)
            {
                _asyncLockRelease = release;
            }

            /// <summary>
            /// Closes and releases resources associated with <see cref="LockRelease"/>.
            /// </summary>
            public void Dispose()
            {
                _asyncLockRelease?._asyncSemaphore.Release();
            }
        }
    }
}
