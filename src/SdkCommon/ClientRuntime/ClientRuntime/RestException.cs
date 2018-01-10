// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace Microsoft.Rest
{
    /// <summary>
    /// Generic exception for Microsoft Rest Client. 
    /// </summary>
#if FullNetFx
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

        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }

        /// <summary>
        /// the status code returned by server
        /// </summary>
        //public int ResponseStatusCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responseMessage">The response message.</param>
        public RestException(string message, HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage, int statusCode) : base(message)
        {
            Request = requestMessage;
            Response = responseMessage;
            //ResponseStatusCode = statusCode;
        }

#if FullNetFx
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