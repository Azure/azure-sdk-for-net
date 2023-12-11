// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Exception class for request validations.
    /// </summary>
    internal class AuthenticationEventTriggerRequestValidationException : AuthenticationEventTriggerValidationException
    {
        /// <inheritdoc/>
        public override HttpStatusCode ExceptionStatusCode => HttpStatusCode.InternalServerError;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerRequestValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public AuthenticationEventTriggerRequestValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerRequestValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AuthenticationEventTriggerRequestValidationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
