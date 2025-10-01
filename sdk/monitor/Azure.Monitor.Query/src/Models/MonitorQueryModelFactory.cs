// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query.Models
{
    /// <summary>
    /// Model factory that enables mocking for public model types.
    /// </summary>
    public static partial class MonitorQueryModelFactory
    {
        private const string TrimmingUnsafeMessage = "This method uses JSON serialization that is incompatible with trimming.";

        /// <summary>
        /// Creates an instance of <see cref="MetricsQueryResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="cost"> The integer value representing the relative cost of the query. </param>
        /// <param name="timespan"> The timespan for which the data was retrieved. Its value consists of two datetimes concatenated, separated by &apos;/&apos;.  This may be adjusted in the future and returned back from what was originally requested. </param>
        /// <param name="granularity"> The interval (window size) for which the metric data was returned in. This may be adjusted in the future and returned back from what was originally requested.  This is not present if a metadata request was made. </param>
        /// <param name="namespace"> The namespace of the metrics being queried. </param>
        /// <param name="resourceRegion"> The region of the resource being queried for metrics. </param>
        /// <param name="metrics"> The value of the collection. </param>
        public static MetricsQueryResult MetricsQueryResult(int? cost, string timespan, TimeSpan? granularity, string @namespace, string resourceRegion, IReadOnlyList<MetricResult> metrics)
        {
            return new MetricsQueryResult(cost, timespan, granularity, @namespace, resourceRegion, metrics.ToArray(), serializedAdditionalRawData: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.MetricResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="id"> The metric ID. </param>
        /// <param name="resourceType"> The resource type of the metric resource. </param>
        /// <param name="name"> The name of the metric. </param>
        /// <param name="unit"> The unit of the metric. </param>
        /// <param name="timeSeries"> The time series returned when a data query is performed. </param>
        public static MetricResult MetricResult(string id, string resourceType, string name, MetricUnit unit, IEnumerable<MetricTimeSeriesElement> timeSeries)
        {
            return new MetricResult(id, resourceType, new LocalizableString(name), unit, timeSeries);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.MetricTimeSeriesElement"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="metadataValues"> A dictionary comprised of metric metadata values. </param>
        /// <param name="values"> A list of <see cref="Models.MetricValue"/> elements. </param>
        public static MetricTimeSeriesElement MetricTimeSeriesElement(IReadOnlyDictionary<string, string> metadataValues, IEnumerable<MetricValue> values)
        {
            var metadataValueList = new List<MetadataValue>();
            foreach (var value in metadataValues)
            {
                var metadataValue = new MetadataValue(new LocalizableString(value.Key), value.Value, serializedAdditionalRawData: null);
                metadataValueList.Add(metadataValue);
            }
            return new MetricTimeSeriesElement(metadataValueList, values.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.MetricValue"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="timeStamp"> The timestamp for the metric value in ISO 8601 format. </param>
        /// <param name="average"> The average value in the time range. </param>
        /// <param name="minimum"> The least value in the time range. </param>
        /// <param name="maximum"> The greatest value in the time range. </param>
        /// <param name="total"> The sum of all of the values in the time range. </param>
        /// <param name="count"> The number of samples in the time range. Can be used to determine the number of values that contributed to the average value. </param>
        public static MetricValue MetricValue(DateTimeOffset timeStamp = default, double? average = null, double? minimum = null, double? maximum = null, double? total = null, double? count = null)
        {
            return new MetricValue(timeStamp, average, minimum, maximum, total, count, serializedAdditionalRawData: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.LogsQueryResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="allTables"> The list of tables, columns, and rows. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        /// <param name="error"> Any object. </param>
        [RequiresUnreferencedCode(TrimmingUnsafeMessage)]
        [RequiresDynamicCode(TrimmingUnsafeMessage)]
        public static LogsQueryResult LogsQueryResult(IReadOnlyList<LogsTable> allTables, BinaryData statistics, BinaryData visualization, BinaryData error)
        {
            JsonElement statisticsJson = statistics.ToObjectFromJson<JsonElement>();
            JsonElement visualizationJson = visualization.ToObjectFromJson<JsonElement>();
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new LogsQueryResult(allTables.ToArray(), statisticsJson, visualizationJson, errorJson, serializedAdditionalRawData: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.LogsTableRow"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="columns"> The list of columns. </param>
        /// <param name="values"> An object array representing the rows of the table. </param>
        [RequiresUnreferencedCode(TrimmingUnsafeMessage)]
        [RequiresDynamicCode(TrimmingUnsafeMessage)]
        public static LogsTableRow LogsTableRow(IEnumerable<LogsTableColumn> columns, IEnumerable<object> values)
        {
            var columnsList = columns.ToArray();
            var columnMap = Models.LogsTableColumn.GetColumnMapFromColumns(columns);
            JsonElement row = JsonElementFromObject(values);
            return new LogsTableRow(columnMap, columnsList, row);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.LogsTable"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
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

        [RequiresUnreferencedCode(TrimmingUnsafeMessage)]
        [RequiresDynamicCode(TrimmingUnsafeMessage)]
        private static JsonElement JsonElementFromObject<TValue>(TValue value, JsonSerializerOptions options = default)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
            var doc = JsonDocument.Parse(bytes);
            return doc.RootElement.Clone();
        }
    }
}
