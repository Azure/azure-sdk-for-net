// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Result of Query Performance Insight data reset. </summary>
    public partial class MySqlQueryPerformanceInsightResetDataResult
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

        /// <summary> Initializes a new instance of <see cref="MySqlQueryPerformanceInsightResetDataResult"/>. </summary>
        internal MySqlQueryPerformanceInsightResetDataResult()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MySqlQueryPerformanceInsightResetDataResult"/>. </summary>
        /// <param name="status"> Indicates result of the operation. </param>
        /// <param name="message"> operation message. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlQueryPerformanceInsightResetDataResult(MySqlQueryPerformanceInsightResetDataResultState? status, string message, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Status = status;
            Message = message;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Indicates result of the operation. </summary>
        public MySqlQueryPerformanceInsightResetDataResultState? Status { get; }
        /// <summary> operation message. </summary>
        public string Message { get; }
    }
}