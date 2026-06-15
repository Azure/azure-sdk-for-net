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

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("VirtualHubs")]
    [CodeGenSuppress("VpnSites")]
    public partial class VirtualWanData
    {
        [WirePath("properties.virtualHubs")] public IReadOnlyList<WritableSubResource> VirtualHubs => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualHubs);
        [WirePath("properties.vpnSites")] public IReadOnlyList<WritableSubResource> VpnSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VpnSites);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
