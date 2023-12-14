// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Exception class for response validations.
    /// </summary>
    internal class AuthenticationEventTriggerResponseValidationException : AuthenticationEventTriggerValidationException
    {
        /// <inheritdoc/>
        public override HttpStatusCode ExceptionStatusCode => HttpStatusCode.BadRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerResponseValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public AuthenticationEventTriggerResponseValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerResponseValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AuthenticationEventTriggerResponseValidationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
