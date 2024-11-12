// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The Private Endpoint resource. </summary>
    public partial class MachineLearningPrivateEndpoint
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

        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpoint"/>. </summary>
        public MachineLearningPrivateEndpoint()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpoint"/>. </summary>
        /// <param name="id"> e.g. /subscriptions/{networkSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}. </param>
        /// <param name="subnetArmId"> The subnetId that the private endpoint is connected to. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MachineLearningPrivateEndpoint(ResourceIdentifier id, ResourceIdentifier subnetArmId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            SubnetArmId = subnetArmId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> e.g. /subscriptions/{networkSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}. </summary>
        public ResourceIdentifier Id { get; }
        /// <summary> The subnetId that the private endpoint is connected to. </summary>
        public ResourceIdentifier SubnetArmId { get; }
    }
}
