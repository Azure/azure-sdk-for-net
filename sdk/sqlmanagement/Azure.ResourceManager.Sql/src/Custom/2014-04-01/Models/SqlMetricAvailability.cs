// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> A metric availability value. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SqlMetricAvailability
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

        /// <summary> Initializes a new instance of <see cref="SqlMetricAvailability"/>. </summary>
        internal SqlMetricAvailability()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SqlMetricAvailability"/>. </summary>
        /// <param name="retention"> The length of retention for the database metric. </param>
        /// <param name="timeGrain"> The granularity of the database metric. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SqlMetricAvailability(string retention, string timeGrain, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Retention = retention;
            TimeGrain = timeGrain;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The length of retention for the database metric. </summary>
        [WirePath("retention")]
        public string Retention { get; }
        /// <summary> The granularity of the database metric. </summary>
        [WirePath("timeGrain")]
        public string TimeGrain { get; }
    }
}
