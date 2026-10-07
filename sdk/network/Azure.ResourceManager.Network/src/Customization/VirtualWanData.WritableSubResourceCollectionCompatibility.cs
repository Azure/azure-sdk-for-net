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
    /// <summary> Compatibility declaration for the VirtualWanData type. </summary>
    [CodeGenSuppress("VirtualHubs")]
    [CodeGenSuppress("VpnSites")]
    public partial class VirtualWanData
    {
        /// <summary> Gets or sets the VirtualHubs compatibility property. </summary>
        [WirePath("properties.virtualHubs")]
        public IReadOnlyList<WritableSubResource> VirtualHubs => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualHubs);
        /// <summary> Gets or sets the VpnSites compatibility property. </summary>
        [WirePath("properties.vpnSites")]
        public IReadOnlyList<WritableSubResource> VpnSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VpnSites);
    }
}
