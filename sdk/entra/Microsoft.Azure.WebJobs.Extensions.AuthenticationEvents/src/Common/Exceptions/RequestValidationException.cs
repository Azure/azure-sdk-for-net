// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Exception class for request validations
    /// </summary>
    public class RequestValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public RequestValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public RequestValidationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
