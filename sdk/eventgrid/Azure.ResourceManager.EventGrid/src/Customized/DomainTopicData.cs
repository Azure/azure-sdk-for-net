// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("DomainTopicData")]

namespace Azure.ResourceManager.EventGrid
{
    /// <summary> Domain Topic. </summary>
    public partial class DomainTopicData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="DomainTopicData"/>. </summary>
        public DomainTopicData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DomainTopicData"/>. </summary>
        internal DomainTopicData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DomainTopicProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, name, resourceType, systemData)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Properties of the domain topic. </summary>
        [WirePath("properties")]
        internal DomainTopicProperties Properties { get; set; }

        /// <summary> Provisioning state of the domain topic. </summary>
        [WirePath("properties.provisioningState")]
        public DomainTopicProvisioningState? ProvisioningState => Properties?.ProvisioningState;
    }
}
