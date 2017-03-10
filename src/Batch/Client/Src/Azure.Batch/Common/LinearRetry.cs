// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a retry policy that performs a specified number of retries, using a specified fixed time interval between retries.
    /// </summary>
    public class LinearRetry : IRetryPolicy
    {
        /// <summary>
        /// Gets the backoff interval between retries.
        /// </summary>
        public TimeSpan DeltaBackoff { get; private set; }

        /// <summary>
        /// Gets the maximum number of retry attempts.
        /// </summary>
        public int MaximumRetries { get; private set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearRetry"/> class using the specified delta and maximum number of retries.
        /// </summary>
        /// <param name="deltaBackoff">The backoff interval between retries.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        public LinearRetry(TimeSpan deltaBackoff, int maxRetries)
        {
            RetryPolicyCommon.ValidateArguments(deltaBackoff, maxRetries);

            this.DeltaBackoff = deltaBackoff;
            this.MaximumRetries = maxRetries;
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

            RetryDecision decision;
            if (shouldRetry)
            {
                decision = RetryDecision.RetryWithDelay(this.DeltaBackoff);
            }
            else
            {
                decision = RetryDecision.NoRetry;
            }

            return Task.FromResult(decision);
        }
    }
}
