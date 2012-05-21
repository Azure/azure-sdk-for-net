/*
 * Copyright 2012 Microsoft Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    class HttpErrorHandler: MessageProcessingHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal HttpErrorHandler()
            : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="innerHandler">Inner HTTP handler</param>
        internal HttpErrorHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// Processes outhoing HTTP requests.
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Processed HTTP request</returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // We're not interested in outgoing requests; do nothing.
            return request;
        }

        /// <summary>
        /// Processes incoming HTTP responses.
        /// </summary>
        /// <param name="response">HTTP response</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Processed HTTP response</returns>
        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
        {
            if (!response.IsSuccessStatusCode)
                throw new AzureServiceException();
            return response;
        }
    }
}
