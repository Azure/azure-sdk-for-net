// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    // Code based on http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266988.aspx
    public class AsyncLock : IDisposable
    {
        readonly SemaphoreSlim asyncSemaphore;
        readonly Task<LockRelease> lockRelease;
        bool disposed = false;

        public AsyncLock()
        {
            asyncSemaphore = new SemaphoreSlim(1);
            lockRelease = Task.FromResult(new LockRelease(this));
        }

        public Task<LockRelease> LockAsync()
        {
            return this.LockAsync(CancellationToken.None);
        }

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

        public struct LockRelease : IDisposable
        {
            readonly AsyncLock asyncLockRelease;
            bool disposed;

            internal LockRelease(AsyncLock release)
            {
                this.asyncLockRelease = release;
                this.disposed = false;
            }

            public void Dispose()
            {
                Dispose(true);
            }

            void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        asyncLockRelease?.asyncSemaphore.Release();
                    }

                    this.disposed = true;
                }
            }
        }
    }
}
