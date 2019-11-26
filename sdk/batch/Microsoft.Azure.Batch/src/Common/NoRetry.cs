// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a retry policy that performs no retries.
    /// </summary>
    public class NoRetry : IRetryPolicy
    {
        /// <summary>
        /// Determines if the operation should be retried and how long to wait until the next retry. This
        /// implementation always returns <see cref="RetryDecision.NoRetry"/>.
        /// </summary>
        /// <param name="exception">An <see cref="Exception"/> object that represents the last exception encountered.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="RetryDecision"/> object which specifies if a retry should be performed.This
        /// implementation always returns <see cref="RetryDecision.NoRetry"/>.</returns>
        public Task<RetryDecision> ShouldRetryAsync(Exception exception, OperationContext operationContext)
        {
            return Task.FromResult(RetryDecision.NoRetry);
        }
    }
}
