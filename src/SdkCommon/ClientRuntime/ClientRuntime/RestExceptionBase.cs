// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Runtime.Serialization;
namespace Microsoft.Rest
{
    // An abstract base class from which RestExceptions will be derived
    public abstract class RestExceptionBase : Exception
    {
        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        public RestExceptionBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public RestExceptionBase(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RestExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if FullNetFx
        /// <summary>
        /// Initializes a new instance of the RestException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected RestExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}