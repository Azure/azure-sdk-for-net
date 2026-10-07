// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayData type. </summary>
    [CodeGenSuppress("ResourceGuid")]
    public partial class VirtualNetworkGatewayData
    {
        /// <summary> Gets the ResourceGuid compatibility property. </summary>
        [WirePath("properties.resourceGuid")]
        public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid);
    }
}
