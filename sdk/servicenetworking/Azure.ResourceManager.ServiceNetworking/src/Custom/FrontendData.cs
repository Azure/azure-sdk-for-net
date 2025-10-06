// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
    /// <summary>
    /// A class representing the Frontend data model.
    /// Frontend Subresource of Traffic Controller.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `TrafficControllerFrontendData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FrontendData : TrackedResourceData
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

        /// <summary> Initializes a new instance of <see cref="FrontendData"/>. </summary>
        /// <param name="location"> The location. </param>
        public FrontendData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="FrontendData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="fqdn"> The Fully Qualified Domain Name of the DNS record associated to a Traffic Controller frontend. </param>
        /// <param name="provisioningState"> Provisioning State of Traffic Controller Frontend Resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FrontendData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string fqdn, ProvisioningState? provisioningState, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Fqdn = fqdn;
            ProvisioningState = provisioningState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="FrontendData"/> for deserialization. </summary>
        internal FrontendData()
        {
        }
        internal FrontendData(TrafficControllerFrontendData data) : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Tags, data.Location)
        {
            Fqdn = data.Fqdn;
            ProvisioningState = data.ProvisioningState.ToString();
            _serializedAdditionalRawData = null;
        }

        internal TrafficControllerFrontendData ToTrafficControllerFrontendData()
        {
            return new TrafficControllerFrontendData(Id, Name, ResourceType, SystemData, Tags, Location, Fqdn, ProvisioningState.ToString(), _serializedAdditionalRawData);
        }

        /// <summary> The Fully Qualified Domain Name of the DNS record associated to a Traffic Controller frontend. </summary>
        public string Fqdn { get; }
        /// <summary> Provisioning State of Traffic Controller Frontend Resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
