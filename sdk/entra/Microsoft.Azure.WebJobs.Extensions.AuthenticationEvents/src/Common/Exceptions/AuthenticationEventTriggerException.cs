// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Root exception for AuthenticationEventTrigger.
    /// </summary>
    internal abstract class AuthenticationEventTriggerException : Exception
    {
        /// <summary>
        /// Status code when exception is thrown.
        /// </summary>
        public abstract HttpStatusCode ExceptionStatusCode { get; }

        /// <summary>
        /// Reason phrase when exception is thrown.
        /// </summary>
        public abstract string ReasonPhrase { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public AuthenticationEventTriggerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationEventTriggerException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AuthenticationEventTriggerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
