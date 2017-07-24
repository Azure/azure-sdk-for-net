// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a retry policy.
    /// </summary>
    public interface IRetryPolicy
    {
        /// <summary>
        /// Determines if the operation should be retried and how long to wait until the next retry. 
        /// </summary>
        /// <param name="exception">An <see cref="Exception"/> object that represents the last exception encountered.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="RetryDecision"/> object which specifies if a retry should be performed.</returns>
        Task<RetryDecision> ShouldRetryAsync(Exception exception, OperationContext operationContext);
    }
}
