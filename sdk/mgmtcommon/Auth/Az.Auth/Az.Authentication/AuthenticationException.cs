// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.Rest;
#if FullNetFx
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Security.Permissions;
#endif

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Authentication exception for Microsoft Rest Client for Azure. 
    /// </summary>
#if FullNetFx
    [Serializable]
#endif
    public class AuthenticationException : RestException
    {

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        public AuthenticationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public AuthenticationException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public AuthenticationException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

#if FullNetFx
        /// <summary>
        /// Wrap an exception thrown by the ADAL library.  This prevents client dependencies on a particular version fo ADAL.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner AdalException with additional details</param>
        internal AuthenticationException(string message, AdalException innerException) : 
            base(string.Format(CultureInfo.CurrentCulture, message, (innerException == null)? string.Empty : innerException?.Message ), innerException)
        {
        }


        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected AuthenticationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Serializes content of the exception.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
        }
#endif
    }
}