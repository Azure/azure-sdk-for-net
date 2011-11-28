//-----------------------------------------------------------------------
// <copyright file="ResponseReceivedEventArgs.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ResponseReceivedEventArgs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using Protocol;

    /// <summary>
    /// Provides the arguments for the <c>ResponseReceived</c> event.
    /// </summary>
    public class ResponseReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the request ID.
        /// </summary>
        /// <value>The request ID.</value>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Gets the request headers.
        /// </summary>
        /// <value>The collection of request headers.</value>
        /// <remarks>Modifying the collection of request headers may result in unexpected behavior.</remarks>
        public NameValueCollection RequestHeaders { get; internal set; }

        /// <summary>
        /// Gets the request URI.
        /// </summary>
        /// <value>The request URI.</value>
        public Uri RequestUri { get; internal set; }

        /// <summary>
        /// Gets the response headers.
        /// </summary>
        /// <value>The collection of response headers.</value>
        /// <remarks>Modifying the collection of response headers may result in unexpected behavior.</remarks>
        public NameValueCollection ResponseHeaders { get; internal set; }

        /// <summary>
        /// Gets the HTTP status code for the request.
        /// </summary>
        /// <value>The HTTP status code for the request.</value>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets the status description for the request.
        /// </summary>
        /// <value>The status description for the request.</value>
        public string StatusDescription { get; internal set; }

        /// <summary>
        /// Gets an exception returned by the service.
        /// </summary>
        /// <value>The exception returned by the service.</value>
        public Exception Exception { get; internal set; }
    }
}