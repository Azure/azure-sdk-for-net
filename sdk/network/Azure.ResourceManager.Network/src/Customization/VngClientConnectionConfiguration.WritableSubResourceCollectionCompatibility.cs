// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("VirtualNetworkGatewayPolicyGroups")]
    public partial class VngClientConnectionConfiguration
    {
        [Azure.ResourceManager.Network.WirePath("properties.virtualNetworkGatewayPolicyGroups")] public IList<WritableSubResource> VirtualNetworkGatewayPolicyGroups => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.VirtualNetworkGatewayPolicyGroups);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
