// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace Microsoft.Rest
{
    /// <summary>
    /// Generic exception for Microsoft Rest Client. 
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class RestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        public RestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public RestException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected RestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}