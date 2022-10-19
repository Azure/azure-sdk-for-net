// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    ///  The set of options that can be specified to influence how
    ///  retry attempts are made, and a failure is eligible to be retried.
    /// </summary>
    public class RetryOptions
    {
        /// <summary>
        /// Creates a new <see cref="RetryOptions"/> instance with default values.
        /// </summary>
        internal RetryOptions() : this(ClientOptions.Default.Retry)
        {
        }

        /// <summary>
        /// Initializes the newly created <see cref="RetryOptions"/> with the same settings as the specified <paramref name="retryOptions"/>.
        /// </summary>
        /// <param name="retryOptions">The <see cref="RetryOptions"/> to model the newly created instance on.</param>
        internal RetryOptions(RetryOptions? retryOptions)
        {
            if (retryOptions != null)
            {
                MaxRetries = retryOptions.MaxRetries;
                Delay = retryOptions.Delay;
                MaxDelay = retryOptions.MaxDelay;
                Mode = retryOptions.Mode;
                NetworkTimeout = retryOptions.NetworkTimeout;
                RetryConditions = retryOptions.RetryConditions;
            }
            else
            {
                RetryConditions = new List<RetryCondition>();
            }
        }

        /// <summary>
        /// The maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// The delay between retry attempts for a fixed approach or the delay
        /// on which to base calculations for a backoff-based approach.
        /// If the service provides a Retry-After response header, the next retry will be delayed by the duration specified by the header value.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(0.8);

        /// <summary>
        /// The maximum permissible delay between retry attempts when the service does not provide a Retry-After response header.
        /// If the service provides a Retry-After response header, the next retry will be delayed by the duration specified by the header value.
        /// </summary>
        public TimeSpan MaxDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The approach to use for calculating retry delays.
        /// </summary>
        public RetryMode Mode { get; set; } = RetryMode.Exponential;

        /// <summary>
        /// The timeout applied to an individual network operations.
        /// </summary>
        public TimeSpan NetworkTimeout { get; set; } = TimeSpan.FromSeconds(100);

        /// <summary>
        /// Adds a condition to help determine whether or not a request should be retried.
        /// Adding a <see cref="RetryCondition"/> changes the "should retry" behavior of the default
        /// pipeline RetryPolicy. Conditions are applied in order, so the most recently added
        /// condition takes precendece over those that were previously added.
        /// </summary>
        /// <param name="condition"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddRetryCondition(RetryCondition condition)
        {
            throw new NotImplementedException();
        }

        internal IList<RetryCondition> RetryConditions { get; }
    }
}
