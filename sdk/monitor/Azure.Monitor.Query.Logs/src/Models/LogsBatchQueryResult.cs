// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary> Contains the tables, columns &amp; rows resulting from a query. </summary>
    [CodeGenSuppress("Error")]
    [CodeGenSuppress("_additionalBinaryDataProperties")]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(IEnumerable<LogsTable>))]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(LogsTable), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>), typeof(ErrorInfo), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(IList<LogsTable>), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("LogsBatchQueryResult", typeof(IReadOnlyList<LogsTable>), typeof(JsonElement), typeof(JsonElement), typeof(JsonElement), typeof(IDictionary<string, BinaryData>), typeof(IList<LogsTable>), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
    public partial class LogsBatchQueryResult : LogsQueryResult
    {
        internal int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the query id.
        /// </summary>
        public string Id { get; internal set; }

        internal LogsBatchQueryResult()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LogsBatchQueryResult"/>. </summary>
        /// <param name="allTables"> The results of the query in tabular format. </param>
        /// <param name="error"> Any object. </param>
        /// <param name="statistics"> Any object. </param>
        /// <param name="visualization"> Any object. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LogsBatchQueryResult(IReadOnlyList<LogsTable> allTables, JsonElement error, JsonElement statistics, JsonElement visualization, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(allTables, error, statistics, visualization, serializedAdditionalRawData)
        {
        }

        /// <summary> The results of the query in tabular format. </summary>
        internal IList<LogsTable> Tables { get; }

        /// <summary>
        /// Statistics represented in JSON format.
        /// <para> To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions?)"/>. </para>
        /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term> BinaryData.FromObjectAsJson("foo"). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("\"foo\""). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromObjectAsJson(new { key = "value" }). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("{\"key\": \"value\"}"). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal IDictionary<string, BinaryData> Statistics { get; }

        /// <summary>
        /// Visualization data in JSON format.
        /// <para> To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions?)"/>. </para>
        /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term> BinaryData.FromObjectAsJson("foo"). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("\"foo\""). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromObjectAsJson(new { key = "value" }). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("{\"key\": \"value\"}"). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal IDictionary<string, BinaryData> Render { get; }
    }
}
