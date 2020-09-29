// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class ElasticsearchDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticsearchDataFeedSource"/> class.
        /// </summary>
        /// <param name="host"> Host. </param>
        /// <param name="port"> Port. </param>
        /// <param name="authHeader"> Authorization header. </param>
        /// <param name="query"> Query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="host"/>, <paramref name="port"/>, <paramref name="authHeader"/>, or <paramref name="query"/> is null. </exception>
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
