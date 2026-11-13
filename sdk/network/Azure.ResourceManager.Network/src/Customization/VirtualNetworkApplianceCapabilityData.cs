// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Match the consolidated spec's composition-based resource without exposing its template base.
    [CodeGenSerialization(nameof(Properties), "properties")]
    public abstract partial class VirtualNetworkApplianceCapabilityData : ResourceData
    {
        // The custom resource base replaces the template that originally supplied this wire property.
        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        public VirtualNetworkApplianceCapabilityProperties Properties { get; set; }
    }
}
