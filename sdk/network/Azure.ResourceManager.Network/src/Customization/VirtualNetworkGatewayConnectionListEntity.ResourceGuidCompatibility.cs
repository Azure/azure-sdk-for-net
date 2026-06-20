// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionListEntity type. </summary>
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Gets the ResourceGuid compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")]
        public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid);
    }
}
