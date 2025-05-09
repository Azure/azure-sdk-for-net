// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.WorkloadsSapVirtualInstance.Models
{
    /// <summary> The SAP Availability Zone Pair. </summary>
    public partial class SapAvailabilityZonePair
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

        /// <summary> Initializes a new instance of <see cref="SapAvailabilityZonePair"/>. </summary>
        internal SapAvailabilityZonePair()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SapAvailabilityZonePair"/>. </summary>
        /// <param name="zoneA"> The zone A. </param>
        /// <param name="zoneB"> The zone B. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SapAvailabilityZonePair(long? zoneA, long? zoneB, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ZoneA = zoneA;
            ZoneB = zoneB;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The zone A. </summary>
        public long? ZoneA { get; }
        /// <summary> The zone B. </summary>
        public long? ZoneB { get; }
    }
}
