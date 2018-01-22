// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;

namespace Microsoft.Rest.Azure
{
    public delegate string ExceptionMessageGetter();

    /// <summary>
    /// An exception generated from an http response returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : RestException
    {

        protected string _message;

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
        public CloudError Body
        {
            get
            {
                return ErrorBody;
            }

            set
            {
                ErrorBody = value;
            }
        }
        

        public CloudError ErrorBody { get; set; }

        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        public CloudException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message)
        {
            _message = message;
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
            _message = message;
        }
        
        public override string Message => string.IsNullOrEmpty(ErrorBody?.Message) ? _message : ErrorBody.Message;

        protected string BaseExceptionMessage => base.Message;
    }
}
