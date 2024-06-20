// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the DnsARecord data model. </summary>
    public partial class DnsBaseRecordData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="DnsBaseRecordData"/>. </summary>
        public DnsBaseRecordData()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="DnsBaseRecordData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="trafficManagementProfile"> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DnsBaseRecordData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource,  WritableSubResource trafficManagementProfile, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            ETag = etag;
            Metadata = metadata;
            TtlInSeconds = ttl;
            Fqdn = fqdn;
            ProvisioningState = provisioningState;
            TargetResource = targetResource;
            TrafficManagementProfile = trafficManagementProfile;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The etag of the record set. </summary>
        public ETag? ETag { get; set; }
        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata { get; }
        /// <summary> The Ttl (time-to-live) of the records in the record set. </summary>
        public long? TtlInSeconds { get; set; }
        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn { get; }
        /// <summary> provisioning State of the record set. </summary>
        public string ProvisioningState { get; }
        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        internal WritableSubResource TargetResource { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TargetResourceId
        {
            get => TargetResource is null ? default : TargetResource.Id;
            set
            {
                if (TargetResource is null)
                    TargetResource = new WritableSubResource();
                TargetResource.Id = value;
            }
        }
        /// <summary> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </summary>
        internal WritableSubResource TrafficManagementProfile { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TrafficManagementProfileId
        {
            get => TrafficManagementProfile is null ? default : TrafficManagementProfile.Id;
            set
            {
                if (TrafficManagementProfile is null)
                    TrafficManagementProfile = new WritableSubResource();
                TrafficManagementProfile.Id = value;
            }
        }
    }
}
