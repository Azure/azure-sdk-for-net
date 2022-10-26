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
    /// <summary> A class representing the ARecord data model. </summary>
    public partial class ARecordData : RecordData
    {
        /// <summary> Initializes a new instance of ARecordData. </summary>
        public ARecordData()
        {
            ARecords = new ChangeTrackingList<ARecordInfo>();
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
        internal ARecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, bool? isAutoRegistered) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, isAutoRegistered)
        {
            ARecords = new ChangeTrackingList<ARecordInfo>();
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<ARecordInfo> ARecords { get; }
    }
}
