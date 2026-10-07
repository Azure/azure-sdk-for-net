// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the DnsCaaRecord data model. </summary>
    public partial class DnsCaaRecordData : DnsBaseRecordData
    {
        /// <summary> Initializes a new instance of <see cref="DnsCaaRecordData"/>. </summary>
        public DnsCaaRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DnsCaaRecordData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The properties of the record set. </param>
        /// <param name="eTag"> The etag of the record set. </param>
        internal DnsCaaRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, DnsRecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, additionalBinaryDataProperties, properties, eTag)
        {
        }

        /// <summary> The list of Caa records in the record set. </summary>
        public IList<DnsCaaRecordInfo> DnsCaaRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DnsRecordSetProperties();
                }
                return Properties.DnsCaaRecords;
            }
        }
    }
}
