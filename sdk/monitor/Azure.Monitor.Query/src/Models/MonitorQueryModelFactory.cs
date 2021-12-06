// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Monitor.Query.Models;

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
        public static LogsQueryResult LogsQueryResult(IReadOnlyList<LogsTable> allTables, BinaryData statistics, BinaryData visualization, BinaryData error)
        {
            JsonElement statisticsJson = statistics.ToObjectFromJson<JsonElement>();
            JsonElement visualizationJson = visualization.ToObjectFromJson<JsonElement>();
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new LogsQueryResult(allTables, statisticsJson, visualizationJson, errorJson);
        }

        /// <summary> Initializes a new instance of LogsTableRow. </summary>
        /// /// <param name="columns"> The list of columns. </param>
        /// <param name="values"> An object array representing the rows of the table. </param>
        /// <returns> A new <see cref="Models.LogsTableRow"/> instance for mocking. </returns>
        public static LogsTableRow LogsTableRow(IEnumerable<LogsTableColumn> columns, IEnumerable<object> values)
        {
            var columnsList = columns.ToArray();
            var columnMap = Models.LogsTableColumn.GetColumnMapFromColumns(columns);
            JsonElement row = JsonElementFromObject(values);
            return new LogsTableRow(columnMap, columnsList, row);
        }

        /// <summary> Initializes a new instance of LogsTable. </summary>
        /// <param name="name"> The name of the table. </param>
        /// <param name="columns"> The list of columns. </param>
        /// <param name="rows"> The list of rows. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="rows"/> is null. </exception>
        public static LogsTable LogsTable(string name, IEnumerable<LogsTableColumn> columns, IEnumerable<LogsTableRow> rows)
        {
            JsonElement row = JsonElementFromObject(rows);
            return new LogsTable(name, columns, row);
        }

        private static JsonElement JsonElementFromObject<TValue>(TValue value, JsonSerializerOptions options = default)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
            var doc = JsonDocument.Parse(bytes);
            return doc.RootElement.Clone();
        }
    }
}
