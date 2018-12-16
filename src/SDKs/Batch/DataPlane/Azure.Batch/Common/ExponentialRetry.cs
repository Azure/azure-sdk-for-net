// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a retry policy that performs a specified number of retries, using an exponential backoff scheme to determine the interval between retries. 
    /// </summary>
    public class ExponentialRetry : IRetryPolicy
    {
        /// <summary>
        /// Gets the backoff interval between retries, where the resulting backoff is 2^n * deltaBackoff (where n is the number of retries).
        /// </summary>
        public TimeSpan DeltaBackoff { get; private set; }

        /// <summary>
        /// Gets the maximum number of retry attempts.
        /// </summary>
        public int MaximumRetries { get; private set; }

        /// <summary>
        /// The maximum duration to wait between retries.
        /// </summary>
        public TimeSpan? MaxBackoff { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentialRetry"/> class using the specified delta and maximum number of retries.
        /// </summary>
        /// <param name="deltaBackoff">The backoff interval between retries, where the resulting backoff is 2^n * deltaBackoff (where n is the number of retries)</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="maxBackoff">The maximum duration to wait between retries.</param>
        public ExponentialRetry(TimeSpan deltaBackoff, int maxRetries, TimeSpan? maxBackoff = null)
        {
            RetryPolicyCommon.ValidateArguments(deltaBackoff, maxRetries);

            if (maxBackoff < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(maxBackoff));
            }

            this.DeltaBackoff = deltaBackoff;
            this.MaximumRetries = maxRetries;
            this.MaxBackoff = maxBackoff;
        }

        /// <summary>
        /// Determines if the operation should be retried and how long to wait until the next retry. 
        /// </summary>
        /// <param name="exception">An <see cref="Exception"/> object that represents the last exception encountered.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="RetryDecision"/> object which specifies if a retry should be performed.</returns>
        public Task<RetryDecision> ShouldRetryAsync(Exception exception, OperationContext operationContext)
        {
            if (operationContext == null)
            {
                throw new ArgumentNullException("operationContext");
            }

            bool shouldRetry = RetryPolicyCommon.ShouldRetry(exception, operationContext, this.MaximumRetries);
            TimeSpan? retryAfter = (exception as BatchException)?.RequestInformation?.RetryAfter;
            int currentRetryCount = operationContext.RequestResults.Count - 1;

            RetryDecision decision;
            if (shouldRetry)
            {
                double deltaBackoffMilliseconds = this.DeltaBackoff.TotalMilliseconds;
                double millisecondsBackoff = Math.Pow(2, currentRetryCount) * deltaBackoffMilliseconds;

                var delay = TimeSpan.FromMilliseconds(millisecondsBackoff);
                delay = retryAfter.HasValue && delay > retryAfter ? retryAfter.Value : delay;
                delay = this.MaxBackoff.HasValue && delay > this.MaxBackoff ? this.MaxBackoff.Value : delay;

                decision = RetryDecision.RetryWithDelay(delay);
            }
            else
            {
                decision = RetryDecision.NoRetry;
            }

            return Task.FromResult(decision);
        }
    }
}
