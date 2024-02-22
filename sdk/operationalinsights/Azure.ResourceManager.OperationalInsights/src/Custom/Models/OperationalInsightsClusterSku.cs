// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    /// <summary> The cluster sku definition. </summary>
    public partial class OperationalInsightsClusterSku
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

        /// <summary> Initializes a new instance of <see cref="OperationalInsightsClusterSku"/>. </summary>
        public OperationalInsightsClusterSku()
        {
        }

        /// <summary> Initializes a new instance of <see cref="OperationalInsightsClusterSku"/>. </summary>
        /// <param name="capacity"> The capacity value. </param>
        /// <param name="name"> The name of the SKU. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal OperationalInsightsClusterSku(OperationalInsightsClusterCapacity? capacity, OperationalInsightsClusterSkuName? name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Capacity = capacity;
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The capacity value. </summary>
        public OperationalInsightsClusterCapacity? Capacity { get; set; }
        /// <summary> The name of the SKU. </summary>
        public OperationalInsightsClusterSkuName? Name { get; set; }
    }
}
