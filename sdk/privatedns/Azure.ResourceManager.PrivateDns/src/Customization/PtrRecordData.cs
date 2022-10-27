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
    /// <summary> A class representing the PtrRecord data model. </summary>
    public partial class PtrRecordData : RecordData
    {
        /// <summary> Initializes a new instance of PtrRecordData. </summary>
        public PtrRecordData()
        {
            PtrRecords = new ChangeTrackingList<PtrRecordInfo>();
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
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        internal PtrRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, bool? isAutoRegistered, IList<PtrRecordInfo> ptrRecords) : base(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, isAutoRegistered)
        {
            PtrRecords = ptrRecords;
        }

        /// <summary> The list of Ptr records in the record set. </summary>
        public IList<PtrRecordInfo> PtrRecords { get; }
    }
}
