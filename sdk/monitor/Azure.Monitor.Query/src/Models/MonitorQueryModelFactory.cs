// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query.Models
{
    /// <summary>
    /// Model factory that enables mocking for the MetricsQueryResult class.
    /// </summary>
    public static partial class MonitorQueryModelFactory
    {
        /// <summary> Enables the user to create an instance of a <see cref="MetricsQueryResult"/>. </summary>
        /// <param name="cost"> The integer value representing the relative cost of the query. </param>
        /// <param name="timespan"> The timespan for which the data was retrieved. Its value consists of two datetimes concatenated, separated by &apos;/&apos;.  This may be adjusted in the future and returned back from what was originally requested. </param>
        /// <param name="granularity"> The interval (window size) for which the metric data was returned in.  This may be adjusted in the future and returned back from what was originally requested.  This is not present if a metadata request was made. </param>
        /// <param name="namespace"> The namespace of the metrics being queried. </param>
        /// <param name="resourceRegion"> The region of the resource being queried for metrics. </param>
        /// <param name="metrics"> the value of the collection. </param>
        public static MetricsQueryResult MetricsQueryResult(int? cost, string timespan, TimeSpan? granularity, string @namespace, string resourceRegion, IEnumerable<MetricResult> metrics)
        {
            return new MetricsQueryResult(cost, timespan, granularity, @namespace, resourceRegion, metrics.ToArray());
        }

        /// <summary>
        /// make a metric result
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceType"></param>
        /// <param name="localizedName"></param>
        /// <param name="unit"></param>
        /// <param name="timeSeries"></param>
        /// <returns></returns>
        public static MetricResult MetricResult(string id, string resourceType, string localizedName, MetricUnit unit, IEnumerable<MetricTimeSeriesElement> timeSeries)
        {
            return new MetricResult(id, resourceType, new LocalizableString(localizedName), unit, timeSeries);
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <returns></returns>
        public static MetricTimeSeriesElement MetricTimeSeriesElement()
        {
            return new MetricTimeSeriesElement();
        }

        /// <summary> Enables the user to create an instance of a <see cref="LogsQueryResult"/>. </summary>
        /// <param name="allTables"> The list of tables, columns and rows. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        /// <param name="error"> Any object. </param>
        public static LogsQueryResult LogsQueryResult(IEnumerable<LogsTable> allTables, BinaryData statistics, BinaryData visualization, BinaryData error)
        {
            JsonElement statisticsJson = statistics.ToObjectFromJson<JsonElement>();
            JsonElement visualizationJson = visualization.ToObjectFromJson<JsonElement>();
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new LogsQueryResult(allTables.ToArray(), statisticsJson, visualizationJson, errorJson);
        }

        /// <summary> Enables the user to create an instance of a <see cref="LogsTableRow"/>. </summary>
        /// <param name="columns"> The list of columns. </param>
        /// <param name="values"> An object array representing the rows of the table. </param>
        /// <returns> A new <see cref="Models.LogsTableRow"/> instance for mocking. </returns>
        public static LogsTableRow LogsTableRow(IEnumerable<LogsTableColumn> columns, IEnumerable<object> values)
        {
            var columnsList = columns.ToArray();
            var columnMap = Models.LogsTableColumn.GetColumnMapFromColumns(columns);
            JsonElement row = JsonElementFromObject(values);
            return new LogsTableRow(columnMap, columnsList, row);
        }

        /// <summary> Enables the user to create an instance of a <see cref="LogsTable"/>. </summary>
        /// <param name="name"> The name of the table. </param>
        /// <param name="columns"> The list of columns. </param>
        /// <param name="rows"> The list of rows. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="rows"/> is <c>null</c>. </exception>
        public static LogsTable LogsTable(string name, IEnumerable<LogsTableColumn> columns, IEnumerable<LogsTableRow> rows)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var row in rows)
            {
                row._row.WriteTo(writer);
            }
            writer.WriteEndArray();
            writer.Flush();
            var doc = JsonDocument.Parse(stream.ToArray());
            var logsTableRow = doc.RootElement.Clone();
            return new LogsTable(name, columns, logsTableRow);
        }

        private static JsonElement JsonElementFromObject<TValue>(TValue value, JsonSerializerOptions options = default)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
            var doc = JsonDocument.Parse(bytes);
            return doc.RootElement.Clone();
        }
    }
}
