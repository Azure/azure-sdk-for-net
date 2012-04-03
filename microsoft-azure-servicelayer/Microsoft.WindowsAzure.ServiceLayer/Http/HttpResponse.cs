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
using System.Diagnostics;

using NetHttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Represents an HTTP response message.
    /// server.
    /// </summary>
    public sealed class HttpResponse
    {
        /// <summary>
        /// Gets the request that lead to this response.
        /// </summary>
        public HttpRequest Request { get; private set; }

        /// <summary>
        /// Gets the status code of the HTTP response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Tells whether the HTTP response was successful.
        /// </summary>
        public bool IsSuccessStatusCode { get { return StatusCode >= 200 && StatusCode < 299; } }

        /// <summary>
        /// Gets or sets the reason phrase which typically is sent by servers
        /// together with the status code.
        /// </summary>
        public string ReasonPhrase { get; set; }

        /// <summary>
        /// Gets or sets the content of the response.
        /// </summary>
        public HttpContent Content { get; set; }

        /// <summary>
        /// Gets the collection of HTTP response headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Initializes the response object.
        /// </summary>
        /// <param name="originalRequest">Request that initiated the response.</param>
        /// <param name="statusCode">Status code of the HTTP response.</param>
        public HttpResponse(HttpRequest originalRequest, int statusCode)
        {
            Validator.ArgumentIsNotNull("originalRequest", originalRequest);
            Validator.ArgumentIsValidEnumValue<System.Net.HttpStatusCode>("statusCode", statusCode);

            Request = originalRequest;
            StatusCode = statusCode;
            Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes the response object.
        /// </summary>
        /// <param name="originalRequest">Request that initiated the response.</param>
        /// <param name="response">.Net HTTP response.</param>
        internal HttpResponse(HttpRequest originalRequest, NetHttpResponseMessage response)
        {
            Debug.Assert(originalRequest != null);
            Debug.Assert(response != null);

            Request = originalRequest;
            StatusCode = (int)response.StatusCode;
            ReasonPhrase = response.ReasonPhrase;
            Content = HttpContent.CreateFromResponse(response);
            Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<string, IEnumerable<string>> item in response.Headers)
            {
                string valueString = string.Join(string.Empty, item.Value);
                Headers.Add(item.Key, valueString);
            }
        }
    }
}
