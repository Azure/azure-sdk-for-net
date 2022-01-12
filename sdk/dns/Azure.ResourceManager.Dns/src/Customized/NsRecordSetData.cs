// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the RecordSet NS data model. </summary>
    public partial class NsRecordSetData : Resource
    {
        /// <summary> Initializes a new instance of NsRecordData. </summary>
        public NsRecordSetData()
        {
        }

        /// <summary> Initializes a new instance of NsRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="tTL"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="nSRecord"> The NS record in the record set. </param>
        internal NsRecordSetData(ResourceIdentifier id, string name, ResourceType type, string etag, IDictionary<string, string> metadata, long? tTL, string fqdn, string provisioningState, WritableSubResource targetResource, NsRecord nSRecord) : base(id, name, type)
        {
            Etag = etag;
            Metadata = metadata;
            TTL = tTL;
            Fqdn = fqdn;
            ProvisioningState = provisioningState;
            TargetResource = targetResource;
            NsRecord = nSRecord;
        }

        /// <summary> The etag of the record set. </summary>
        public string Etag { get; set; }
        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata { get; }
        /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
        public long? TTL { get; set; }
        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn { get; }
        /// <summary> provisioning State of the record set. </summary>
        public string ProvisioningState { get; }
        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        public WritableSubResource TargetResource { get; set; }
        /// <summary> The NS record in the record set. </summary>
        public NsRecord NsRecord { get; set; }
    }
}
