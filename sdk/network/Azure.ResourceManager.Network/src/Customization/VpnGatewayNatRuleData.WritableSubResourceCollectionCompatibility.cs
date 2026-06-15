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
    [CodeGenSuppress("EgressVpnSiteLinkConnections")]
    [CodeGenSuppress("IngressVpnSiteLinkConnections")]
    public partial class VpnGatewayNatRuleData
    {
        [WirePath("properties.egressVpnSiteLinkConnections")] public IReadOnlyList<WritableSubResource> EgressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.EgressVpnSiteLinkConnections);
        [WirePath("properties.ingressVpnSiteLinkConnections")] public IReadOnlyList<WritableSubResource> IngressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.IngressVpnSiteLinkConnections);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
