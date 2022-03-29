// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Cosmos DB data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureCosmosDbDataFeedSource : DataFeedSource
    {
        private string _connectionString;

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
            : base(DataFeedSourceKind.AzureCosmosDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(sqlQuery, nameof(sqlQuery));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));

            ConnectionString = connectionString;
            SqlQuery = sqlQuery;
            Database = database;
            CollectionId = collectionId;
        }

        internal AzureCosmosDbDataFeedSource(AzureCosmosDBParameter parameter)
            : base(DataFeedSourceKind.AzureCosmosDb)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            SqlQuery = parameter.SqlQuery;
            Database = parameter.Database;
            CollectionId = parameter.CollectionId;
        }

        /// <summary>
        /// The SQL query to retrieve the data to be ingested.
        /// </summary>
        public string SqlQuery { get; set; }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// The collection ID.
        /// </summary>
        public string CollectionId { get; set; }

        /// <summary>
        /// The connection string.
        /// </summary>
        internal string ConnectionString
        {
            get => Volatile.Read(ref _connectionString);
            private set => Volatile.Write(ref _connectionString, value);
        }

        /// <summary>
        /// Updates the connection string.
        /// </summary>
        /// <param name="connectionString">The new connection string to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> is empty.</exception>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }
    }
}
