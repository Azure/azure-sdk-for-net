// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Represents a retry strategy with a specified number of retry attempts and a default, fixed 
    /// time interval between retries.
    /// </summary>
    public class FixedIntervalRetryStrategy : RetryStrategy
    {
        private readonly int _retryCount;
        private readonly TimeSpan _retryInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedIntervalRetryStrategy"/> class. 
        /// </summary>
        public FixedIntervalRetryStrategy()
            : this(DefaultClientRetryCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedIntervalRetryStrategy"/> class with the 
        /// specified number of retry attempts. 
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        public FixedIntervalRetryStrategy(int retryCount)
            : this(retryCount, DefaultRetryInterval)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedIntervalRetryStrategy"/> class with the 
        /// specified number of retry attempts and time interval. 
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="retryInterval">The time interval between retries.</param>
        public FixedIntervalRetryStrategy(int retryCount, TimeSpan retryInterval)
            : this(null, retryCount, retryInterval, DefaultFirstFastRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedIntervalRetryStrategy"/> class with the 
        /// specified number of retry attempts, time interval, and retry strategy. 
        /// </summary>
        /// <param name="name">The retry strategy name.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="retryInterval">The time interval between retries.</param>
        public FixedIntervalRetryStrategy(string name, int retryCount, TimeSpan retryInterval)
            : this(name, retryCount, retryInterval, DefaultFirstFastRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedIntervalRetryStrategy"/> class with the 
        /// specified number of retry attempts, time interval, retry strategy, and fast start option. 
        /// </summary>
        /// <param name="name">The retry strategy name.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="retryInterval">The time interval between retries.</param>
        /// <param name="firstFastRetry">true to immediately retry in the first attempt; otherwise, false. 
        /// The subsequent retries will remain subject to the configured retry interval.</param>
        public FixedIntervalRetryStrategy(string name, int retryCount, TimeSpan retryInterval, bool firstFastRetry)
            : base(name, firstFastRetry)
        {
            Guard.ArgumentNotNegativeValue(retryCount, "retryCount");
            Guard.ArgumentNotNegativeValue(retryInterval.Ticks, "retryInterval");

            _retryCount = retryCount;
            _retryInterval = retryInterval;
        }

        /// <summary>
        /// Returns the corresponding ShouldRetry delegate.
        /// </summary>
        /// <returns>The ShouldRetry delegate.</returns>
        public override ShouldRetryHandler GetShouldRetryHandler()
        {
            if (_retryCount == 0)
            {
                return
                    delegate(int currentRetryCount, Exception lastException)
                    {
                        return new RetryCondition(false, TimeSpan.Zero);
                    };
            }

            return delegate(int currentRetryCount, Exception lastException)
            {
                if (currentRetryCount < _retryCount)
                {
                    return new RetryCondition(true, _retryInterval);
                }
                return new RetryCondition(false, TimeSpan.Zero);
            };
        }
    }
}