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
        /// <param name="authorizationHeader">The value of the authorization header.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="host"/>, <paramref name="port"/>, <paramref name="authorizationHeader"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="host"/>, <paramref name="port"/>, <paramref name="authorizationHeader"/>, or <paramref name="query"/> is empty.</exception>
        public ElasticsearchDataFeedSource(string host, string port, string authorizationHeader, string query)
            : base(DataFeedSourceType.Elasticsearch)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNullOrEmpty(port, nameof(port));
            Argument.AssertNotNullOrEmpty(authorizationHeader, nameof(authorizationHeader));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new ElasticsearchParameter(host, port, authorizationHeader, query);

            Host = host;
            Port = port;
            AuthorizationHeader = authorizationHeader;
            Query = query;
        }

        internal ElasticsearchDataFeedSource(ElasticsearchParameter parameter)
            : base(DataFeedSourceType.Elasticsearch)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            Host = parameter.Host;
            Port = parameter.Port;
            AuthorizationHeader = parameter.AuthHeader;
            Query = parameter.Query;
        }

        /// <summary>
        /// The endpoint URL.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// The port.
        /// </summary>
        public string Port { get; }

        /// <summary>
        /// The value of the authorization header.
        /// </summary>
        public string AuthorizationHeader { get; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; }
    }
}
