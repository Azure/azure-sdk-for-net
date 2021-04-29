// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Options for <see cref="LogsClient.QueryAsync"/> and <see cref="LogsBatchQuery.AddQuery"/> methods.
    /// </summary>
    public class LogsQueryOptions
    {
        /// <summary>
        /// Gets or sets the value indicating the service timeout for the query. Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to include query execution statistics as part of the response.
        /// Statistics can be retrieved via the <see cref="LogsQueryResult.Statistics"/> property.
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeStatistics { get; set; }
    }
}