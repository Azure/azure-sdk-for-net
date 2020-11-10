// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents an error that occurred while renewing a token.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TokenRenewalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRenewalException"/> class.
        /// </summary>
        public TokenRenewalException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRenewalException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TokenRenewalException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRenewalException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TokenRenewalException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
