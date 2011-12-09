//-----------------------------------------------------------------------
// <copyright file="ResponseReceivedEventArgs.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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