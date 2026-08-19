// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VngClientConnectionConfiguration type. </summary>
    [CodeGenSuppress("VirtualNetworkGatewayPolicyGroups")]
    public partial class VngClientConnectionConfiguration
    {
        /// <summary> Gets or sets the VirtualNetworkGatewayPolicyGroups compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.virtualNetworkGatewayPolicyGroups")]
        public IList<WritableSubResource> VirtualNetworkGatewayPolicyGroups => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.VirtualNetworkGatewayPolicyGroups);
    }
}
