// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Exception class for response validations
    /// </summary>
    public class ResponseValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public ResponseValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ResponseValidationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
