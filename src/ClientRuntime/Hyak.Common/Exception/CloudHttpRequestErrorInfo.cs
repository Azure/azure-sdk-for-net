// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Net.Http;
using Hyak.Common.Internals;

namespace Hyak.Common
{
    /// <summary>
    /// Describes HTTP requests associated with error conditions.
    /// </summary>
    public class CloudHttpRequestErrorInfo
        : CloudHttpErrorInfo
    {
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

        /// <summary>
        /// Initializes a new instance of the CloudHttpRequestErrorInfo class.
        /// </summary>
        protected CloudHttpRequestErrorInfo()
            : base()
        {
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new CloudHttpRequestErrorInfo from a HttpRequestMessage.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <returns>A CloudHttpRequestErrorInfo instance.</returns>
        public static CloudHttpRequestErrorInfo Create(HttpRequestMessage request)
        {
            return Create(request, request.Content.AsString());
        }

        /// <summary>
        /// Creates a new CloudHttpRequestErrorInfo from a HttpRequestMessage.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="content">
        /// The request content, which may be passed separately if the request
        /// has already been disposed.
        /// </param>
        /// <returns>A CloudHttpRequestErrorInfo instance.</returns>
        public static CloudHttpRequestErrorInfo Create(HttpRequestMessage request, string content)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            CloudHttpRequestErrorInfo info = new CloudHttpRequestErrorInfo();

            // Copy CloudHttpErrorInfo properties
            info.Content = content;
            info.Version = request.Version;
            info.CopyHeaders(request.Headers);
            info.CopyHeaders(request.GetContentHeaders());

            // Copy CloudHttpRequestErrorInfo properties
            info.Method = request.Method;
            info.RequestUri = request.RequestUri;
            if (request.Properties != null)
            {
                foreach (KeyValuePair<string, object> pair in request.Properties)
                {
                    info.Properties[pair.Key] = pair.Value;
                }
            }
            
            return info;
        }
    }
}
