// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("PartnerConfigurationData")]

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Partner configuration information. </summary>
    public partial class PartnerConfigurationData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="PartnerConfigurationData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public PartnerConfigurationData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="PartnerConfigurationData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="properties"> Properties of the partner configuration. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal PartnerConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, PartnerConfigurationProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Properties of the partner configuration. </summary>
        [WirePath("properties")]
        internal PartnerConfigurationProperties Properties { get; set; }

        /// <summary> The details of authorized partners. </summary>
        [WirePath("properties.partnerAuthorization")]
        public PartnerAuthorization PartnerAuthorization
        {
            get
            {
                return Properties is null ? default : Properties.PartnerAuthorization;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PartnerConfigurationProperties();
                }
                Properties.PartnerAuthorization = value;
            }
        }

        /// <summary> Provisioning state of the partner configuration. </summary>
        [WirePath("properties.provisioningState")]
        public PartnerConfigurationProvisioningState? ProvisioningState
        {
            get
            {
                return Properties is null ? default : Properties.ProvisioningState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PartnerConfigurationProperties();
                }
                Properties.ProvisioningState = value;
            }
        }
    }
}
