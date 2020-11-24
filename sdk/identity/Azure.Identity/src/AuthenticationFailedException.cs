// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Azure.Identity
{
    /// <summary>
    /// An exception class raised for errors in authenticating client requests.
    /// </summary>
    public class AuthenticationFailedException : Exception
    {
        /// <summary>
        /// Creates a new AuthenticationFailedException with the specified message.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        public AuthenticationFailedException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Creates a new AuthenticationFailedException with the specified message.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        /// <param name="innerException">The exception underlying the authentication failure.</param>
        public AuthenticationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
