// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("VerifiedPartnerData")]

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Verified partner information. </summary>
    public partial class VerifiedPartnerData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="VerifiedPartnerData"/>. </summary>
        public VerifiedPartnerData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VerifiedPartnerData"/> for deserialization. </summary>
        internal VerifiedPartnerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, VerifiedPartnerProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData)
        {
            PartnerRegistrationImmutableId = properties?.PartnerRegistrationImmutableId;
            OrganizationName = properties?.OrganizationName;
            PartnerDisplayName = properties?.PartnerDisplayName;
            PartnerTopicDetails = properties?.PartnerTopicDetails;
            PartnerDestinationDetails = properties?.PartnerDestinationDetails;
            ProvisioningState = properties?.ProvisioningState;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> ImmutableId of the corresponding partner registration. </summary>
        [WirePath("properties.partnerRegistrationImmutableId")]
        public Guid? PartnerRegistrationImmutableId { get; set; }

        /// <summary> Official name of the Partner. </summary>
        [WirePath("properties.organizationName")]
        public string OrganizationName { get; set; }

        /// <summary> Display name of the verified partner. </summary>
        [WirePath("properties.partnerDisplayName")]
        public string PartnerDisplayName { get; set; }

        /// <summary> Details of the partner topic scenario. </summary>
        [WirePath("properties.partnerTopicDetails")]
        public PartnerDetails PartnerTopicDetails { get; set; }

        /// <summary> Details of the partner destination scenario. </summary>
        [WirePath("properties.partnerDestinationDetails")]
        public PartnerDetails PartnerDestinationDetails { get; set; }

        /// <summary> Provisioning state of the verified partner. </summary>
        [WirePath("properties.provisioningState")]
        public VerifiedPartnerProvisioningState? ProvisioningState { get; set; }
    }
}
