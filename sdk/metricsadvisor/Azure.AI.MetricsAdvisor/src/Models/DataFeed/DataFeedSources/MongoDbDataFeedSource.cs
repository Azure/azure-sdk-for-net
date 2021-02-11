// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes a MongoDB data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class MongoDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="command">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="database"/>, or <paramref name="command"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="database"/>, or <paramref name="command"/> is empty.</exception>
        public MongoDbDataFeedSource(string connectionString, string database, string command)
            : base(DataFeedSourceType.MongoDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(command, nameof(command));

            Parameter = new MongoDBParameter(connectionString, database, command);

            ConnectionString = connectionString;
            Database = database;
            Command = command;
        }
        internal MongoDbDataFeedSource(MongoDBParameter parameter)
            : base(DataFeedSourceType.MongoDb)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            Database = parameter.Database;
            Command = parameter.Command;
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
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Command { get; }
    }
}
