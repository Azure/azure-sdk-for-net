// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// An exception indicating that interactive authentication is required.
    /// </summary>
    [Serializable]
    public class AuthenticationRequiredException : CredentialUnavailableException
    {
        /// <summary>
        /// Creates a new <see cref="AuthenticationRequiredException"/> with the specified message and context.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        /// <param name="context">The details of the authentication request.</param>
        public AuthenticationRequiredException(string message, TokenRequestContext context)
            : this(message, context, default)
        {
        }

        /// <summary>
        /// Creates a new <see cref="AuthenticationRequiredException"/> with the specified message, context and inner exception.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        /// <param name="context">The details of the authentication request.</param>
        /// <param name="innerException">The exception underlying the authentication failure.</param>
        public AuthenticationRequiredException(string message, TokenRequestContext context, Exception innerException)
            : base(message, innerException)
        {
            TokenRequestContext = context;
        }

        /// <summary>
        /// A constructor used for serialization.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        /// <returns></returns>
#if NET8_0_OR_GREATER
        [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
        protected AuthenticationRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// The details of the authentication request which resulted in the authentication failure.
        /// </summary>
        public TokenRequestContext TokenRequestContext { get; }
    }
}
