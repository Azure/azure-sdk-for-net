// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes a MySQL data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class MySqlDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="query"/> is empty.</exception>
        public MySqlDataFeedSource(string connectionString, string query)
            : base(DataFeedSourceType.MySql)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new SqlSourceParameter(connectionString, query);

            ConnectionString = connectionString;
            Query = query;
        }

        internal MySqlDataFeedSource(SqlSourceParameter parameter)
            : base(DataFeedSourceType.MySql)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            Query = parameter.Query;
        }

        /// <summary>
        /// The connection string.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; }
    }
}
