// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Provides extension methods for <see cref="SemaphoreSlim"/> to support automatic release patterns.
    /// </summary>
    internal static class SemaphoreSlimExtensions
    {
        /// <summary>
        /// Waits asynchronously for the semaphore and returns a disposable that releases it when disposed.
        /// </summary>
        /// <param name="semaphore">The semaphore to wait on.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous wait operation. The task result is a disposable that releases the semaphore.</returns>
        public static async Task<IDisposable> AutoReleaseWaitAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            return new SemaphoreReleaser(semaphore);
        }

        /// <summary>
        /// Waits for the semaphore and returns a disposable that releases it when disposed.
        /// </summary>
        /// <param name="semaphore">The semaphore to wait on.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A disposable that releases the semaphore.</returns>
        public static IDisposable AutoReleaseWait(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
        {
            semaphore.Wait(cancellationToken);
            return new SemaphoreReleaser(semaphore);
        }

        private sealed class SemaphoreReleaser : IDisposable
        {
            private readonly SemaphoreSlim _semaphore;
            private bool _disposed;

            public SemaphoreReleaser(SemaphoreSlim semaphore)
            {
                _semaphore = semaphore ?? throw new ArgumentNullException(nameof(semaphore));
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _semaphore.Release();
                    _disposed = true;
                }
            }
        }
    }
}