// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// An exception generated from an http response returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : RestException, IHttpRestException<CloudError>
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
        public CloudError Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        public CloudException() : base()
        {
        }

        /// <summary>
        /// The error code in Body
        /// </summary>
        public string Code => Body?.Code;

        /// <summary>
        /// The error message in Body
        /// </summary>
        public override string Message => (string.IsNullOrEmpty(Body?.Message))? base.Message : Body.Message;
        
        /// <summary>
        /// Target in error Body
        /// </summary>
        public string Target => Body?.Target;

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responseMessage">The response message.</param>
        public CloudException(string message, HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage) : base(message)
        {
            Request = requestMessage;
            Response = responseMessage;
        }

        public void SetErrorModel(CloudError errorBody)
        {
            this.Body = errorBody;
        }
    }
}
