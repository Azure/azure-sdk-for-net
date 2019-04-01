// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿
namespace Microsoft.Azure.Batch
{
    using System;
    using Common;

    /// <summary>
    /// A RequestInterceptor that sets the RetryPolicy.
    /// </summary>
    public class RetryPolicyProvider : Protocol.RequestInterceptor
    {
        /// <summary>
        /// Gets or sets the retry policy to use.
        /// </summary>
        public IRetryPolicy Policy { get; set; }

        /// <summary>
        /// Creates a new <see cref="RetryPolicyProvider"/> using the <see cref="NoRetry"/> policy.
        /// </summary>
        /// <returns>A provider configured to perform no retries.</returns>
        public static RetryPolicyProvider NoRetryProvider()
        {
            return new RetryPolicyProvider(new NoRetry());
        }

        /// <summary>
        /// Creates a new <see cref="RetryPolicyProvider"/> using the <see cref="LinearRetry"/> policy.
        /// </summary>
        /// <param name="deltaBackoff">The backoff interval between retries.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <returns>A provider configured to perform linear retries using the specified backoff and max retries.</returns>
        public static RetryPolicyProvider LinearRetryProvider(TimeSpan deltaBackoff, int maxRetries)
        {
            return new RetryPolicyProvider(new LinearRetry(deltaBackoff, maxRetries));
        }
        
        /// <summary>
        /// Creates a new <see cref="RetryPolicyProvider"/> using the <see cref="ExponentialRetry"/> policy.
        /// </summary>
        /// <param name="deltaBackoff">The backoff interval between retries, where the resulting backoff is 2^n * deltaBackoff (where n is the number of retries)</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <returns>A provider configured to perform exponential retries using the specified backoff and max retries.</returns>
        public static RetryPolicyProvider ExponentialRetryProvider(TimeSpan deltaBackoff, int maxRetries)
        {
            return new RetryPolicyProvider(new ExponentialRetry(deltaBackoff, maxRetries));
        }

        /// <summary>
        /// Initializes a new behavior to set the retry policy.
        /// </summary>
        /// <param name="retryPolicy">The retry policy to set.</param>
        public RetryPolicyProvider(IRetryPolicy retryPolicy)
        {
            this.Policy = retryPolicy;

            base.ModificationInterceptHandler = SetRetryPolicyInterceptor;
        }

        private void SetRetryPolicyInterceptor(Protocol.IBatchRequest request)
        {
            if (null != this.Policy)
            {
                request.RetryPolicy = this.Policy;
            }
        }
    }
}
