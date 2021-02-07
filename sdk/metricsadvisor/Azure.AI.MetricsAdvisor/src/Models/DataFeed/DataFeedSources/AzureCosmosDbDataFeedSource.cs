// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Cosmos DB data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureCosmosDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCosmosDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Cosmos DB service.</param>
        /// <param name="sqlQuery">The SQL query to retrieve the data to be ingested.</param>
        /// <param name="database">The name of the database.</param>
        /// <param name="collectionId">The collection ID.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="sqlQuery"/>, <paramref name="database"/>, or <paramref name="collectionId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="sqlQuery"/>, <paramref name="database"/>, or <paramref name="collectionId"/> is empty.</exception>
        public AzureCosmosDbDataFeedSource(string connectionString, string sqlQuery, string database, string collectionId)
            : base(DataFeedSourceType.AzureCosmosDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(sqlQuery, nameof(sqlQuery));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));

            Parameter = new AzureCosmosDBParameter(connectionString, sqlQuery, database, collectionId);

            ConnectionString = connectionString;
            SqlQuery = sqlQuery;
            Database = database;
            CollectionId = collectionId;
        }

        internal AzureCosmosDbDataFeedSource(AzureCosmosDBParameter parameter)
            : base(DataFeedSourceType.AzureCosmosDb)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            SqlQuery = parameter.SqlQuery;
            Database = parameter.Database;
            CollectionId = parameter.CollectionId;
        }

        /// <summary>
        /// The connection string.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The SQL query to retrieve the data to be ingested.
        /// </summary>
        public string SqlQuery { get; }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Database { get; }

        /// <summary>
        /// The collection ID.
        /// </summary>
        public string CollectionId { get; }
    }
}
