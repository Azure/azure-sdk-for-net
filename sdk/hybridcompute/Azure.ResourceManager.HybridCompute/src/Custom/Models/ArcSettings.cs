// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA settings APIs exposed ArcSettings with Guid-based tenant IDs instead of ArcSettingsData.
    /// <summary> The ArcSettings. </summary>
    public partial class ArcSettings : ResourceData
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ArcSettings"/>. </summary>
        public ArcSettings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ArcSettings"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tenantId"> Azure resource tenant Id. </param>
        /// <param name="gatewayResourceId"> Associated Gateway Resource Id. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        public ArcSettings(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, Guid? tenantId, ResourceIdentifier gatewayResourceId, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            TenantId = tenantId;
            GatewayResourceId = gatewayResourceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Azure resource tenant Id. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId { get; }

        /// <summary> Associated Gateway Resource Id. </summary>
        [WirePath("properties.gatewayProperties.gatewayResourceId")]
        public ResourceIdentifier GatewayResourceId { get; set; }
    }
}
