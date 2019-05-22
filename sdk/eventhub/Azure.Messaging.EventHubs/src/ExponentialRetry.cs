// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A policy to govern retrying of messaging operations in which the delay between retries will grow in an
    ///   exponential manner, allowing more time to recover as the number of retries increases.
    /// </summary>
    ///
    /// <seealso cref="Retry" />
    ///
    public sealed class ExponentialRetry : Retry
    {
        /// <summary>The minimum time period permissible for backing off between retries.</summary>
        private readonly TimeSpan _minimumBackoff;

        /// <summary>The maximum time period permissible for backing off between retries.</summary>
        private readonly TimeSpan _maximumBackoff;

        /// <summary>The maximum time period permissible for backing off between retries.</summary>
        private readonly int _maximumRetryCount;

        /// <summary>The exponential base for retry interval calculations.</summary>
        private readonly double _retryFactor;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ExponentialRetry"/> class.
        /// </summary>
        ///
        /// <param name="minimumBackoff">The minimum time period permissible for backing off between retries.</param>
        /// <param name="maximumBackoff">The maximum time period permissible for backing off between retries.</param>
        /// <param name="maximumRetryCount">The maximum number of retries allowed.</param>
        ///
        public ExponentialRetry(TimeSpan minimumBackoff,
                                TimeSpan maximumBackoff,
                                int      maximumRetryCount)
        {
            Guard.ArgumentNotNegative(nameof(minimumBackoff), minimumBackoff);
            Guard.ArgumentNotNegative(nameof(maximumBackoff), maximumBackoff);

            _minimumBackoff = minimumBackoff;
            _maximumBackoff = maximumBackoff;
            _maximumRetryCount = maximumRetryCount;
            _retryFactor = ComputeRetryFactor(minimumBackoff, maximumBackoff, maximumRetryCount);
        }

        /// <summary>
        ///   Creates a new copy of the current <see cref="Retry" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="Retry" />.</returns>
        ///
        public override Retry Clone() =>
            new ExponentialRetry(_minimumBackoff, _maximumBackoff, _maximumRetryCount);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Allows a concrete retry policy implementation to offer a base retry interval to be used in
        ///   the calculations performed by <see cref="Retry.GetNextRetryInterval" />.
        /// </summary>
        ///
        /// <param name="lastException">The last exception that was observed for the operation to be retried.</param>
        /// <param name="remainingTime">The amount of time remaining for the cumulative timeout across retry attempts.</param>
        /// <param name="baseWaitSeconds">The number of seconds to base the suggested retry interval on; this should be used as the minimum interval returned under normal circumstances.</param>
        /// <param name="retryCount">The number of retries that have already been attempted.</param>
        ///
        /// <returns>The amount of time to delay before retrying the associated operation; if <c>null</c>, then the operation is no longer eligible to be retried.</returns>
        ///
        /// <remarks>
        ///   The interval produced by this method is considered non-authoritative and is subject to adjustment by the
        ///   <see cref="Retry.GetNextRetryInterval" /> implementation.
        /// </remarks>
        ///
        protected override TimeSpan? OnGetNextRetryInterval(Exception lastException,
                                                            TimeSpan  remainingTime,
                                                            int       baseWaitSeconds,
                                                            int       retryCount)
        {
            if ((!Retry.IsRetriableException(lastException)) || (retryCount >= _maximumRetryCount))
            {
                return null;
            }

            double nextRetryInterval = Math.Pow(_retryFactor, (double)retryCount);
            long nextRetryIntervalSeconds = (long)nextRetryInterval;
            long nextRetryIntervalMilliseconds = (long)((nextRetryInterval - (double)nextRetryIntervalSeconds) * 1000);
            TimeSpan retryAfter = _minimumBackoff.Add(TimeSpan.FromMilliseconds(nextRetryIntervalSeconds * 1000 + nextRetryIntervalMilliseconds));

            return retryAfter.Add(TimeSpan.FromSeconds(baseWaitSeconds));
        }

        /// <summary>
        ///   Computes the base factor to be used in calculating the exponential component of
        ///   the retry interval.
        /// </summary>
        ///
        /// <param name="minimumBackoff">The minimum time period permissible for backing off between retries.</param>
        /// <param name="maximumBackoff">The maximum time period permissible for backing off between retries.</param>
        /// <param name="maximumRetryCount">The maximum number of retries allowed.</param>
        ///
        /// <returns>The exponential base for retry interval calculations.</returns>
        ///
        private double ComputeRetryFactor(TimeSpan minimumBackoff,
                                          TimeSpan maximumBackoff,
                                          int      maximumRetryCount)
        {
            double deltaBackoff = maximumBackoff.Subtract(minimumBackoff).TotalSeconds;

            if ((deltaBackoff <= 0) || (maximumRetryCount <= 0))
            {
                return 0;
            }

            return (Math.Log(deltaBackoff) / Math.Log(maximumRetryCount));
        }
    }
}
