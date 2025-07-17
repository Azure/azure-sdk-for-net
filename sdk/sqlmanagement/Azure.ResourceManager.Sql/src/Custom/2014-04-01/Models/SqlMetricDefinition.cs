// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> A database metric definition. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SqlMetricDefinition
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

        /// <summary> Initializes a new instance of <see cref="SqlMetricDefinition"/>. </summary>
        internal SqlMetricDefinition()
        {
            MetricAvailabilities = new ChangeTrackingList<SqlMetricAvailability>();
        }

        /// <summary> Initializes a new instance of <see cref="SqlMetricDefinition"/>. </summary>
        /// <param name="name"> The name information for the metric. </param>
        /// <param name="primaryAggregationType"> The primary aggregation type defining how metric values are displayed. </param>
        /// <param name="resourceUriString"> The resource uri of the database. </param>
        /// <param name="unit"> The unit of the metric. </param>
        /// <param name="metricAvailabilities"> The list of database metric availabilities for the metric. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SqlMetricDefinition(SqlMetricName name, SqlMetricPrimaryAggregationType? primaryAggregationType, string resourceUriString, SqlMetricDefinitionUnitType? unit, IReadOnlyList<SqlMetricAvailability> metricAvailabilities, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            PrimaryAggregationType = primaryAggregationType;
            ResourceUriString = resourceUriString;
            Unit = unit;
            MetricAvailabilities = metricAvailabilities;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name information for the metric. </summary>
        [WirePath("name")]
        public SqlMetricName Name { get; }
        /// <summary> The primary aggregation type defining how metric values are displayed. </summary>
        [WirePath("primaryAggregationType")]
        public SqlMetricPrimaryAggregationType? PrimaryAggregationType { get; }
        /// <summary> The resource uri of the database. </summary>
        [WirePath("resourceUri")]
        public string ResourceUriString { get; }
        /// <summary> The unit of the metric. </summary>
        [WirePath("unit")]
        public SqlMetricDefinitionUnitType? Unit { get; }
        /// <summary> The list of database metric availabilities for the metric. </summary>
        [WirePath("metricAvailabilities")]
        public IReadOnlyList<SqlMetricAvailability> MetricAvailabilities { get; }
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public Uri ResourceUri => string.IsNullOrEmpty(ResourceUriString) ? null : new Uri(ResourceUriString);
    }
}
