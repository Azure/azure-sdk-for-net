// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// delegate used by CloudException to return the exception message
    /// </summary>
    public delegate string ExceptionMessageGetter();

    /// <summary>
    /// An exception generated from an http response returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : RestException
    {
        /// <summary>
        /// Gets or sets the response object.
        /// </summary>
        public CloudError Body { get; set; }

        private ExceptionMessageGetter MessageGetter;

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
            InitializeDefaultMessageGetter(null);
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message)
        {
            InitializeDefaultMessageGetter(null);
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException)
        {
            InitializeDefaultMessageGetter(null);
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class with delegate that decides what should be the message displayed
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="messageGetter">delegate to determine what message is returned</param>
        public CloudException(string message, ExceptionMessageGetter messageGetter) : base(message)
        {
            InitializeDefaultMessageGetter(messageGetter);
        }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responseMessage">The response message.</param>
        public CloudException(string message, HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage, int statusCode) : base(message, requestMessage, responseMessage, statusCode)
        {
            InitializeDefaultMessageGetter(null);
        }

        public override string Message => MessageGetter();

        private void InitializeDefaultMessageGetter(ExceptionMessageGetter messageGetter)
        {
            if (messageGetter == null)
            {
                this.MessageGetter = () => (string.IsNullOrEmpty(Body?.Message)) ? base.Message : Body.Message;
            }
            else
            {
                this.MessageGetter = messageGetter;
            }
        }
    }
}
