// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("QueryResults")]
    public partial class LogsQueryResult
    {
        [CodeGenMember("Statistics")]
        private readonly JsonElement _statistics;

        // TODO: Handle not found
        /// <summary>
        /// Returns the primary result of the query.
        /// </summary>
        public LogsQueryResultTable PrimaryTable => Tables.Single(t => t.Name == "PrimaryResult");

        /// <summary>
        /// Returns the query statistics if the <see cref="LogsQueryOptions.IncludeStatistics"/> is set to <c>true</c>.
        /// </summary>
        public BinaryData Statistics => _statistics.ValueKind == JsonValueKind.Undefined ? null : new BinaryData(_statistics.ToString());

        internal ErrorDetails Error { get; }
    }
}