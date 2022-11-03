// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("RecordData")]

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the Record data model. </summary>
    public partial class RecordData : BaseRecordData
    {
        /// <summary> Initializes a new instance of RecordData. </summary>
        public RecordData()
        {
            ARecords = new ChangeTrackingList<ARecordInfo>();
            AaaaRecords = new ChangeTrackingList<AaaaRecordInfo>();
            MXRecords = new ChangeTrackingList<MXRecordInfo>();
            NSRecords = new ChangeTrackingList<NSRecordInfo>();
            PtrRecords = new ChangeTrackingList<PtrRecordInfo>();
            SrvRecords = new ChangeTrackingList<SrvRecordInfo>();
            TxtRecords = new ChangeTrackingList<TxtRecordInfo>();
            CaaRecords = new ChangeTrackingList<CaaRecordInfo>();
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
        internal RecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource, IList<ARecordInfo> aRecords, IList<AaaaRecordInfo> aaaaRecords, IList<MXRecordInfo> mxRecords, IList<NSRecordInfo> nsRecords, IList<PtrRecordInfo> ptrRecords, IList<SrvRecordInfo> srvRecords, IList<TxtRecordInfo> txtRecords, CnameRecordInfo cnameRecordInfo, SoaRecordInfo soaRecordInfo, IList<CaaRecordInfo> caaRecords) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource)
        {
            ARecords = aRecords;
            AaaaRecords = aaaaRecords;
            MXRecords = mxRecords;
            NSRecords = nsRecords;
            PtrRecords = ptrRecords;
            SrvRecords = srvRecords;
            TxtRecords = txtRecords;
            CnameRecordInfo = cnameRecordInfo;
            SoaRecordInfo = soaRecordInfo;
            CaaRecords = caaRecords;
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<ARecordInfo> ARecords { get; }
        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<AaaaRecordInfo> AaaaRecords { get; }
        /// <summary> The list of MX records in the record set. </summary>
        public IList<MXRecordInfo> MXRecords { get; }
        /// <summary> The list of NS records in the record set. </summary>
        public IList<NSRecordInfo> NSRecords { get; }
        /// <summary> The list of PTR records in the record set. </summary>
        public IList<PtrRecordInfo> PtrRecords { get; }
        /// <summary> The list of SRV records in the record set. </summary>
        public IList<SrvRecordInfo> SrvRecords { get; }
        /// <summary> The list of TXT records in the record set. </summary>
        public IList<TxtRecordInfo> TxtRecords { get; }
        /// <summary> The CNAME record in the  record set. </summary>
        internal CnameRecordInfo CnameRecordInfo { get; set; }
        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => CnameRecordInfo is null ? default : CnameRecordInfo.Cname;
            set
            {
                if (CnameRecordInfo is null)
                    CnameRecordInfo = new CnameRecordInfo();
                CnameRecordInfo.Cname = value;
            }
        }

        /// <summary> The SOA record in the record set. </summary>
        public SoaRecordInfo SoaRecordInfo { get; set; }
        /// <summary> The list of CAA records in the record set. </summary>
        public IList<CaaRecordInfo> CaaRecords { get; }
    }
}
