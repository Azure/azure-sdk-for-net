// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// A retry strategy with a specified number of retry attempts and an incremental time 
    /// interval between retries.
    /// </summary>
    public class IncrementalRetryStrategy : RetryStrategy
    {
        /// <summary>
        /// Represents the default time increment between retry attempts in the progressive delay policy.
        /// </summary>
        public static readonly TimeSpan DefaultRetryIncrement = TimeSpan.FromSeconds(1.0);

        private readonly TimeSpan _increment;
        private readonly TimeSpan _initialInterval;
        private readonly int _retryCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncrementalRetryStrategy"/> class. 
        /// </summary>
        public IncrementalRetryStrategy()
            : this(DefaultClientRetryCount, DefaultRetryInterval, DefaultRetryIncrement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncrementalRetryStrategy"/> class with the specified retry settings.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval that will apply for the first retry.</param>
        /// <param name="increment">The incremental time value that will be used to calculate the progressive 
        /// delay between retries.</param>
        public IncrementalRetryStrategy(int retryCount, TimeSpan initialInterval, TimeSpan increment)
            : this(null, retryCount, initialInterval, increment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncrementalRetryStrategy"/> class with the specified name and retry settings.
        /// </summary>
        /// <param name="name">The retry strategy name.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval that will apply for the first retry.</param>
        /// <param name="increment">The incremental time value that will be used to calculate the progressive 
        /// delay between retries.</param>
        public IncrementalRetryStrategy(string name, int retryCount, TimeSpan initialInterval, TimeSpan increment)
            : this(name, retryCount, initialInterval, increment, DefaultFirstFastRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncrementalRetryStrategy"/> class with the specified number of retry attempts, 
        /// time interval, retry strategy, and fast start option. 
        /// </summary>
        /// <param name="name">The retry strategy name.</param>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval that will apply for the first retry.</param>
        /// <param name="increment">The incremental time value that will be used to calculate the progressive delay between 
        /// retries.</param>
        /// <param name="firstFastRetry">true to immediately retry in the first attempt; otherwise, false. The subsequent 
        /// retries will remain subject to the configured retry interval.</param>
        public IncrementalRetryStrategy(string name, int retryCount, TimeSpan initialInterval, TimeSpan increment, bool firstFastRetry)
            : base(name, firstFastRetry)
        {
            Guard.ArgumentNotNegativeValue(retryCount, "retryCount");
            Guard.ArgumentNotNegativeValue(initialInterval.Ticks, "initialInterval");
            Guard.ArgumentNotNegativeValue(increment.Ticks, "increment");

            _retryCount = retryCount;
            _initialInterval = initialInterval;
            _increment = increment;
        }

        /// <summary>
        /// Returns the corresponding ShouldRetry delegate.
        /// </summary>
        /// <returns>The ShouldRetry delegate.</returns>
        public override ShouldRetryHandler GetShouldRetryHandler()
        {
            return delegate(int currentRetryCount, Exception lastException)
            {
                if (currentRetryCount < _retryCount)
                {
                    TimeSpan retryInterval = TimeSpan.FromMilliseconds(_initialInterval.TotalMilliseconds +
                                                                       (_increment.TotalMilliseconds*
                                                                        currentRetryCount));
                    return new RetryCondition(true, retryInterval);
                }
                return new RetryCondition(false, TimeSpan.Zero);
            };
        }
    }
}