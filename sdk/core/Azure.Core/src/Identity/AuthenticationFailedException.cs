// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// An exception class raised for errors in authenticating client requests.
    /// </summary>
    [Serializable]
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
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

        /// <summary>
        /// A constructor used for serialization.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        /// <returns></returns>
#if NET8_0_OR_GREATER
        [Obsolete(DiagnosticId = "SYSLIB0051")]
#endif
        protected AuthenticationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
#pragma warning restore AZC0034
}
