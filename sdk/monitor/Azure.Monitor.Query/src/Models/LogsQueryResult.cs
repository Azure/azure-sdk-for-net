// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("QueryResults")]
    public partial class LogsQueryResult
    {
        // TODO: Handle not found
        /// <summary>
        /// Returns the primary result of the query.
        /// </summary>
        public LogsQueryResultTable PrimaryTable => Tables.Single(t => t.Name == "PrimaryResult");

#pragma warning disable AZC0014
        /// <summary>
        /// Returns the query statistics if the <see cref="LogsQueryOptions.IncludeStatistics"/> is set to <c>true</c>.
        /// </summary>
        public JsonElement Statistics { get; }
#pragma warning restore AZC0014

        internal ErrorDetails Error { get; }
    }
}