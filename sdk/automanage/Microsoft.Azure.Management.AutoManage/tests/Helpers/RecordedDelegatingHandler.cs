﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Automanage.Models;

namespace Automanage.Tests.Helpers
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.OK;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.OK;
            SubsequentStatusCodeToReturn = StatusCodeToReturn;
            _response = response;
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public HttpStatusCode SubsequentStatusCodeToReturn { get; set; }

        public string Request { get; private set; }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        public HttpContentHeaders ContentHeaders { get; private set; }

        public HttpMethod Method { get; private set; }

        public Uri Uri { get; private set; }

        public bool IsPassThrough { get; set; }

        private int counter;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            counter++;
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
                // Generate mock response for unit tests
                if (_response != null && counter == 1)
                {
                    return _response;
                }
                else
                {
                    var statusCode = StatusCodeToReturn;
                    if (counter > 1)
                        statusCode = SubsequentStatusCodeToReturn;
                    HttpResponseMessage response = new HttpResponseMessage(statusCode);
                    response.Content = new StringContent("");
                    return response;
                }
            }
        }
    }
}