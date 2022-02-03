// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    ///  The set of options that can be specified to influence how
    ///  retry attempts are made, and a failure is eligible to be retried.
    /// </summary>
    public class RetryOptions
    {
        internal RetryOptions()
        {
        }

        internal RetryOptions(RetryOptions retryOptions)
        {
            MaxRetries = retryOptions.MaxRetries;
            Delay = retryOptions.Delay;
            MaxDelay = retryOptions.MaxDelay;
            Mode = retryOptions.Mode;
            NetworkTimeout = retryOptions.NetworkTimeout;
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
    }
}
