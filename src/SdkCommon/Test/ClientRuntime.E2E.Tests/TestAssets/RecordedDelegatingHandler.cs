﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.E2E.Tests.TestAssets
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Delegating handler for test purpose
    /// </summary>
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            _response = response;
        }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public bool IsPassThrough { get; set; }

        public HttpMethod Method { get; private set; }

        public string RequestContent { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public Uri Uri { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            // Save request
            if (request.Content == null)
            {
                RequestContent = string.Empty;
            }
            else
            {
                RequestContent = await request.Content.ReadAsStringAsync();
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

            if (_response != null)
            {
                return _response;
            }
            else
            {
                var response = new HttpResponseMessage(StatusCodeToReturn);
                response.Content = new StringContent("");
                return response;
            }
        }
    }
}
