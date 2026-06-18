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
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayPolicyGroup type. </summary>
    [CodeGenSuppress("VngClientConnectionConfigurations")]
    public partial class VirtualNetworkGatewayPolicyGroup
    {
        /// <summary> Gets or sets the VngClientConnectionConfigurations compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.vngClientConnectionConfigurations")]
        public IReadOnlyList<WritableSubResource> VngClientConnectionConfigurations => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VngClientConnectionConfigurations);
    }
}
