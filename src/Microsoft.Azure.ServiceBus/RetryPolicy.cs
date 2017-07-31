// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    /// <summary>
    /// Represents an abstraction for retrying messaging operations. Users should not 
    /// implement this class, and instead should use one of the provided implementations.
    /// </summary>
    public abstract class RetryPolicy
    {
        internal static readonly TimeSpan ServerBusyBaseSleepTime = TimeSpan.FromSeconds(10);

        const int DefaultRetryMaxCount = 5;
        static readonly TimeSpan DefaultRetryMinBackoff = TimeSpan.Zero;
        static readonly TimeSpan DefaultRetryMaxBackoff = TimeSpan.FromSeconds(30);

        readonly object serverBusyLock = new object();
        Timer serverBusyResetTimer;

        // This is a volatile copy of IsServerBusy. IsServerBusy is synchronized with a lock, whereas encounteredServerBusy is kept volatile for performance reasons.
        volatile bool encounteredServerBusy;

        /// <summary></summary>
        protected RetryPolicy()
        {
            this.serverBusyResetTimer = new Timer(OnTimerCallback, this, TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        /// Returns the default retry policy, <see cref="RetryExponential"/>.
        /// </summary>
        public static RetryPolicy Default => new RetryExponential(DefaultRetryMinBackoff, DefaultRetryMaxBackoff, DefaultRetryMaxCount);

        /// <summary>
        /// Determines whether or not the server returned a busy error.
        /// </summary>
        public bool IsServerBusy { get; protected set; }

        /// <summary>
        /// Gets the exception message when a server busy error is returned.
        /// </summary>
        public string ServerBusyExceptionMessage { get; protected set; }

        /// <summary>
        /// Runs a <see cref="Func{T, TResult}"/>, using the current RetryPolicy.
        /// </summary>
        /// <param name="operation">A <see cref="Func{T, TResult}"/> to be executed.</param>
        /// <param name="operationTimeout">The timeout for the entire operation.</param>
        /// <returns></returns>
        public async Task RunOperation(Func<Task> operation, TimeSpan operationTimeout)
        {
            int currentRetryCount = 0;
            List<Exception> exceptions = null;
            TimeoutHelper timeoutHelper = new TimeoutHelper(operationTimeout);

            if (this.IsServerBusy && timeoutHelper.RemainingTime() < RetryPolicy.ServerBusyBaseSleepTime)
            {
                // We are in a server busy state before we start processing.
                // Since ServerBusyBaseSleepTime > remaining time for the operation, we don't wait for the entire Sleep time.
                await Task.Delay(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                throw new ServerBusyException(this.ServerBusyExceptionMessage);
            }

            while (true)
            {
                if (this.IsServerBusy)
                {
                    await Task.Delay(RetryPolicy.ServerBusyBaseSleepTime).ConfigureAwait(false);
                }

                try
                {
                    await operation().ConfigureAwait(false);

                    // Its a successful operation. Preemptively reset ServerBusy status.
                    this.ResetServerBusy();
                    break;
                }
                catch (Exception exception)
                {
                    TimeSpan retryInterval;
                    currentRetryCount++;
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }
                    exceptions.Add(exception);

                    if (this.ShouldRetry(
                        timeoutHelper.RemainingTime(), currentRetryCount, exception, out retryInterval)
                        && retryInterval < timeoutHelper.RemainingTime())
                    {
                        // Log intermediate exceptions.
                        MessagingEventSource.Log.RunOperationExceptionEncountered(exception);
                        await Task.Delay(retryInterval).ConfigureAwait(false);
                        continue;
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// Determines whether or not the exception can be retried.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>A bool indicating whether or not the operation can be retried.</returns>
        public virtual bool IsRetryableException(Exception exception)
        {
            if (exception == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(exception));
            }

            var serviceBusException = exception as ServiceBusException;
            return serviceBusException?.IsTransient == true;
        }

        internal bool ShouldRetry(TimeSpan remainingTime, int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
        {
            if (lastException == null)
            {
                // there are no exceptions.
                retryInterval = TimeSpan.Zero;
                return false;
            }

            if (lastException is ServerBusyException)
            {
                this.SetServerBusy(lastException.Message);
            }

            if (this.IsRetryableException(lastException))
            {
                return this.OnShouldRetry(remainingTime, currentRetryCount, out retryInterval);
            }

            retryInterval = TimeSpan.Zero;
            return false;
        }

        internal void SetServerBusy(string exceptionMessage)
        {
            // multiple call to this method will not prolong the timer.
            if (this.encounteredServerBusy)
            {
                return;
            }

            lock (this.serverBusyLock)
            {
                if (!this.encounteredServerBusy)
                {
                    this.encounteredServerBusy = true;
                    this.ServerBusyExceptionMessage = string.IsNullOrWhiteSpace(exceptionMessage) ?
                        Resources.DefaultServerBusyException : exceptionMessage;
                    this.IsServerBusy = true;
                    this.serverBusyResetTimer.Change(RetryPolicy.ServerBusyBaseSleepTime, TimeSpan.FromMilliseconds(-1));
                }
            }
        }

        internal void ResetServerBusy()
        {
            if (!this.encounteredServerBusy)
            {
                return;
            }

            lock (this.serverBusyLock)
            {
                if (this.encounteredServerBusy)
                {
                    this.encounteredServerBusy = false;
                    this.ServerBusyExceptionMessage = Resources.DefaultServerBusyException;
                    this.IsServerBusy = false;
                    this.serverBusyResetTimer.Change(TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(-1));
                }
            }
        }

        /// <summary></summary>
        /// <param name="remainingTime"></param>
        /// <param name="currentRetryCount"></param>
        /// <param name="retryInterval"></param>
        /// <returns></returns>
        protected abstract bool OnShouldRetry(TimeSpan remainingTime, int currentRetryCount, out TimeSpan retryInterval);

        static void OnTimerCallback(object state)
        {
            var thisPtr = (RetryPolicy)state;
            thisPtr.ResetServerBusy();
        }
    }
}