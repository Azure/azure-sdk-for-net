// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
