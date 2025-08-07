// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("DnsRecordData")]

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the Record data model. </summary>
    public partial class DnsRecordData : DnsBaseRecordData
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

        /// <summary> Initializes a new instance of <see cref="DnsRecordData"/>. </summary>
        public DnsRecordData()
        {
            DnsARecords = new ChangeTrackingList<DnsARecordInfo>();
            DnsAaaaRecords = new ChangeTrackingList<DnsAaaaRecordInfo>();
            DnsMXRecords = new ChangeTrackingList<DnsMXRecordInfo>();
            DnsNSRecords = new ChangeTrackingList<DnsNSRecordInfo>();
            DnsPtrRecords = new ChangeTrackingList<DnsPtrRecordInfo>();
            DnsSrvRecords = new ChangeTrackingList<DnsSrvRecordInfo>();
            DnsTxtRecords = new ChangeTrackingList<DnsTxtRecordInfo>();
            DnsCaaRecords = new ChangeTrackingList<DnsCaaRecordInfo>();
            DnsDSRecords = new ChangeTrackingList<DnsDSRecordInfo>();
            DnsTlsaRecords = new ChangeTrackingList<DnsTlsaRecordInfo>();
            DnsNaptrRecords = new ChangeTrackingList<DnsNaptrRecordInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="DnsRecordData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="trafficManagementProfile"> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <param name="cnameRecordInfo"> The CNAME record in the  record set. </param>
        /// <param name="soaRecordInfo"> The SOA record in the record set. </param>
        /// <param name="caaRecords"> The list of CAA records in the record set. </param>
        /// <param name="dsRecords"> The list of DS records in the record set. </param>
        /// <param name="tlsaRecords"> The list of TLSA records in the record set. </param>
        /// <param name="naptrRecords"> The list of NAPTR records in the record set. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource, WritableSubResource trafficManagementProfile, IList<DnsARecordInfo> aRecords, IList<DnsAaaaRecordInfo> aaaaRecords, IList<DnsMXRecordInfo> mxRecords, IList<DnsNSRecordInfo> nsRecords, IList<DnsPtrRecordInfo> ptrRecords, IList<DnsSrvRecordInfo> srvRecords, IList<DnsTxtRecordInfo> txtRecords, DnsCnameRecordInfo cnameRecordInfo, DnsSoaRecordInfo soaRecordInfo, IList<DnsCaaRecordInfo> caaRecords, IList<DnsDSRecordInfo> dsRecords, IList<DnsTlsaRecordInfo> tlsaRecords, IList<DnsNaptrRecordInfo> naptrRecords, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, trafficManagementProfile, serializedAdditionalRawData)
        {
            DnsARecords = aRecords;
            DnsAaaaRecords = aaaaRecords;
            DnsMXRecords = mxRecords;
            DnsNSRecords = nsRecords;
            DnsPtrRecords = ptrRecords;
            DnsSrvRecords = srvRecords;
            DnsTxtRecords = txtRecords;
            DnsCnameRecordInfo = cnameRecordInfo;
            DnsSoaRecordInfo = soaRecordInfo;
            DnsCaaRecords = caaRecords;
            DnsDSRecords = dsRecords;
            DnsTlsaRecords = tlsaRecords;
            DnsNaptrRecords = naptrRecords;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<DnsARecordInfo> DnsARecords { get; }
        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<DnsAaaaRecordInfo> DnsAaaaRecords { get; }
        /// <summary> The list of MX records in the record set. </summary>
        public IList<DnsMXRecordInfo> DnsMXRecords { get; }
        /// <summary> The list of NS records in the record set. </summary>
        public IList<DnsNSRecordInfo> DnsNSRecords { get; }
        /// <summary> The list of PTR records in the record set. </summary>
        public IList<DnsPtrRecordInfo> DnsPtrRecords { get; }
        /// <summary> The list of SRV records in the record set. </summary>
        public IList<DnsSrvRecordInfo> DnsSrvRecords { get; }
        /// <summary> The list of TXT records in the record set. </summary>
        public IList<DnsTxtRecordInfo> DnsTxtRecords { get; }
        /// <summary> The CNAME record in the  record set. </summary>
        internal DnsCnameRecordInfo DnsCnameRecordInfo { get; set; }
        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => DnsCnameRecordInfo is null ? default : DnsCnameRecordInfo.Cname;
            set
            {
                if (DnsCnameRecordInfo is null)
                    DnsCnameRecordInfo = new DnsCnameRecordInfo();
                DnsCnameRecordInfo.Cname = value;
            }
        }

        /// <summary> The SOA record in the record set. </summary>
        public DnsSoaRecordInfo DnsSoaRecordInfo { get; set; }
        /// <summary> The list of CAA records in the record set. </summary>
        public IList<DnsCaaRecordInfo> DnsCaaRecords { get; }
        /// <summary> The list of DS records in the record set. </summary>
        public IList<DnsDSRecordInfo> DnsDSRecords { get; }
        /// <summary> The list of TLSA records in the record set. </summary>
        public IList<DnsTlsaRecordInfo> DnsTlsaRecords { get; }
        /// <summary> The list of NAPTR records in the record set. </summary>
        public IList<DnsNaptrRecordInfo> DnsNaptrRecords { get; }
        /// <summary> The DnsRecordType in the record set. </summary>
        public DnsRecordType RecordType
        {
            get
            {
                var resourceTypeString = base.ResourceType.Type.Split('/').Where(part => !string.IsNullOrEmpty(part)).LastOrDefault();
                DnsRecordType recordType = DnsRecordTypeExtensions.ToDnsRecordType(resourceTypeString);
                return recordType;
            }
        }
    }
}
