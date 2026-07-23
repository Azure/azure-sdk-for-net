// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the PrivateDnsCnameRecord data model. </summary>
    public partial class PrivateDnsCnameRecordData : PrivateDnsBaseRecordData
    {
        /// <summary> Initializes a new instance of <see cref="PrivateDnsCnameRecordData"/>. </summary>
        public PrivateDnsCnameRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsCnameRecordData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The properties of the record set. </param>
        /// <param name="eTag"> The etag of the record set. </param>
        internal PrivateDnsCnameRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, PrivateDnsRecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, additionalBinaryDataProperties, properties, eTag)
        {
        }

        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get
            {
                return Properties is null ? default : Properties.Cname;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PrivateDnsRecordSetProperties();
                }
                Properties.Cname = value;
            }
        }
    }
}
