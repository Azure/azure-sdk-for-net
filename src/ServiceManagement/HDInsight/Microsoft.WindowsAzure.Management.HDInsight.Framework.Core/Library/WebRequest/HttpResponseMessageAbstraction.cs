// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System.Net;

    /// <summary>
    /// Represents a response from an Http request.
    /// </summary>
    internal class HttpResponseMessageAbstraction : IHttpResponseMessageAbstraction
    {
        /// <summary>
        /// Initializes a new instance of the HttpResponseMessageAbstraction class.
        /// </summary>
        /// <param name="statusCode">
        /// The HttpStatusCode.
        /// </param>
        /// <param name="headers">
        /// The headers returned.
        /// </param>
        /// <param name="content">
        /// The content returned.
        /// </param>
        internal HttpResponseMessageAbstraction(HttpStatusCode statusCode, IHttpResponseHeadersAbstraction headers, string content)
        {
            this.StatusCode = statusCode;
            if (headers.IsNotNull())
            {
                this.Headers = headers;
            }
            else
            {
                this.Headers = new HttpResponseHeadersAbstraction();
            }
            this.Content = content;
        }

        /// <summary>
        /// Gets the status code of the request.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the Response Headers for the response.
        /// </summary>
        public IHttpResponseHeadersAbstraction Headers { get; private set; }

        /// <summary>
        /// Gets the content of the request.
        /// </summary>
        public string Content { get; private set; }
    }
}
