// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
    /// <summary>
    /// A class representing the Association data model.
    /// Association Subresource of Traffic Controller
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `TrafficControllerAssociationData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AssociationData : TrackedResourceData
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

        /// <summary> Initializes a new instance of <see cref="AssociationData"/>. </summary>
        /// <param name="location"> The location. </param>
        public AssociationData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="AssociationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="associationType"> Association Type. </param>
        /// <param name="subnet"> Association Subnet. </param>
        /// <param name="provisioningState"> Provisioning State of Traffic Controller Association Resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AssociationData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, AssociationType? associationType, WritableSubResource subnet, ProvisioningState? provisioningState, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            AssociationType = associationType;
            Subnet = subnet;
            ProvisioningState = provisioningState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AssociationData"/> for deserialization. </summary>
        internal AssociationData()
        {
        }

        internal AssociationData(TrafficControllerAssociationData data) : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Tags, data.Location)
        {
            AssociationType = data.AssociationType.ToString();
            Subnet = data.Subnet;
            ProvisioningState = data.ProvisioningState.ToString();
            _serializedAdditionalRawData = null;
        }

        internal TrafficControllerAssociationData ToTrafficControllerAssociationData()
        {
            return new TrafficControllerAssociationData(Id, Name, ResourceType, SystemData, Tags, Location, AssociationType.ToString(), Subnet, ProvisioningState.ToString(), _serializedAdditionalRawData);
        }

        /// <summary> Association Type. </summary>
        public AssociationType? AssociationType { get; set; }
        /// <summary> Association Subnet. </summary>
        internal WritableSubResource Subnet { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet is null ? default : Subnet.Id;
            set
            {
                if (Subnet is null)
                    Subnet = new WritableSubResource();
                Subnet.Id = value;
            }
        }

        /// <summary> Provisioning State of Traffic Controller Association Resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
