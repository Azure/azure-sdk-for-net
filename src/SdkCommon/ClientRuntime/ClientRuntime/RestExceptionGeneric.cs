// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
namespace Microsoft.Rest
{
#if FullNetFx
    [Serializable]
#endif
    public class RestException<T> : RestException
    {
        
        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        public RestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorModelException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public RestException(string message)
            : base(message, null)
        {
        }

        public RestException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responseMessage">The response message.</param>
        public RestException(string message, HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage) : base(message)
        {
            Request = requestMessage;
            Response = responseMessage;
        }

        public T ErrorBody { get; set; }
        
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }
        
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