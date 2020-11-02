// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an InfluxDB data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class InfluxDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfluxDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="username">The access username.</param>
        /// <param name="password">The access password.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="database"/>, <paramref name="username"/>, <paramref name="password"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="database"/>, <paramref name="username"/>, <paramref name="password"/>, or <paramref name="query"/> is empty.</exception>
        public InfluxDbDataFeedSource(string connectionString, string database, string username, string password, string query)
            : base(DataFeedSourceType.InfluxDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(username, nameof(username));
            Argument.AssertNotNullOrEmpty(password, nameof(password));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new InfluxDBParameter(connectionString, database, username, password, query);

            ConnectionString = connectionString;
            Database = database;
            Username = username;
            Password = password;
            Query = query;
        }

        internal InfluxDbDataFeedSource(InfluxDBParameter parameter)
            : base(DataFeedSourceType.InfluxDb)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            Database = parameter.Database;
            Username = parameter.UserName;
            Password = parameter.Password;
            Query = parameter.Query;
        }

        /// <summary>
        /// The connection string.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Database { get; }

        /// <summary>
        /// The access username.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// The access password.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; }
    }
}
