// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// The set of options to use for configuring the retry policy.
    /// </summary>
    public class RetryPolicyOptions
    {
        /// <summary>
        /// The maximum number of retries to attempt for a request.
        /// Defaults to 3.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// The delay strategy to use for calculating the delay between retry attempts.
        /// Defaults to an exponential strategy.
        /// </summary>
        public DelayStrategy? DelayStrategy { get; set; }

        /// <summary>
        /// The response classifier to use for determining if a response should be retried.
        /// </summary>
        public ResponseClassifier? ResponseClassifier { get; set; }
    }
}