//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NetHttpMethod = System.Net.Http.HttpMethod;
using NetHttpRequestMessage = System.Net.Http.HttpRequestMessage;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Represents an HTTP request.
    /// </summary>
    public sealed class HttpRequest
    {
        private NetHttpMethod _method;                      // HTTP method verb.

        /// <summary>
        /// Gets the URI used for the HTTP request.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the HTTP method used for HTTP request.
        /// </summary>
        public string Method
        {
            get { return _method.ToString(); }
        }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Gets the content of the request.
        /// </summary>
        public HttpContent Content { get; set; }

        /// <summary>
        /// Initializes the request.
        /// </summary>
        /// <param name="method">The request's HTTP method.</param>
        /// <param name="uri">The request's URI.</param>
        public HttpRequest(string method, Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            Uri = uri;
            _method = new NetHttpMethod(method);
            Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates a .Net request and populates it with all data.
        /// </summary>
        /// <returns>.Net request.</returns>
        internal NetHttpRequestMessage CreateNetRequest()
        {
            NetHttpRequestMessage request = new NetHttpRequestMessage(_method, Uri);

            // Populate headers.
            foreach (KeyValuePair<string, string> headerItem in Headers)
            {
                request.Headers.Add(headerItem.Key, headerItem.Value);
            }

            // Populate content.
            if (Content != null)
            {
                Content.SubmitTo(request);
            }
            return request;
        }
    }
}
