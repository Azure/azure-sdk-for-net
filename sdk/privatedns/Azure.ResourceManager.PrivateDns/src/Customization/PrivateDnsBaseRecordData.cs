// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model; this base class preserves the shipped per-record data inheritance hierarchy.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the Record data model. </summary>
    public partial class PrivateDnsBaseRecordData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="PrivateDnsBaseRecordData"/>. </summary>
        public PrivateDnsBaseRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsBaseRecordData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The properties of the record set. </param>
        /// <param name="eTag"> The ETag of the record set. </param>
        internal PrivateDnsBaseRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, PrivateDnsRecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
            ETag = eTag;
        }

        /// <summary> The properties of the record set. </summary>
        internal PrivateDnsRecordSetProperties Properties { get; set; }

        /// <summary> The ETag of the record set. </summary>
        public ETag? ETag { get; set; }

        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PrivateDnsRecordSetProperties();
                }
                return Properties.Metadata;
            }
        }

        /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
        public long? TtlInSeconds
        {
            get => Properties is null ? default : Properties.TtlInSeconds;
            set
            {
                if (Properties is null)
                {
                    Properties = new PrivateDnsRecordSetProperties();
                }
                Properties.TtlInSeconds = value;
            }
        }

        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn => Properties is null ? default : Properties.Fqdn;

        /// <summary> Is the record set auto-registered in the Private DNS zone through a virtual network link?. </summary>
        public bool? IsAutoRegistered => Properties is null ? default : Properties.IsAutoRegistered;
    }
}