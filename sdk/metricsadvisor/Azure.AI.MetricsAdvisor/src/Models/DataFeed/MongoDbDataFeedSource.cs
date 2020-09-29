// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class MongoDbDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString"> MongoDB connection string. </param>
        /// <param name="database"> Database name. </param>
        /// <param name="command"> Query script. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/>, <paramref name="database"/>, or <paramref name="command"/> is null. </exception>
        public MongoDbDataFeedSource(string connectionString, string database, string command)
            : base(DataFeedSourceType.MongoDb)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(database, nameof(database));
            Argument.AssertNotNullOrEmpty(command, nameof(command));

            Parameter = new MongoDBParameter(connectionString, database, command);
        }
    }
}
