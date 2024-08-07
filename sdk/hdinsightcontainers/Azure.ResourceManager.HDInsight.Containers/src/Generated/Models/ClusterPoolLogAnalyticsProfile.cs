// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.HDInsight.Containers.Models
{
    /// <summary> Cluster pool log analytics profile used to enable or disable OMS agent for AKS cluster. </summary>
    public partial class ClusterPoolLogAnalyticsProfile
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

        /// <summary> Initializes a new instance of <see cref="ClusterPoolLogAnalyticsProfile"/>. </summary>
        /// <param name="isEnabled"> True if log analytics is enabled for cluster pool, otherwise false. </param>
        public ClusterPoolLogAnalyticsProfile(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        /// <summary> Initializes a new instance of <see cref="ClusterPoolLogAnalyticsProfile"/>. </summary>
        /// <param name="isEnabled"> True if log analytics is enabled for cluster pool, otherwise false. </param>
        /// <param name="workspaceId"> Log analytics workspace to associate with the OMS agent. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ClusterPoolLogAnalyticsProfile(bool isEnabled, ResourceIdentifier workspaceId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            IsEnabled = isEnabled;
            WorkspaceId = workspaceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ClusterPoolLogAnalyticsProfile"/> for deserialization. </summary>
        internal ClusterPoolLogAnalyticsProfile()
        {
        }

        /// <summary> True if log analytics is enabled for cluster pool, otherwise false. </summary>
        [WirePath("enabled")]
        public bool IsEnabled { get; set; }
        /// <summary> Log analytics workspace to associate with the OMS agent. </summary>
        [WirePath("workspaceId")]
        public ResourceIdentifier WorkspaceId { get; set; }
    }
}
