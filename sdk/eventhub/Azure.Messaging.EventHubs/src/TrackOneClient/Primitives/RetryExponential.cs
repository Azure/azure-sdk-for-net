// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// RetryPolicy implementation where the delay between retries will grow in a staggered exponential manner.
    /// RetryPolicy can be set on the client using <see cref="EventHubClient"/>.
    /// RetryIntervals will be computed using a retryFactor which is a function of deltaBackOff (MaximumBackoff - MinimumBackoff) and MaximumRetryCount
    /// </summary>
    internal sealed class RetryExponential : RetryPolicy
    {
        internal readonly TimeSpan _minimumBackoff;
        internal readonly TimeSpan _maximumBackoff;
        internal readonly int _maximumRetryCount;
        internal readonly double _retryFactor;

        /// <summary>
        /// Returns a new RetryExponential retry policy object.
        /// </summary>
        /// <param name="minimumBackoff">Minimum backoff interval.</param>
        /// <param name="maximumBackoff">Maximum backoff interval.</param>
        /// <param name="maximumRetryCount">Maximum retry count.</param>
        public RetryExponential(TimeSpan minimumBackoff, TimeSpan maximumBackoff, int maximumRetryCount)
        {
            TimeoutHelper.ThrowIfNegativeArgument(minimumBackoff, nameof(minimumBackoff));
            TimeoutHelper.ThrowIfNegativeArgument(maximumBackoff, nameof(maximumBackoff));

            _minimumBackoff = minimumBackoff;
            _maximumBackoff = maximumBackoff;
            _maximumRetryCount = maximumRetryCount;
            _retryFactor = ComputeRetryFactor();
        }

        /// <summary></summary>
        /// <param name="lastException"></param>
        /// <param name="remainingTime"></param>
        /// <param name="baseWaitTimeSecs"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        protected override TimeSpan? OnGetNextRetryInterval(Exception lastException, TimeSpan remainingTime, int baseWaitTimeSecs, int retryCount)
        {
            if (retryCount >= _maximumRetryCount)
            {
                return null;
            }

            if (!RetryPolicy.IsRetryableException(lastException))
            {
                return null;
            }

            double nextRetryInterval = Math.Pow(_retryFactor, (double)retryCount);
            long nextRetryIntervalSeconds = (long)nextRetryInterval;
            long nextRetryIntervalMilliseconds = (long)((nextRetryInterval - (double)nextRetryIntervalSeconds) * 1000);

            TimeSpan retryAfter = _minimumBackoff.Add(TimeSpan.FromMilliseconds(nextRetryIntervalSeconds * 1000 + nextRetryIntervalMilliseconds));
            retryAfter = retryAfter.Add(TimeSpan.FromSeconds(baseWaitTimeSecs));

            return retryAfter;
        }

        private double ComputeRetryFactor()
        {
            double deltaBackoff = _maximumBackoff.Subtract(_minimumBackoff).TotalSeconds;
            if (deltaBackoff <= 0 || _maximumRetryCount <= 0)
            {
                return 0;
            }

            return (Math.Log(deltaBackoff) / Math.Log(_maximumRetryCount));
        }

        /// <summary>Creates a new copy of this instance.</summary>
        /// <returns>The created new copy of this instance.</returns>
        public override RetryPolicy Clone()
        {
            return new RetryExponential(_minimumBackoff, _maximumBackoff, _maximumRetryCount);
        }
    }
}
