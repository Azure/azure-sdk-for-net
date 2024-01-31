// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDnsModelFactory
    {
        /// <summary> Initializes a new instance of DnsAaaaRecordData. </summary>
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
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsAaaaRecordData"/> instance for mocking. </returns>
        public static DnsAaaaRecordData DnsAaaaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl  = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsAaaaRecordInfo> aaaaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aaaaRecords ??= new List<DnsAaaaRecordInfo>();

            return new DnsAaaaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aaaaRecords?.ToList(), serializedAdditionalRawData: null);
        }
    }
}
