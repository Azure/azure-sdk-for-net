// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Runtime.Serialization;
#if !PORTABLE
using System.Security.Permissions;
#endif

namespace Microsoft.Rest
{
    /// <summary>
    /// Exception thrown for an invalid response with custom error information.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class HttpOperationException : RestException
    {
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }

        /// <summary>
        /// Gets or sets the response object.
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the HttpOperationException class.
        /// </summary>
        public HttpOperationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the HttpOperationException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public HttpOperationException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the HttpOperationException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public HttpOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the HttpOperationException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected HttpOperationException(SerializationInfo info, StreamingContext context)
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

            info.AddValue("Request", Request);
            info.AddValue("Response", Response);
            info.AddValue("Body", Body);
        }
#endif
    }
}