// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

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
        internal DnsBaseRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, RecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
            ETag = eTag;
        }

        /// <summary> The properties of the record set. </summary>
        internal RecordSetProperties Properties { get; set; }

        /// <summary> The etag of the record set. </summary>
        public ETag? ETag { get; set; }

        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
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
                    Properties = new RecordSetProperties();
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

        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        public WritableSubResource TargetResource
        {
            get
            {
                return Properties is null ? default : Properties.TargetResource;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                Properties.TargetResource = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TargetResourceId
        {
            get => TargetResource is null ? default : TargetResource.Id;
            set
            {
                if (TargetResource is null)
                    TargetResource = new WritableSubResource();
                TargetResource.Id = value;
            }
        }

        /// <summary> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </summary>
        public WritableSubResource TrafficManagementProfile
        {
            get
            {
                return Properties is null ? default : Properties.TrafficManagementProfile;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                Properties.TrafficManagementProfile = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TrafficManagementProfileId
        {
            get => TrafficManagementProfile is null ? default : TrafficManagementProfile.Id;
            set
            {
                if (TrafficManagementProfile is null)
                    TrafficManagementProfile = new WritableSubResource();
                TrafficManagementProfile.Id = value;
            }
        }
    }
}
