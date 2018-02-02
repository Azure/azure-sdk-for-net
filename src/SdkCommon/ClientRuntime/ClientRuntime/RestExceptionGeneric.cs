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
        public RestException() : base()
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
        
        public T Body { get; set; }
        
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }

        /// <summary>
        /// Gets/Sets the HTTP status code returned by server.
        /// </summary>
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// Gets/Sets request id of the operation.
        /// </summary>
        public string RequestId { get; set; }

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