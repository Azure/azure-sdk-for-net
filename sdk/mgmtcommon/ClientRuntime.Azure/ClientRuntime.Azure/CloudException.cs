// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception generated from an http response returned from a Microsoft Azure service
    /// </summary>
    public class CloudException : RestException
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
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        public CloudException() : base() { }

        /// <summary>
        /// Initializes a new instance of the CloudException class given exception message.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        public CloudException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the CloudException class caused by another exception.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        /// <param name="innerException">The exception which caused the current exception.</param>
        public CloudException(string message, Exception innerException) : base(message, innerException) { }

#if FullNetFx
        /// <summary>
        /// Initializes a new instance of the CloudException class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        public CloudException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if(info != null)
            {
                Request = info.GetValue("Request", typeof(HttpRequestMessageWrapper)) as HttpRequestMessageWrapper;
                Response = info.GetValue("Response", typeof(HttpResponseMessageWrapper)) as HttpResponseMessageWrapper;
                Body = info.GetValue("Body", typeof(CloudError)) as CloudError;
                RequestId = info.GetString("RequestId");
            }
        }

        /// <summary>
        /// Sets SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="info">Serialization infor.</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentException("info");

            info.AddValue("Request", Request);
            info.AddValue("Response", Response);
            info.AddValue("Body", Body);
            info.AddValue("RequestId", RequestId);

            base.GetObjectData(info, context);
        }
#endif
    }
}
