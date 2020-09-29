// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class InfluxDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfluxDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString"> InfluxDB connection string. </param>
        /// <param name="database"> Database name. </param>
        /// <param name="userName"> Database access user. </param>
        /// <param name="password"> Database access password. </param>
        /// <param name="query"> Query script. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/>, <paramref name="database"/>, <paramref name="userName"/>, <paramref name="password"/>, or <paramref name="query"/> is null. </exception>
        public InfluxDbDataFeedSource(string connectionString, string database, string userName, string password, string query)
            : base(DataFeedSourceType.InfluxDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(userName, nameof(userName));
            Argument.AssertNotNullOrEmpty(password, nameof(password));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new InfluxDBParameter(connectionString, database, userName, password, query);
        }
    }
}
