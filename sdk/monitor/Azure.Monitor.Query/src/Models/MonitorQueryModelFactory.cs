// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Monitor.Query.Models
{
    /// <summary>
    /// Model factory that enables mocking for the MetricsQueryResult class.
    /// </summary>
    public static partial class MonitorQueryModelFactory
    {
        /// <summary> Initializes a new instance of MetricsQueryResult. </summary>
        /// <param name="cost"> The integer value representing the relative cost of the query. </param>
        /// <param name="timespan"> The timespan for which the data was retrieved. Its value consists of two datetimes concatenated, separated by &apos;/&apos;.  This may be adjusted in the future and returned back from what was originally requested. </param>
        /// <param name="granularity"> The interval (window size) for which the metric data was returned in.  This may be adjusted in the future and returned back from what was originally requested.  This is not present if a metadata request was made. </param>
        /// <param name="namespace"> The namespace of the metrics being queried. </param>
        /// <param name="resourceRegion"> The region of the resource being queried for metrics. </param>
        /// <param name="metrics"> the value of the collection. </param>
        public static MetricsQueryResult MetricsQueryResult(int? cost, string timespan, TimeSpan? granularity, string @namespace, string resourceRegion, IReadOnlyList<MetricResult> metrics)
        {
            return new MetricsQueryResult(cost, timespan, granularity, @namespace, resourceRegion, metrics);
        }

        /// <summary> Initializes a new instance of LogsQueryResult. </summary>
        /// <param name="allTables"> The list of tables, columns and rows. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        /// <param name="error"> Any object. </param>
        public static LogsQueryResult LogsQueryResult(IReadOnlyList<LogsTable> allTables, JsonElement statistics, BinaryData visualization, BinaryData error)
        {
            JsonElement visualizationJson = JsonSerializer.Serialize<JsonElement>(visualization.ToObject());
            return new LogsQueryResult(allTables, statistics, visualization, error);
        }
    }
}
