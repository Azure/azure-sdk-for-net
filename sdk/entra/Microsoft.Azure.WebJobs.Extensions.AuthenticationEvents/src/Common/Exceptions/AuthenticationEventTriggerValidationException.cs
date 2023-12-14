// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Root exception for AuthenticationEventTriggerValidation.
    /// </summary>
    internal abstract class AuthenticationEventTriggerValidationException : AuthenticationEventTriggerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerValidationException"/> class.
        /// </summary>
        /// <param name="message">asdfasd</param>
        public AuthenticationEventTriggerValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AuthenticationEventTriggerValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
