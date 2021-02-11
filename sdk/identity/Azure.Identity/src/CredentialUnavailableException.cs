// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// An exception indicating a <see cref="TokenCredential"/> did not attempt to authenticate and retrieve <see cref="AccessToken"/>, as its prerequisite information or state was not available.
    /// </summary>
    public class CredentialUnavailableException : AuthenticationFailedException
    {
        /// <summary>
        /// Creates a new <see cref="CredentialUnavailableException"/> with the specified message.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        public CredentialUnavailableException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="CredentialUnavailableException"/> with the specified message.
        /// </summary>
        /// <param name="message">The message describing the authentication failure.</param>
        /// <param name="innerException">The exception underlying the authentication failure.</param>
        public CredentialUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        internal static CredentialUnavailableException CreateAggregateException(string message, IList<CredentialUnavailableException> exceptions)
        {
            if (exceptions.Count == 1)
            {
                return exceptions[0];
            }

            // Build the credential unavailable message, this code is only reachable if all credentials throw AuthenticationFailedException
            StringBuilder errorMsg = new StringBuilder(message);

            foreach (var exception in exceptions)
            {
                errorMsg.Append(Environment.NewLine).Append("- ").Append(exception.Message);
            }

            var innerException = new AggregateException("Multiple exceptions were encountered while attempting to authenticate.", exceptions);
            return new CredentialUnavailableException(errorMsg.ToString(), innerException);
        }
    }
}
