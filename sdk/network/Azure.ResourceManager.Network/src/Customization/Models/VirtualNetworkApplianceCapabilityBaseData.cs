// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // ARM ProxyResource<VirtualNetworkApplianceCapabilityProperties> synthesizes this base, so service clientName
    // cannot target it. Map it here to avoid exposing the template-generated public name.
    [CodeGenType("ProxyResourceVirtualNetworkApplianceCapabilityProperties")]
    public partial class VirtualNetworkApplianceCapabilityBaseData
    {
    }
}
