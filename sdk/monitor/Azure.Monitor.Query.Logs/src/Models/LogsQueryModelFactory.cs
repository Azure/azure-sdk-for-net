// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary>
    /// Model factory that enables mocking for public model types.
    /// </summary>
    [CodeGenType("QueryLogsModelFactory")]
    [CodeGenSuppress("LogsQueryResult", typeof(IEnumerable<LogsTable>), typeof(JsonElement), typeof(JsonElement), typeof(JsonElement))]
    [CodeGenSuppress("LogsTable", typeof(string), typeof(IEnumerable<LogsTableColumn>), typeof(JsonElement))]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(IEnumerable<LogsTable>), typeof(JsonElement), typeof(JsonElement), typeof(JsonElement))]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(IEnumerable<LogsTable>), typeof(JsonElement), typeof(JsonElement), typeof(JsonElement), typeof(IEnumerable<LogsTable>), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
    public static partial class LogsQueryModelFactory
    {
        private const string TrimmingUnsafeMessage = "This method uses JSON serialization that is incompatible with trimming.";

        /// <summary>
        /// Creates an instance of <see cref="Models.LogsQueryResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="allTables"> The list of tables, columns, and rows. </param>
        /// <param name="error"> Any object. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        [RequiresUnreferencedCode(TrimmingUnsafeMessage)]
        [RequiresDynamicCode(TrimmingUnsafeMessage)]
        public static LogsQueryResult LogsQueryResult(IReadOnlyList<LogsTable> allTables, BinaryData error, BinaryData statistics, BinaryData visualization)
        {
            JsonElement statisticsJson = statistics.ToObjectFromJson<JsonElement>();
            JsonElement visualizationJson = visualization.ToObjectFromJson<JsonElement>();
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new LogsQueryResult(allTables.ToArray(), errorJson, statisticsJson, visualizationJson, serializedAdditionalRawData: null);
        }

        /// <summary>
        /// Creates an instance of <see cref="Models.LogsBatchQueryResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="allTables"> The list of tables, columns, and rows. </param>
        /// <param name="error"> Any object. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        [RequiresUnreferencedCode(TrimmingUnsafeMessage)]
        [RequiresDynamicCode(TrimmingUnsafeMessage)]
        public static LogsBatchQueryResult LogsBatchQueryResult(IReadOnlyList<LogsTable> allTables, BinaryData error, BinaryData statistics, BinaryData visualization)
        {
            JsonElement statisticsJson = statistics.ToObjectFromJson<JsonElement>();
            JsonElement visualizationJson = visualization.ToObjectFromJson<JsonElement>();
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new LogsBatchQueryResult(allTables.ToArray(), errorJson, statisticsJson, visualizationJson, serializedAdditionalRawData: null);
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

        /// <summary>
        /// /// Creates an instance of <see cref="Models.LogsQueryResult"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        /// <param name="batchQueryResults">The batch query results.</param>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="Models.LogsBatchQueryResultCollection"/> instance.</returns>
        public static LogsBatchQueryResultCollection LogsBatchQueryResultCollection(IList<LogsBatchQueryResult> batchQueryResults, LogsBatchQuery query) =>
            new LogsBatchQueryResultCollection(batchQueryResults, query);

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
