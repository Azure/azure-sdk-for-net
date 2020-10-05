// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// InitializationBarrierSlim allows for synchronized lazy initialization.  An
    /// AsyncLazy wouldn't work in these circumstances because we need the
    /// results of the initialization before anyone else can proceed.
    /// </summary>
    internal class InitializationBarrierSlim : IDisposable
    {
        /// <summary>
        /// Flag indicating whether we've entered the barrier once yet.
        /// </summary>
        private volatile bool _entered = false;

        /// <summary>
        /// Synchronize entry to the barrier.  The first to arrive is allowed
        /// through and everyone else waits for us to finish.
        /// </summary>
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        /// <summary>
        /// Try to enter the barrier.  Only the first caller will be allowed
        /// through and everyone else will wait until it's finished.  If this
        /// returns <see langword="true"/> then you need to call
        /// <see cref="Release"/>.  (Do not call <see cref="Release"/> if you
        /// did not enter the barrier!)
        /// </summary>
        /// <param name="async">Whether to invoke sync or async.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A Task that will either allow you to enter or wait until whoever
        /// made it through has already completed.
        /// </returns>
        public async Task<bool> TryEnterAsync(bool async, CancellationToken cancellationToken)
        {
            if (_semaphore == null)
            {
                throw new ObjectDisposedException(nameof(InitializationBarrierSlim));
            }

            if (_entered)
            {
                // Short circuit if we've already entered
                return false;
            }
            else if (async)
            {
                await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _semaphore.Wait(cancellationToken);
            }

            // Double check whether we were first or just woke up after waiting
            return !_entered;
        }

        /// <summary>
        /// Allow entry into the barrier for anyone waiting and any future
        /// callers.  This needs to be called whenever TryEnterAsync returned
        /// true.
        /// </summary>
        public void Release()
        {
            if (_semaphore == null)
            {
                throw new ObjectDisposedException(nameof(InitializationBarrierSlim));
            }

            // Unblock anyone else who called this at the same time
            _entered = true;
            _semaphore.Release();
        }

        /// <summary>
        /// Dispose the barrier.
        /// </summary>
        public void Dispose()
        {
            _semaphore?.Dispose();
            _semaphore = null;
        }
    }
}
