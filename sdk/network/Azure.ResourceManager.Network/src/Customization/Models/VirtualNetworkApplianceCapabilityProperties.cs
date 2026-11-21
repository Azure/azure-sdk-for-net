// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Keep the capability envelope reachable after replacing its generated resource-template base.
    // Remove this customization when https://github.com/Azure/azure-rest-api-specs/pull/47722 is merged and used for regeneration.
    [CodeGenType("VirtualNetworkApplianceCapabilityProperties")]
    public partial class VirtualNetworkApplianceCapabilityProperties
    {
    }
}
