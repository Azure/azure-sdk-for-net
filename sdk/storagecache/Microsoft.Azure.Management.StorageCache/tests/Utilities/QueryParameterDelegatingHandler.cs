// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Utilities
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Query Parameter Delegating Handler.
    /// </summary>
    public class QueryParameterDelegatingHandler : RecordedDelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterDelegatingHandler"/> class.
        /// </summary>
        public QueryParameterDelegatingHandler()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterDelegatingHandler"/> class.
        /// </summary>
        /// <param name="httpResponse"></param>
        public QueryParameterDelegatingHandler(HttpResponseMessage httpResponse)
            : base(httpResponse)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterDelegatingHandler"/> class.
        /// </summary>
        /// <param name="useMockCache">true if mock cache is to be created, false otherwise.</param>
        public QueryParameterDelegatingHandler(bool useMockCache)
            : base()
        {
            this.UseMockCache = useMockCache;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use mock cache.
        /// </summary>
        public bool UseMockCache { get; set; }

        private string UseMockCacheString
        {
            get { return this.UseMockCache ? "true" : "false"; }
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // we'll use the UriBuilder to parse and modify the url
            var uriBuilder = new UriBuilder(request.RequestUri);

            // when the query string is empty, we simply want to set the appid query parameter
            if (string.IsNullOrEmpty(uriBuilder.Query))
            {
                uriBuilder.Query = $"UseMockCache={this.UseMockCacheString}";
            }

            // otherwise we want to append it
            else
            {
                uriBuilder.Query = $"{uriBuilder.Query}&UseMockCache={this.UseMockCacheString}";
            }

            // replace the uri in the request object
            request.RequestUri = uriBuilder.Uri;

            // make the request as normal
            return base.SendAsync(request, cancellationToken);

            // TODO - do not append every request, check if it exists first and then update accordingly.
        }
    }
}