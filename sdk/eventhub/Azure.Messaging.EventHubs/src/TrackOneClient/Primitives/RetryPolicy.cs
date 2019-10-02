// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using TrackOne.Primitives;

namespace TrackOne
{
    /// <summary>
    /// Represents an abstraction for retrying messaging operations. Users should not
    /// implement this class, and instead should use one of the provided implementations.
    /// </summary>
    internal abstract class RetryPolicy
    {
        private const int DefaultRetryMaxCount = 10;
        private static readonly TimeSpan s_defaultRetryMinBackoff = TimeSpan.Zero;
        private static readonly TimeSpan s_defaultRetryMaxBackoff = TimeSpan.FromSeconds(30);
        private readonly object _serverBusySync = new object();

        /// <summary>
        /// Determines whether or not the exception can be retried.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>A bool indicating whether or not the operation can be retried.</returns>
        public static bool IsRetryableException(Exception exception)
        {
            Guard.ArgumentNotNull(nameof(exception), exception);

            if (exception is EventHubsException)
            {
                return ((EventHubsException)exception).IsTransient;
            }

            if (exception is TaskCanceledException)
            {
                return exception.InnerException == null || IsRetryableException(exception.InnerException);
            }

            // Flatten AggregateException
            if (exception is AggregateException)
            {
                AggregateException fltAggException = (exception as AggregateException).Flatten();
                return fltAggException.InnerException != null && IsRetryableException(fltAggException.InnerException);
            }

            // Other retriable exceptions here.
            if (exception is OperationCanceledException || exception is SocketException)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the default retry policy, <see cref="RetryExponential"/>.
        /// </summary>
        public static RetryPolicy Default => new RetryExponential(s_defaultRetryMinBackoff, s_defaultRetryMaxBackoff, DefaultRetryMaxCount);

        /// <summary>
        /// Returns the default retry policy, <see cref="NoRetry"/>.
        /// </summary>
        public static RetryPolicy NoRetry => new RetryExponential(TimeSpan.Zero, TimeSpan.Zero, 0);

        /// <summary></summary>
        /// <param name="lastException"></param>
        /// <param name="remainingTime"></param>
        /// <param name="baseWaitTime"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        protected abstract TimeSpan? OnGetNextRetryInterval(Exception lastException, TimeSpan remainingTime, int baseWaitTime, int retryCount);

        /// <summary>
        /// Gets the timespan for the next retry operation.
        /// </summary>
        /// <param name="lastException">The last exception that was thrown</param>
        /// <param name="remainingTime">Remaining time for the cumulative timeout</param>
        /// <param name="retryCount">Current retry count</param>
        /// <returns></returns>
        public TimeSpan? GetNextRetryInterval(Exception lastException, TimeSpan remainingTime, int retryCount)
        {
            int baseWaitTime = 0;
            lock (_serverBusySync)
            {
                if (lastException != null &&
                        (lastException is ServerBusyException || (lastException.InnerException != null && lastException.InnerException is ServerBusyException)))
                {
                    baseWaitTime += ClientConstants.ServerBusyBaseSleepTimeInSecs;
                }
            }

            TimeSpan? retryAfter = OnGetNextRetryInterval(lastException, remainingTime, baseWaitTime, retryCount);

            // Don't retry if remaining time isn't enough.
            if (retryAfter == null ||
                remainingTime.TotalSeconds < Math.Max(retryAfter.Value.TotalSeconds, ClientConstants.TimerToleranceInSeconds))
            {
                return null;
            }

            return retryAfter;
        }

        /// <summary>Creates a new copy of the current <see cref="RetryPolicy" /> and clones it into a new instance.</summary>
        /// <returns>A new copy of <see cref="RetryPolicy" />.</returns>
        public abstract RetryPolicy Clone();
    }
}
