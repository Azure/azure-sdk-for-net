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

        internal static AuthenticationFailedException CreateAggregateException(string message, IList<Exception> exceptions)
        {
            // Build the credential unavailable message, this code is only reachable if all credentials throw AuthenticationFailedException
            StringBuilder errorMsg = new StringBuilder(message);

            bool allCredentialUnavailableException = true;
            foreach (var exception in exceptions)
            {
                allCredentialUnavailableException &= exception is CredentialUnavailableException;
                errorMsg.Append(Environment.NewLine).Append("- ").Append(exception.Message);
            }

            var innerException = exceptions.Count == 1
                ? exceptions[0]
                : new AggregateException("Multiple exceptions were encountered while attempting to authenticate.", exceptions);

            // If all credentials have thrown CredentialUnavailableException, throw CredentialUnavailableException,
            // otherwise throw AuthenticationFailedException
            return allCredentialUnavailableException
                ? new CredentialUnavailableException(errorMsg.ToString(), innerException)
                : new AuthenticationFailedException(errorMsg.ToString(), innerException);
        }
    }
}
