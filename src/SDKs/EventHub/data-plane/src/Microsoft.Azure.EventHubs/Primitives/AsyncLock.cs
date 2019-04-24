// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    // Code based on http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266988.aspx

    /// <summary>
    /// Used as an asynchronous semaphore for internal Event Hubs operations.
    /// </summary>
    public class AsyncLock : IDisposable
    {
        readonly SemaphoreSlim asyncSemaphore = new SemaphoreSlim(1);
        readonly Task<LockRelease> lockRelease;
        bool disposed;

        /// <summary>
        /// Returns a new AsyncLock.
        /// </summary>
        public AsyncLock()
        {
            lockRelease = Task.FromResult(new LockRelease(this));
        }

        /// <summary>
        /// Sets a lock.
        /// </summary>
        /// <returns>An asynchronous operation</returns>
        public Task<LockRelease> LockAsync()
        {
            return this.LockAsync(CancellationToken.None);
        }

        /// <summary>
        /// Sets a lock, which allows for cancellation, using a <see cref="CancellationToken"/>.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> which can be used to cancel the lock</param>
        /// <returns>An asynchronous operation</returns>
        public Task<LockRelease> LockAsync(CancellationToken cancellationToken)
        {
            var waitTask = asyncSemaphore.WaitAsync(cancellationToken);
            if (waitTask.IsCompleted)
            {
                // Avoid an allocation in the non-contention case.
                return lockRelease;
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
            this.Dispose(true);
        }

        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.asyncSemaphore.Dispose();
                    (this.lockRelease as IDisposable)?.Dispose();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Used coordinate lock releases.
        /// </summary>
        public struct LockRelease : IDisposable
        {
            readonly AsyncLock asyncLockRelease;

            internal LockRelease(AsyncLock release)
            {
                this.asyncLockRelease = release;
            }

            /// <summary>
            /// Closes and releases resources associated with <see cref="LockRelease"/>.
            /// </summary>
            /// <returns>An asynchronous operation</returns>
            public void Dispose()
            {
                asyncLockRelease?.asyncSemaphore.Release();
            }
        }
    }
}
