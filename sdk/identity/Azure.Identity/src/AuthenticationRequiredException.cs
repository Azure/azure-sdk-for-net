// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// An exception indicating that interactive authentication is required.
    /// </summary>
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
        /// The details of the authentication request which resulted in the authentication failure.
        /// </summary>
        public TokenRequestContext TokenRequestContext { get; }
    }
}
