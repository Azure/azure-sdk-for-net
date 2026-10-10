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

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualHubData type. </summary>
    [CodeGenSuppress("BgpConnections")]
    [CodeGenSuppress("RouteMaps")]
    public partial class VirtualHubData
    {
        /// <summary> Gets or sets the BgpConnections compatibility property. </summary>
        [WirePath("properties.bgpConnections")]
        public IReadOnlyList<WritableSubResource> BgpConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.BgpConnections);
        /// <summary> Gets or sets the RouteMaps compatibility property. </summary>
        [WirePath("properties.routeMaps")]
        public IReadOnlyList<WritableSubResource> RouteMaps => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.RouteMaps);
    }
}
