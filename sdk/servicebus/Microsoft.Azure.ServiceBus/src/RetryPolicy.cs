﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Transactions;
    using Primitives;

    /// <summary>
    /// Represents an abstraction for retrying messaging operations. Users should not
    /// implement this class, and instead should use one of the provided implementations.
    /// <remarks>RetryPolicy will not be applied when an ambient transaction is found.</remarks>
    /// </summary>
    public abstract class RetryPolicy
    {
        internal static readonly TimeSpan ServerBusyBaseSleepTime = TimeSpan.FromSeconds(10);

        private const int DefaultRetryMaxCount = 5;
        private static readonly TimeSpan DefaultRetryMinBackoff = TimeSpan.Zero;
        private static readonly TimeSpan DefaultRetryMaxBackoff = TimeSpan.FromSeconds(30);

        private readonly object serverBusyLock = new object();

        // This is a volatile copy of IsServerBusy. IsServerBusy is synchronized with a lock, whereas encounteredServerBusy is kept volatile for performance reasons.
        private volatile bool encounteredServerBusy;

        protected RetryPolicy()
        {
        }

        /// <summary>
        /// Returns the default retry policy, <see cref="RetryExponential"/>.
        /// </summary>
        public static RetryPolicy Default => new RetryExponential(DefaultRetryMinBackoff, DefaultRetryMaxBackoff, DefaultRetryMaxCount);

        /// <summary>
        /// Returns a <see cref="NoRetry"/> retry policy.
        /// </summary>
        public static RetryPolicy NoRetry => new NoRetry();

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
        public async Task RunOperation(Func<Task> operation, TimeSpan operationTimeout)
        {
            var currentRetryCount = 0;
            List<Exception> exceptions = null;
            var timeoutHelper = new TimeoutHelper(operationTimeout, true);

            if (IsServerBusy && timeoutHelper.RemainingTime() < ServerBusyBaseSleepTime)
            {
                // We are in a server busy state before we start processing.
                // Since ServerBusyBaseSleepTime > remaining time for the operation, we don't wait for the entire Sleep time.
                await Task.Delay(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                throw new ServerBusyException(ServerBusyExceptionMessage);
            }

            while (true)
            {
                if (IsServerBusy)
                {
                    await Task.Delay(ServerBusyBaseSleepTime).ConfigureAwait(false);
                }

                try
                {
                    await operation().ConfigureAwait(false);

                    // Its a successful operation. Preemptively reset ServerBusy status.
                    ResetServerBusy();
                    break;
                }
                catch (Exception exception)
                {
                    currentRetryCount++;
                    if (exceptions == null)
                    {
                        exceptions = new List<Exception>();
                    }
                    exceptions.Add(exception);

                    if (ShouldRetry(
                        timeoutHelper.RemainingTime(), currentRetryCount, exception, out var retryInterval)
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
            // There is no exception information or there's there's an ambient transaction - should not retry
            if (lastException == null || Transaction.Current != null)
            {
                retryInterval = TimeSpan.Zero;
                return false;
            }

            if (lastException is ServerBusyException)
            {
                SetServerBusy(lastException.Message);
            }

            if (IsRetryableException(lastException))
            {
                return OnShouldRetry(remainingTime, currentRetryCount, out retryInterval);
            }

            retryInterval = TimeSpan.Zero;
            return false;
        }

        internal void SetServerBusy(string exceptionMessage)
        {
            // multiple call to this method will not prolong the timer.
            if (encounteredServerBusy)
            {
                return;
            }

            lock (serverBusyLock)
            {
                if (!encounteredServerBusy)
                {
                    encounteredServerBusy = true;
                    ServerBusyExceptionMessage = string.IsNullOrWhiteSpace(exceptionMessage) ?
                        Resources.DefaultServerBusyException : exceptionMessage;
                    IsServerBusy = true;
                    TaskExtensionHelper.Schedule(ScheduleResetServerBusy);
                }
            }
        }

        internal void ResetServerBusy()
        {
            if (!encounteredServerBusy)
            {
                return;
            }

            lock (serverBusyLock)
            {
                if (encounteredServerBusy)
                {
                    encounteredServerBusy = false;
                    ServerBusyExceptionMessage = Resources.DefaultServerBusyException;
                    IsServerBusy = false;
                }
            }
        }

        protected abstract bool OnShouldRetry(TimeSpan remainingTime, int currentRetryCount, out TimeSpan retryInterval);

        private async Task ScheduleResetServerBusy()
        {
            await Task.Delay(ServerBusyBaseSleepTime).ConfigureAwait(false);
            ResetServerBusy();
        }
    }
}