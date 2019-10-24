// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// An exception class raised for errors in authenticating client reqeusts.
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

        internal static AuthenticationFailedException CreateAggregateException(string message, ReadOnlyMemory<object> credentials, ReadOnlyMemory<Exception> innerExceptions)
        {
            StringBuilder exStr = new StringBuilder(message).AppendLine();

            for (int i = 0; i < credentials.Length; i++)
            {
                if (innerExceptions.Span[i] is CredentialUnavailableException)
                {
                    exStr.AppendLine($"  {credentials.Span[i].GetType().Name} is unavailable {innerExceptions.Span[i].Message}.");
                }
                else
                {
                    exStr.AppendLine($"  {credentials.Span[i].GetType().Name} failed with {innerExceptions.Span[i].Message}.");
                }
            }

            exStr.Append("See inner exception for more detail.");

            return new AuthenticationFailedException(exStr.ToString(), new AggregateException(message, innerExceptions.ToArray()));
        }
    }
}
