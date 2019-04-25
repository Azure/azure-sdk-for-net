// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// RetryPolicy implementation where the delay between retries will grow in a staggered exponential manner.
    /// RetryPolicy can be set on the client using <see cref="EventHubClient"/>.
    /// RetryIntervals will be computed using a retryFactor which is a function of deltaBackOff (MaximumBackoff - MinimumBackoff) and MaximumRetryCount
    /// </summary>
    public sealed class RetryExponential : RetryPolicy
    {
        readonly TimeSpan minimumBackoff;
        readonly TimeSpan maximumBackoff;
        readonly int maximumRetryCount;
        readonly double retryFactor;

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

            this.minimumBackoff = minimumBackoff;
            this.maximumBackoff = maximumBackoff;
            this.maximumRetryCount = maximumRetryCount;
            this.retryFactor = this.ComputeRetryFactor();
        }

        /// <summary></summary>
        /// <param name="lastException"></param>
        /// <param name="remainingTime"></param>
        /// <param name="baseWaitTimeSecs"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        protected override TimeSpan? OnGetNextRetryInterval(Exception lastException, TimeSpan remainingTime, int baseWaitTimeSecs, int retryCount)
        {
            if (retryCount >= this.maximumRetryCount)
            {
                return null;
            }

            if (!RetryPolicy.IsRetryableException(lastException))
            {
                return null;
            }

            double nextRetryInterval = Math.Pow(this.retryFactor, (double)retryCount);
            long nextRetryIntervalSeconds = (long)nextRetryInterval;
            long nextRetryIntervalMilliseconds = (long)((nextRetryInterval - (double)nextRetryIntervalSeconds) * 1000);

            TimeSpan retryAfter = this.minimumBackoff.Add(TimeSpan.FromMilliseconds(nextRetryIntervalSeconds * 1000 + nextRetryIntervalMilliseconds));
            retryAfter = retryAfter.Add(TimeSpan.FromSeconds(baseWaitTimeSecs));

            return retryAfter;
        }

        private double ComputeRetryFactor()
        {
            double deltaBackoff = this.maximumBackoff.Subtract(this.minimumBackoff).TotalSeconds;
            if (deltaBackoff <= 0 || this.maximumRetryCount <= 0)
            {
                return 0;
            }

            return (Math.Log(deltaBackoff) / Math.Log(this.maximumRetryCount));
        }

        /// <summary>Creates a new copy of this instance.</summary>
        /// <returns>The created new copy of this instance.</returns>
        public override RetryPolicy Clone()
        {
            return new RetryExponential(this.minimumBackoff, this.maximumBackoff, this.maximumRetryCount);
        }
    }
}
