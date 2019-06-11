// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceGraph.Tests.Helpers
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.OK;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.OK;

            _response = response;
            if (null == _response.Content)
            {
                _response.Content = new StringContent(string.Empty);
            }
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
            Request = null == request.Content ? string.Empty : await request.Content.ReadAsStringAsync();
            RequestHeaders = request.Headers;
            if (null != request.Content)
            {
                ContentHeaders = request.Content.Headers;
            }
            Method = request.Method;
            Uri = request.RequestUri;

            if (IsPassThrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            return _response ?? new HttpResponseMessage(StatusCodeToReturn) { Content = new StringContent("") };
        }
    }
}
