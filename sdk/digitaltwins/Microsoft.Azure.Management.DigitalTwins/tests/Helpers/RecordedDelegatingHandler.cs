// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalTwins.Tests.Helpers
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _response;
        private int _counter;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
            : this()
        {
            _response = response;
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public HttpStatusCode SubsequentStatusCodeToReturn { get; set; }

        public string Request { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public HttpMethod Method { get; private set; }

        public Uri Uri { get; private set; }

        public bool IsPassthrough { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _counter++;

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
            if (IsPassthrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            if (_response != null && _counter == 1)
            {
                return _response;
            }

            var statusCode = StatusCodeToReturn;
            if (_counter > 1)
            {
                statusCode = SubsequentStatusCodeToReturn;
            }
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(""),
            };
            return response;
        }
    }
}
