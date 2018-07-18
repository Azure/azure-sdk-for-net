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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microsoft.Azure.Graph.RBAC
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            _response = response;
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public string Request { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public HttpMethod Method { get; private set; }

        public Uri Uri { get; private set; }

        public bool IsPassThrough { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Save request
            if (request.Content == null)
            {
                Request = string.Empty;
            }
            else
            {
                Request = await request.Content.ReadAsStringAsync();
            }
            RequestHeaders = request.Headers;
            if (request.Content != null)
            {
                ContentHeaders = request.Content.Headers;
            }
            Method = request.Method;
            Uri = request.RequestUri;

            // Prepare response
            if (IsPassThrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                if (_response != null)
                {
                    return _response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(StatusCodeToReturn);
                    response.Content = new StringContent("");
                    return response;
                }
            }
        }
    }
}
