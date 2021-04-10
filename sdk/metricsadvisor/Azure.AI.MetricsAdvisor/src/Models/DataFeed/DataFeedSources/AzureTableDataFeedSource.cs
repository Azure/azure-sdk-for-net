// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Table data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureTableDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureTableDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Storage Account.</param>
        /// <param name="table">The name of the Table.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="table"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="table"/>, or <paramref name="query"/> is empty.</exception>
        public AzureTableDataFeedSource(string connectionString, string table, string query)
            : base(DataFeedSourceType.AzureTable)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(table, nameof(table));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new AzureTableParameter(connectionString, table, query);

            ConnectionString = connectionString;
            Table = table;
            Query = query;
        }

        internal AzureTableDataFeedSource(AzureTableParameter parameter)
            : base(DataFeedSourceType.AzureTable)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            Table = parameter.Table;
            Query = parameter.Query;
        }

        /// <summary>
        /// The connection string for authenticating to the Azure Storage Account.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The name of the Table.
        /// </summary>
        public string Table { get; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; }
    }
}
