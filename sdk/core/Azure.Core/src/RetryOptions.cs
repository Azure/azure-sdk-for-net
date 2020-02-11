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

        /// <summary>
        /// The maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// The delay between retry attempts for a fixed approach or the delay
        /// on which to base calculations for a backoff-based approach.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(0.8);

        /// <summary>
        /// The maximum permissible delay between retry attempts.
        /// </summary>
        public TimeSpan MaxDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The approach to use for calculating retry delays.
        /// </summary>
        public RetryMode Mode { get; set; } = RetryMode.Exponential;
    }
}
