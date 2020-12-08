// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an HTTP Request data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class HttpRequestDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestDataFeedSource"/> class.
        /// </summary>
        /// <param name="url">The HTTP URL.</param>
        /// <param name="httpHeader">The HTTP header.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="payload">The HTTP request body.</param>
        /// <exception cref="ArgumentNullException"><paramref name="url"/>, <paramref name="httpHeader"/>, <paramref name="httpMethod"/>, or <paramref name="payload"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="httpHeader"/>, <paramref name="httpMethod"/>, or <paramref name="payload"/> is empty.</exception>
        public HttpRequestDataFeedSource(Uri url, string httpHeader, string httpMethod, string payload)
            : base(DataFeedSourceType.HttpRequest)
        {
            Argument.AssertNotNull(url, nameof(url));
            Argument.AssertNotNullOrEmpty(httpHeader, nameof(httpHeader));
            Argument.AssertNotNullOrEmpty(httpMethod, nameof(httpMethod));
            Argument.AssertNotNullOrEmpty(payload, nameof(payload));

            Parameter = new HttpRequestParameter(url.AbsoluteUri, httpHeader, httpMethod, payload);
        }
    }
}
