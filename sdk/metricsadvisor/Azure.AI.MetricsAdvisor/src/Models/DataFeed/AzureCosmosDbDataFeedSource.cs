// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class AzureCosmosDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCosmosDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString"> Azure CosmosDB connection string. </param>
        /// <param name="sqlQuery"> Query script. </param>
        /// <param name="database"> Database name. </param>
        /// <param name="collectionId"> Collection id. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/>, <paramref name="sqlQuery"/>, <paramref name="database"/>, or <paramref name="collectionId"/> is null. </exception>
        public AzureCosmosDbDataFeedSource(string connectionString, string sqlQuery, string database, string collectionId)
            : base(DataFeedSourceType.AzureCosmosDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(sqlQuery, nameof(sqlQuery));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));

            Parameter = new AzureCosmosDBParameter(connectionString, sqlQuery, database, collectionId);
        }
    }
}
