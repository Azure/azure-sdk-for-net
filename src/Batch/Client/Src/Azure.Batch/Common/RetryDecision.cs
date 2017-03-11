// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;

    /// <summary>
    /// Represents a decision made by an <see cref="IRetryPolicy"/>.
    /// </summary>
    public sealed class RetryDecision
    {
        /// <summary>
        /// A retry decision with <see cref="ShouldRetry"/> set to false
        /// </summary>
        public static readonly RetryDecision NoRetry = new RetryDecision();

        /// <summary>
        /// Create a new <see cref="RetryDecision"/> with the specified delay before the next retry.
        /// </summary>
        /// <param name="retryDelay">The duration to wait before performing the retry.</param>
        /// <returns>A <see cref="RetryDecision"/> object with the specified retry delay and <see cref="ShouldRetry"/> set to true.</returns>
        public static RetryDecision RetryWithDelay(TimeSpan retryDelay)
        {
            return new RetryDecision(retryDelay);
        }

        /// <summary>
        /// Gets the delay before the next retry.
        /// </summary>
        public TimeSpan? RetryDelay { get; private set; }

        /// <summary>
        /// Gets whether a retry should be performed or not.
        /// </summary>
        public bool ShouldRetry { get; private set; }
        

        private RetryDecision()
        {
            this.ShouldRetry = false;
            this.RetryDelay = null;
        }

        private RetryDecision(TimeSpan retryDelay)
        {
            this.ShouldRetry = true;
            this.RetryDelay = retryDelay;
        }

    }
}
