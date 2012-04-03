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
using System.Text;
using System.Threading.Tasks;

using NetHttpClient = System.Net.Http.HttpClient;
using NetHttpRequestMessage = System.Net.Http.HttpRequestMessage;
using NetHttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Default HTTP handler.
    /// </summary>
    /// <remarks>The class implements the default processing of HTTP requests.
    /// It is used as a final point in the chain of handlers to communicate
    /// with the server.</remarks>
    public sealed class HttpDefaultHandler: IHttpHandler
    {
        private NetHttpClient _client;                      // HTTP client used for communication with the server.

        /// <summary>
        /// Initializes the handler.
        /// </summary>
        public HttpDefaultHandler()
        {
            _client = new NetHttpClient();
        }

        /// <summary>
        /// Processes the HTTP request.
        /// </summary>
        /// <param name="request">HTTP request.</param>
        /// <returns>HTTP response.</returns>
        HttpResponse IHttpHandler.ProcessRequest(HttpRequest request)
        {
            Validator.ArgumentIsNotNull("request", request);

            NetHttpRequestMessage netRequest = request.CreateNetRequest();
            return _client.SendAsync(netRequest)
                .ContinueWith<HttpResponse>(t => new HttpResponse(request, t.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;
        }
    }
}
