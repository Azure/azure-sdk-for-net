// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A class representing the Offer data model.
    /// Offer details.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="OfferData"/>. </summary>
        public OfferData()
        {
            SkuMappings = new ChangeTrackingList<HciSkuMappings>();
        }

        /// <summary> Initializes a new instance of <see cref="OfferData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <param name="publisherId"> Identifier of the Publisher for the offer. </param>
        /// <param name="content"> JSON serialized catalog content of the offer. </param>
        /// <param name="contentVersion"> The API version of the catalog service used to serve the catalog content. </param>
        /// <param name="skuMappings"> Array of SKU mappings. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal OfferData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string provisioningState, string publisherId, string content, string contentVersion, IList<HciSkuMappings> skuMappings, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            ProvisioningState = provisioningState;
            PublisherId = publisherId;
            Content = content;
            ContentVersion = contentVersion;
            SkuMappings = skuMappings;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="OfferData"/>. </summary>
        /// <param name="data"> The instance of <see cref="HciClusterOfferData" />. </param>
        internal OfferData(HciClusterOfferData data) : base(data.Id, data.Name, data.ResourceType, data.SystemData)
        {
            ProvisioningState = data.ProvisioningState;
            PublisherId = data.PublisherId;
            Content = data.Content;
            ContentVersion = data.ContentVersion;
            SkuMappings = data.SkuMappings;
            _serializedAdditionalRawData = null;
        }

        /// <summary> Provisioning State. </summary>
        public string ProvisioningState { get; }
        /// <summary> Identifier of the Publisher for the offer. </summary>
        public string PublisherId { get; set; }
        /// <summary> JSON serialized catalog content of the offer. </summary>
        public string Content { get; set; }
        /// <summary> The API version of the catalog service used to serve the catalog content. </summary>
        public string ContentVersion { get; set; }
        /// <summary> Array of SKU mappings. </summary>
        public IList<HciSkuMappings> SkuMappings { get; }
    }
}
