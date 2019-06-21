// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Maps.Tests.Helpers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class RecordedDelegatingHandler : DelegatingHandler
    {
        private HttpResponseMessage _response;

        public RecordedDelegatingHandler()
        {
            this.StatusCodeToReturn = HttpStatusCode.Created;
            this.SubsequentStatusCodeToReturn = this.StatusCodeToReturn;
        }

        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            this.StatusCodeToReturn = HttpStatusCode.Created;
            this.SubsequentStatusCodeToReturn = this.StatusCodeToReturn;
            this._response = response;
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
            this.counter++;

            // Save request
            if (request.Content == null)
            {
                this.Request = string.Empty;
            }
            else
            {
                this.Request = await request.Content.ReadAsStringAsync();
            }
            this.RequestHeaders = request.Headers;
            if (request.Content != null)
            {
                this.ContentHeaders = request.Content.Headers;
            }
            this.Method = request.Method;
            this.Uri = request.RequestUri;

            // Prepare response
            if (this.IsPassThrough)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                if (this._response != null && this.counter == 1)
                {
                    return this._response;
                }
                else
                {
                    var statusCode = this.StatusCodeToReturn;
                    if (this.counter > 1)
                    {
                        statusCode = this.SubsequentStatusCodeToReturn;
                    }

                    var response = new HttpResponseMessage(statusCode) { Content = new StringContent(string.Empty) };
                    return response;
                }
            }
        }
    }
}
