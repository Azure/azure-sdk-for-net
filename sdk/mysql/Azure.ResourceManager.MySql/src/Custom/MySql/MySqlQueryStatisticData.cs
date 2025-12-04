// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql
{
    /// <summary>
    /// A class representing the MySqlQueryStatistic data model.
    /// Represents a Query Statistic.
    /// </summary>
    public partial class MySqlQueryStatisticData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MySqlQueryStatisticData"/>. </summary>
        public MySqlQueryStatisticData()
        {
            DatabaseNames = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="MySqlQueryStatisticData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="queryId"> Database query identifier. </param>
        /// <param name="startOn"> Observation start time. </param>
        /// <param name="endOn"> Observation end time. </param>
        /// <param name="aggregationFunction"> Aggregation function name. </param>
        /// <param name="databaseNames"> The list of database names. </param>
        /// <param name="queryExecutionCount"> Number of query executions in this time interval. </param>
        /// <param name="metricName"> Metric name. </param>
        /// <param name="metricDisplayName"> Metric display name. </param>
        /// <param name="metricValue"> Metric value. </param>
        /// <param name="metricValueUnit"> Metric value unit. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlQueryStatisticData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string queryId, DateTimeOffset? startOn, DateTimeOffset? endOn, string aggregationFunction, IList<string> databaseNames, long? queryExecutionCount, string metricName, string metricDisplayName, double? metricValue, string metricValueUnit, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            QueryId = queryId;
            StartOn = startOn;
            EndOn = endOn;
            AggregationFunction = aggregationFunction;
            DatabaseNames = databaseNames;
            QueryExecutionCount = queryExecutionCount;
            MetricName = metricName;
            MetricDisplayName = metricDisplayName;
            MetricValue = metricValue;
            MetricValueUnit = metricValueUnit;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Database query identifier. </summary>
        public string QueryId { get; set; }
        /// <summary> Observation start time. </summary>
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Observation end time. </summary>
        public DateTimeOffset? EndOn { get; set; }
        /// <summary> Aggregation function name. </summary>
        public string AggregationFunction { get; set; }
        /// <summary> The list of database names. </summary>
        public IList<string> DatabaseNames { get; }
        /// <summary> Number of query executions in this time interval. </summary>
        public long? QueryExecutionCount { get; set; }
        /// <summary> Metric name. </summary>
        public string MetricName { get; set; }
        /// <summary> Metric display name. </summary>
        public string MetricDisplayName { get; set; }
        /// <summary> Metric value. </summary>
        public double? MetricValue { get; set; }
        /// <summary> Metric value unit. </summary>
        public string MetricValueUnit { get; set; }
    }
}