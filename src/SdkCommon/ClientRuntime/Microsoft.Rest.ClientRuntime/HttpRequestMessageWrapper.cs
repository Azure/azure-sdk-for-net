// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Rest
{
    /// <summary>
    /// Wrapper around HttpRequestMessage type that copies properties of HttpRequestMessage so that
    /// they are available after the HttpClient gets disposed.
    /// </summary>
    public class HttpRequestMessageWrapper : HttpMessageWrapper
    {
        /// <summary>
        /// Initializes a new instance of the HttpRequestMessageWrapper class from HttpRequestMessage
        /// and content.
        /// </summary>
        public HttpRequestMessageWrapper(HttpRequestMessage httpRequest, string content)
        {
            if (httpRequest == null)
            {
                throw new ArgumentNullException("httpRequest");
            }

            this.CopyHeaders(httpRequest.Headers);
            this.CopyHeaders(httpRequest.GetContentHeaders());

            this.Content = content;
            this.Method = httpRequest.Method;
            this.RequestUri = httpRequest.RequestUri;
            if (httpRequest.Properties != null)
            {
                Properties = new Dictionary<string, object>();
                foreach (KeyValuePair<string, object> pair in httpRequest.Properties)
                {
                    this.Properties[pair.Key] = pair.Value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the HTTP method used by the HTTP request message.
        /// </summary>
        public HttpMethod Method { get; protected set; }

        /// <summary>
        /// Gets or sets the Uri used for the HTTP request.
        /// </summary>
        public Uri RequestUri { get; protected set; }

        /// <summary>
        /// Gets a set of properties for the HTTP request.
        /// </summary>
        public IDictionary<string, object> Properties { get; private set; }
    }
}
