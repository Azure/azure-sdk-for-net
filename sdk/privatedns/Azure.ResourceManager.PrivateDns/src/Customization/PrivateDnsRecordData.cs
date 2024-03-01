// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;

[assembly: CodeGenSuppressType("PrivateDnsRecordData")]

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the RecordSet data model. </summary>
    public partial class PrivateDnsRecordData : PrivateDnsBaseRecordData
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
        /// <summary> Initializes a new instance of RecordSetData. </summary>
        public PrivateDnsRecordData()
        {
            ARecords = new ChangeTrackingList<PrivateDnsARecordInfo>();
            AaaaRecords = new ChangeTrackingList<PrivateDnsAaaaRecordInfo>();
            MXRecords = new ChangeTrackingList<PrivateDnsMXRecordInfo>();
            PtrRecords = new ChangeTrackingList<PrivateDnsPtrRecordInfo>();
            SrvRecords = new ChangeTrackingList<PrivateDnsSrvRecordInfo>();
            TxtRecords = new ChangeTrackingList<PrivateDnsTxtRecordInfo>();
        }

        /// <summary> Initializes a new instance of RecordSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The ETag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="isAutoRegistered"> Is the record set auto-registered in the Private DNS zone through a virtual network link?. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <param name="privateDnsCnameRecordInfo"> The CNAME record in the record set. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <param name="privateDnsSoaRecordInfo"> The SOA record in the record set. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PrivateDnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, bool? isAutoRegistered, IList<PrivateDnsARecordInfo> aRecords, IList<PrivateDnsAaaaRecordInfo> aaaaRecords, PrivateDnsCnameRecordInfo privateDnsCnameRecordInfo, IList<PrivateDnsMXRecordInfo> mxRecords, IList<PrivateDnsPtrRecordInfo> ptrRecords, PrivateDnsSoaRecordInfo privateDnsSoaRecordInfo, IList<PrivateDnsSrvRecordInfo> srvRecords, IList<PrivateDnsTxtRecordInfo> txtRecords, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, isAutoRegistered, serializedAdditionalRawData)
        {
            ARecords = aRecords;
            AaaaRecords = aaaaRecords;
            PrivateDnsCnameRecordInfo = privateDnsCnameRecordInfo;
            MXRecords = mxRecords;
            PtrRecords = ptrRecords;
            PrivateDnsSoaRecordInfo = privateDnsSoaRecordInfo;
            SrvRecords = srvRecords;
            TxtRecords = txtRecords;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> The list of A records in the record set. </summary>
        public IList<PrivateDnsARecordInfo> ARecords { get; }
        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<PrivateDnsAaaaRecordInfo> AaaaRecords { get; }
        /// <summary> The CNAME record in the record set. </summary>
        internal PrivateDnsCnameRecordInfo PrivateDnsCnameRecordInfo { get; set; }
        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => PrivateDnsCnameRecordInfo is null ? default : PrivateDnsCnameRecordInfo.Cname;
            set
            {
                if (PrivateDnsCnameRecordInfo is null)
                    PrivateDnsCnameRecordInfo = new PrivateDnsCnameRecordInfo();
                PrivateDnsCnameRecordInfo.Cname = value;
            }
        }

        /// <summary> The list of MX records in the record set. </summary>
        public IList<PrivateDnsMXRecordInfo> MXRecords { get; }
        /// <summary> The list of PTR records in the record set. </summary>
        public IList<PrivateDnsPtrRecordInfo> PtrRecords { get; }
        /// <summary> The SOA record in the record set. </summary>
        public PrivateDnsSoaRecordInfo PrivateDnsSoaRecordInfo { get; set; }
        /// <summary> The list of SRV records in the record set. </summary>
        public IList<PrivateDnsSrvRecordInfo> SrvRecords { get; }
        /// <summary> The list of TXT records in the record set. </summary>
        public IList<PrivateDnsTxtRecordInfo> TxtRecords { get; }
    }
}
