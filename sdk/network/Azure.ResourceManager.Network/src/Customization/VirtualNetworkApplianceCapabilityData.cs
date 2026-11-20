// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Match the consolidated spec's composition-based resource without exposing its template base.
    // Remove this customization when https://github.com/Azure/azure-rest-api-specs/pull/47722 is merged and used for regeneration.
    [CodeGenSerialization(nameof(Properties), "properties")]
    public abstract partial class VirtualNetworkApplianceCapabilityData : ResourceData
    {
        // The custom resource base replaces the template that originally supplied this wire property.
        // Remove with the custom base when https://github.com/Azure/azure-rest-api-specs/pull/47722 is merged and used for regeneration.
        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        public VirtualNetworkApplianceCapabilityProperties Properties { get; set; }
    }
}
