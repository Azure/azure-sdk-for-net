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
using Microsoft.WindowsAzure.Common.Properties;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// The special type of exception that provides managed exit from a retry loop. The user code can use this
    /// exception to notify the retry policy that no further retry attempts are required.
    /// </summary>
    [Obsolete("You should use cancellation tokens or other means of stoping the retry loop.")]
    public sealed class RetryLimitExceededException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryLimitExceededException"/> class with a default error message.
        /// </summary>
        public RetryLimitExceededException()
            : this(Resources.RetryLimitExceeded)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryLimitExceededException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RetryLimitExceededException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryLimitExceededException"/> class with a reference to the inner exception
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RetryLimitExceededException(Exception innerException)
            : base(innerException != null ? innerException.Message : Resources.RetryLimitExceeded, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryLimitExceededException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RetryLimitExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
