// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpRecorder.Tests
{
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        public RecordedDelegatingHandler()
        {
            StatusCodeToReturn = HttpStatusCode.Created;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            StatusCodeToReturn = HttpStatusCode.Created;
            Response = response;
        }

        public HttpStatusCode StatusCodeToReturn { get; set; }

        public string Request { get; protected set; }

        protected HttpResponseMessage Response { get; set; }

        public HttpRequestHeaders RequestHeaders { get; protected set; }

        public HttpContentHeaders ContentHeaders { get; protected set; }

        public HttpMethod Method { get; protected set; }

        public Uri Uri { get; protected set; }

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
                if (Response != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(Response.StatusCode);
                    response.RequestMessage = new HttpRequestMessage(request.Method, request.RequestUri);
                    foreach (var header in request.Headers)
                    {
                        response.RequestMessage.Headers.Add(header.Key, header.Value);
                    }
                    response.RequestMessage.Content = request.Content;
                    response.Content = Response.Content;
                    foreach (var h in Response.Headers)
                    {
                        response.Headers.Add(h.Key, h.Value);
                    }
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(StatusCodeToReturn);
                    response.RequestMessage = new HttpRequestMessage(request.Method, request.RequestUri);
                    response.RequestMessage.Content = request.Content;
                    response.Content = new StringContent("");
                    return response;
                }
            }
        }
    }
}
