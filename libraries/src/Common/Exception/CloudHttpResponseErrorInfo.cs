//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Describes HTTP responses associated with error conditions.
    /// </summary>
    public class CloudHttpResponseErrorInfo
        : CloudHttpErrorInfo
    {
        /// <summary>
        /// Gets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode StatusCode { get; protected set; }

        /// <summary>
        /// Gets the reason phrase which typically is sent by servers together
        /// with the status code.
        /// </summary>
        public string ReasonPhrase { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the CloudHttpResponseErrorInfo class.
        /// </summary>
        protected CloudHttpResponseErrorInfo()
            : base()
        {
        }

        /// <summary>
        /// Creates a new CloudHttpResponseErrorInfo from a HttpResponseMessage.
        /// </summary>
        /// <param name="response">The resposne message.</param>
        /// <returns>A CloudHttpResponseErrorInfo instance.</returns>
        public static CloudHttpResponseErrorInfo Create(HttpResponseMessage response)
        {
            return Create(response, response.Content.AsString());
        }

        /// <summary>
        /// Creates a new CloudHttpResponseErrorInfo from a HttpResponseMessage.
        /// </summary>
        /// <param name="response">The resposne message.</param>
        /// <param name="content">
        /// The response content, which may be passed separately if the
        /// response has already been disposed.
        /// </param>
        /// <returns>A CloudHttpResponseErrorInfo instance.</returns>
        public static CloudHttpResponseErrorInfo Create(HttpResponseMessage response, string content)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            CloudHttpResponseErrorInfo info = new CloudHttpResponseErrorInfo();

            // Copy CloudHttpErrorInfo properties
            info.Content = content;
            info.Version = response.Version;
            info.CopyHeaders(response.Headers);
            info.CopyHeaders(response.GetContentHeaders());

            // Copy CloudHttpResponseErrorInfo properties
            info.StatusCode = response.StatusCode;
            info.ReasonPhrase = response.ReasonPhrase;
            
            return info;
        }
    }
}
