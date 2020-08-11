// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.StorageCache.Tests.Utilities
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic delegation handler.
    /// </summary>
    public class RecordedDelegatingHandler : DelegatingHandler
    {
        // Default response.
        private HttpResponseMessage response;

        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordedDelegatingHandler"/> class.
        /// </summary>
        public RecordedDelegatingHandler()
        {
            this.StatusCodeToReturn = HttpStatusCode.Created;
            this.SubsequentStatusCodeToReturn = this.StatusCodeToReturn;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordedDelegatingHandler"/> class.
        /// </summary>
        /// <param name="response">Response returned in all cases.</param>
        public RecordedDelegatingHandler(HttpResponseMessage response)
        {
            this.StatusCodeToReturn = HttpStatusCode.Created;
            this.SubsequentStatusCodeToReturn = this.StatusCodeToReturn;
            this.response = response;
        }

        /// <summary>
        /// Gets or sets HTTP status code.
        /// </summary>
        public HttpStatusCode StatusCodeToReturn { get; set; }

        /// <summary>
        /// Gets or sets subsequent HTTP status code.
        /// </summary>
        public HttpStatusCode SubsequentStatusCodeToReturn { get; set; }

        /// <summary>
        /// Gets string representation of a HTTP request message.
        /// </summary>
        public string Request { get; private set; }

        /// <summary>
        /// Gets the value of the request headers collection.
        /// </summary>
        public HttpRequestHeaders RequestHeaders { get; private set; }

        /// <summary>
        /// Gets the value of the content headers collection.
        /// </summary>
        public HttpContentHeaders ContentHeaders { get; private set; }

        /// <summary>
        /// Gets the a HTTP method.
        /// </summary>
        public HttpMethod Method { get; private set; }

        /// <summary>
        /// Gets URI.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether to IsPassThrough.
        /// </summary>
        public bool IsPassThrough { get; set; }

        /// <inheritdoc/>
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
                if (this.response != null && this.counter == 1)
                {
                    return this.response;
                }
                else
                {
                    var statusCode = this.StatusCodeToReturn;
                    if (this.counter > 1)
                    {
                        statusCode = this.SubsequentStatusCodeToReturn;
                    }

                    HttpResponseMessage response = new HttpResponseMessage(statusCode);
                    response.Content = new StringContent(string.Empty);
                    return response;
                }
            }
        }
    }
}
