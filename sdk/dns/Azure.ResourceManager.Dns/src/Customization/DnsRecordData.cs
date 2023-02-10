// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
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
        /// <summary> Initializes a new instance of RecordData. </summary>
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
        }

        /// <summary> Initializes a new instance of RecordData. </summary>
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
        internal DnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource, IList<DnsARecordInfo> aRecords, IList<DnsAaaaRecordInfo> aaaaRecords, IList<DnsMXRecordInfo> mxRecords, IList<DnsNSRecordInfo> nsRecords, IList<DnsPtrRecordInfo> ptrRecords, IList<DnsSrvRecordInfo> srvRecords, IList<DnsTxtRecordInfo> txtRecords, DnsCnameRecordInfo cnameRecordInfo, DnsSoaRecordInfo soaRecordInfo, IList<DnsCaaRecordInfo> caaRecords) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource)
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
    }
}
