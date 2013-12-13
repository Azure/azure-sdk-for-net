//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// Provides a generic version of the <see cref="RetryPolicy"/> class.
    /// </summary>
    /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> interface that is responsible for detecting transient conditions.</typeparam>
    public class RetryPolicy<T> : RetryPolicy where T : ITransientErrorDetectionStrategy, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy{T}"/> class with the specified number of retry attempts and parameters defining the progressive delay between retries.
        /// </summary>
        /// <param name="retryStrategy">The strategy to use for this retry policy.</param>
        public RetryPolicy(RetryStrategy retryStrategy)
            : base(new T(), retryStrategy)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy{T}"/> class with the specified number of retry attempts and the default fixed time interval between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        public RetryPolicy(int retryCount)
            : base(new T(), retryCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy{T}"/> class with the specified number of retry attempts and a fixed time interval between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="retryInterval">The interval between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan retryInterval)
            : base(new T(), retryCount, retryInterval)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy{T}"/> class with the specified number of retry attempts and backoff parameters for calculating the exponential delay between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="minBackoff">The minimum backoff time.</param>
        /// <param name="maxBackoff">The maximum backoff time.</param>
        /// <param name="deltaBackoff">The time value that will be used to calculate a random delta in the exponential delay between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff)
            : base(new T(), retryCount, minBackoff, maxBackoff, deltaBackoff)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryPolicy{T}"/> class with the specified number of retry attempts and parameters defining the progressive delay between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval that will apply for the first retry.</param>
        /// <param name="increment">The incremental time value that will be used to calculate the progressive delay between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan initialInterval, TimeSpan increment)
            : base(new T(), retryCount, initialInterval, increment)
        {
        }
    }
}
