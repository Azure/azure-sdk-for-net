// -----------------------------------------------------------------------------------------
// <copyright file="ExponentialRetry.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.RetryPolicies
{
    using System;
    using Microsoft.WindowsAzure.Storage.Core;

    /// <summary>
    /// Represents a retry policy that performs a specified number of retries, using a randomized exponential backoff scheme to determine the interval between retries. 
    /// </summary>
    public sealed class ExponentialRetry : IRetryPolicy
    {
        private const int DefaultClientRetryCount = 3;
        private static readonly TimeSpan DefaultClientBackoff = TimeSpan.FromSeconds(4);
        private TimeSpan maxBackoff = TimeSpan.FromSeconds(120);
        private TimeSpan minBackoff = TimeSpan.FromSeconds(3);

        private TimeSpan deltaBackoff;
        private int maximumAttempts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentialRetry"/> class.
        /// </summary>
        public ExponentialRetry()
            : this(DefaultClientBackoff, DefaultClientRetryCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentialRetry"/> class using the specified delta and maximum number of retries.
        /// </summary>
        /// <param name="deltaBackoff">The backoff interval between retries.</param>
        /// <param name="maxAttempts">The maximum number of retry attempts.</param>
        public ExponentialRetry(TimeSpan deltaBackoff, int maxAttempts)
        {
            this.deltaBackoff = deltaBackoff;
            this.maximumAttempts = maxAttempts;
        }

        /// <summary>
        /// Determines if the operation should be retried and how long to wait until the next retry. 
        /// </summary>
        /// <param name="currentRetryCount">The number of retries for the given operation. A value of zero signifies this is the first error encountered.</param>
        /// <param name="statusCode">The status code for the last operation.</param>
        /// <param name="lastException">An <see cref="Exception"/> object that represents the last exception encountered.</param>
        /// <param name="retryInterval">The interval to wait until the next retry.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><code>true</code> if the operation should be retried; otherwise, <code>false</code>.</returns>
        public bool ShouldRetry(int currentRetryCount, int statusCode, Exception lastException, out TimeSpan retryInterval, OperationContext operationContext)
        {
            retryInterval = TimeSpan.Zero;

            if ((statusCode >= 400 && statusCode < 500)
                || statusCode == 306 // Internal error / Cancellation
                  || statusCode == 501 // Not Implemented
                    || statusCode == 505 // Version Not Supported
                || lastException.Message == SR.BlobTypeMismatch)
            {
                return false;
            }

            if (currentRetryCount < this.maximumAttempts)
            {
                Random r = new Random();
                int increment = (int)((Math.Pow(2, currentRetryCount) - 1) * r.Next((int)(this.deltaBackoff.TotalMilliseconds * 0.8), (int)(this.deltaBackoff.TotalMilliseconds * 1.2)));

                if (increment < 0 || increment > this.maxBackoff.TotalMilliseconds)
                {
                    retryInterval = this.maxBackoff;
                }
                else
                {
                    retryInterval = TimeSpan.FromMilliseconds(this.minBackoff.TotalMilliseconds + increment);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Generates a new retry policy for the current request attempt.
        /// </summary>
        /// <returns>An <see cref="IRetryPolicy"/> object that represents the retry policy for the current request attempt.</returns>
        public IRetryPolicy CreateInstance()
        {
            return new ExponentialRetry(this.deltaBackoff, this.maximumAttempts);
        }
    }
}
