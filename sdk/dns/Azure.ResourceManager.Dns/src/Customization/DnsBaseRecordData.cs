// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary> Describes a DNS record set (a collection of DNS records with the same name and type). </summary>
    public partial class DnsBaseRecordData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="DnsBaseRecordData"/>. </summary>
        public DnsBaseRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DnsBaseRecordData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The properties of the record set. </param>
        /// <param name="eTag"> The etag of the record set. </param>
        internal DnsBaseRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, DnsRecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
            ETag = eTag;
        }

        /// <summary> The properties of the record set. </summary>
        internal DnsRecordSetProperties Properties { get; set; }

        /// <summary> The etag of the record set. </summary>
        public ETag? ETag { get; set; }

        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DnsRecordSetProperties();
                }
                return Properties.Metadata;
            }
        }

        /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
        public long? TtlInSeconds
        {
            get
            {
                return Properties is null ? default : Properties.TtlInSeconds;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new DnsRecordSetProperties();
                }
                Properties.TtlInSeconds = value;
            }
        }

        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn
        {
            get
            {
                return Properties is null ? default : Properties.Fqdn;
            }
        }

        /// <summary> provisioning State of the record set. </summary>
        public string ProvisioningState
        {
            get
            {
                return Properties is null ? default : Properties.ProvisioningState;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TargetResourceId
        {
            get => Properties?.TargetResource?.Id;
            set
            {
                if (Properties is null)
                {
                    Properties = new DnsRecordSetProperties();
                }
                if (Properties.TargetResource is null)
                {
                    Properties.TargetResource = new DnsSubResourceInfo();
                }
                Properties.TargetResource.Id = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TrafficManagementProfileId
        {
            get => Properties?.TrafficManagementProfile?.Id;
            set
            {
                if (Properties is null)
                {
                    Properties = new DnsRecordSetProperties();
                }
                if (Properties.TrafficManagementProfile is null)
                {
                    Properties.TrafficManagementProfile = new DnsSubResourceInfo();
                }
                Properties.TrafficManagementProfile.Id = value;
            }
        }
    }
}
