// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Elasticsearch data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class ElasticsearchDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticsearchDataFeedSource"/> class.
        /// </summary>
        /// <param name="host">The endpoint URL.</param>
        /// <param name="port">The port.</param>
        /// <param name="authHeader">The value of the Authorization header.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="host"/>, <paramref name="port"/>, <paramref name="authHeader"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="host"/>, <paramref name="port"/>, <paramref name="authHeader"/>, or <paramref name="query"/> is empty.</exception>
        public ElasticsearchDataFeedSource(string host, string port, string authHeader, string query)
            : base(DataFeedSourceType.Elasticsearch)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNullOrEmpty(port, nameof(port));
            Argument.AssertNotNullOrEmpty(authHeader, nameof(authHeader));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new ElasticsearchParameter(host, port, authHeader, query);
        }
    }
}
