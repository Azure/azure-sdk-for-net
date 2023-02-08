// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the PrivateDnsCnameRecord data model. </summary>
    public partial class PrivateDnsCnameRecordData : PrivateDnsBaseRecordData
    {
        /// <summary> Initializes a new instance of PrivateDnsCnameRecordData. </summary>
        public PrivateDnsCnameRecordData()
        {
        }

        /// <summary> Initializes a new instance of RecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The ETag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="isAutoRegistered"> Is the record set auto-registered in the Private DNS zone through a virtual network link?. </param>
        /// <param name="cnameRecord"> The CNAME record in the  record set. </param>
        internal PrivateDnsCnameRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, bool? isAutoRegistered, PrivateDnsCnameRecordInfo cnameRecord) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, isAutoRegistered)
        {
            PrivateDnsCnameRecord = cnameRecord;
        }

        /// <summary> The CNAME record in the  record set. </summary>
        internal PrivateDnsCnameRecordInfo PrivateDnsCnameRecord { get; set; }
        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => PrivateDnsCnameRecord is null ? default : PrivateDnsCnameRecord.Cname;
            set
            {
                if (PrivateDnsCnameRecord is null)
                    PrivateDnsCnameRecord = new PrivateDnsCnameRecordInfo();
                PrivateDnsCnameRecord.Cname = value;
            }
        }
    }
}
