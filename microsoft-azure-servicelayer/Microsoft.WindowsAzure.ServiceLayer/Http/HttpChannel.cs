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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// A channel for processing HTTP requests.
    /// </summary>
    internal class HttpChannel
    {
        /// <summary>
        /// Gets the HTTP processing handler.
        /// </summary>
        internal IHttpHandler Handler { get; private set; }

        /// <summary>
        /// Initializes the pipeline.
        /// </summary>
        /// <param name="handler">HTTP handler.</param>
        internal HttpChannel(IHttpHandler handler)
        {
            Debug.Assert(handler != null);
            Handler = handler;
        }

        /// <summary>
        /// Processes the HTTP request.
        /// </summary>
        /// <param name="request">HTTP request.</param>
        /// <returns>HTTP response.</returns>
        internal Task<HttpResponse> SendAsync(HttpRequest request, params Func<HttpResponse, HttpResponse>[] validators)
        {
            return Task.Factory
                .StartNew(() => Handler.ProcessRequest(request))
                .ContinueWith(t => CheckResponse(t.Result, validators));
        }

        /// <summary>
        /// Detects errors in HTTP responses and translates them into exceptios.
        /// </summary>
        /// <param name="response">Source HTTP response.</param>
        /// <param name="validators">Additional validators.</param>
        /// <returns>Processed HTTP response.</returns>
        private static HttpResponse CheckResponse(HttpResponse response, IEnumerable<Func<HttpResponse, HttpResponse>> validators)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new WindowsAzureHttpException(Resources.ErrorFailedRequest, response);
            }

            // Pass the response through all validators.
            foreach (Func<HttpResponse, HttpResponse> validator in validators)
            {
                response = validator(response);
            }
            return response;
        }

        /// <summary>
        /// Throws exceptions for response with no content.
        /// </summary>
        /// <param name="response">Source response.</param>
        /// <returns>Processed HTTP response.</returns>
        internal static HttpResponse CheckNoContent(HttpResponse response)
        {
            if (response.StatusCode == (int)System.Net.HttpStatusCode.NoContent || response.StatusCode == (int)System.Net.HttpStatusCode.ResetContent)
            {
                throw new WindowsAzureHttpException(Resources.ErrorNoContent, response);
            }
            return response;
        }
    }
}
