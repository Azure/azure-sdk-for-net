// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class AzureTableDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureTableDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString"> Azure Table connection string. </param>
        /// <param name="table"> Table name. </param>
        /// <param name="query"> Query script. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/>, <paramref name="table"/>, or <paramref name="query"/> is null. </exception>
        public AzureTableDataFeedSource(string connectionString, string table, string query)
            : base(DataFeedSourceType.AzureTable)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(table, nameof(table));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new AzureTableParameter(connectionString, table, query);
        }
    }
}
