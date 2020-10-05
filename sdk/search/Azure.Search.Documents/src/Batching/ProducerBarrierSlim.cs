// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// While most writers of a Channel only want to push work and return,
    /// occasionally we'll have writers like Flush that want to block until
    /// the reader does something with that work.  ProducerBarrierSlim allows
    /// them to wait and be released after the work has completed.
    /// </summary>
    internal class ProducerBarrierSlim : IDisposable
    {
        /// <summary>
        /// Semaphore to enforce the barrier.
        /// </summary>
        private SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        /// <summary>
        /// The number of tasks waiting on the submission semaphore.  This
        /// determines how many times we release the semaphore.
        /// </summary>
        internal volatile int _waiters = 0;

        /// <summary>
        /// Wait for the barrier to be lifted.
        /// </summary>
        /// <param name="async">Whether to call sync or async.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A Task that will wait until the barrier is lifted.
        /// </returns>
        public async Task WaitAsync(bool async, CancellationToken cancellationToken)
        {
            if (_semaphore == null)
            {
                throw new ObjectDisposedException(nameof(ProducerBarrierSlim));
            }

            Interlocked.Increment(ref _waiters);
            try
            {
                if (async)
                {
                    await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _semaphore.Wait(cancellationToken);
                }
            }
            finally
            {
                Interlocked.Decrement(ref _waiters);
            }
        }

        /// <summary>
        /// Lift the barrier.
        /// </summary>
        public void Release()
        {
            if (_semaphore == null)
            {
                throw new ObjectDisposedException(nameof(ProducerBarrierSlim));
            }

            // Wake up anyone who was blocked on a flush finishing
            int waiting;
            while ((waiting = _waiters) > 0)
            {
                _semaphore.Release(waiting);
            }
        }

        /// <summary>
        /// Dispose the barrier.
        /// </summary>
        public void Dispose()
        {
            Debug.Assert(
                _waiters == 0,
                $"{nameof(ProducerBarrierSlim)} disposed with tasks still waiting!  Somebody didn't call {nameof(Release)}.");

            _semaphore?.Dispose();
            _semaphore = null;
        }
    }
}
