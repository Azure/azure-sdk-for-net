// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// A retry policy, which does not actually retry.
    /// </summary>
    /// <remarks>Use this if you want all Service Bus exceptions to be handled by user code.</remarks>
    public sealed class NoRetry : RetryPolicy
    {
        /// <summary>
        /// Called to see if a retry should be performed.
        /// </summary>
        /// <param name="remainingTime">The remaining time before the timeout expires.</param>
        /// <param name="currentRetryCount">The number of attempts that have been processed.</param>
        /// <param name="retryInterval">The amount of time to delay before retry.</param>
        protected override bool OnShouldRetry(
            TimeSpan remainingTime,
            int currentRetryCount,
            out TimeSpan retryInterval)
        {
            retryInterval = TimeSpan.Zero;
            return false;
        }
    }
}