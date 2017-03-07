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
