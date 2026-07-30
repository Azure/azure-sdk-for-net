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
    /// <summary> Compatibility declaration for the VpnGatewayNatRuleData type. </summary>
    [CodeGenSuppress("EgressVpnSiteLinkConnections")]
    [CodeGenSuppress("IngressVpnSiteLinkConnections")]
    public partial class VpnGatewayNatRuleData
    {
        /// <summary> Gets or sets the EgressVpnSiteLinkConnections compatibility property. </summary>
        [WirePath("properties.egressVpnSiteLinkConnections")]
        public IReadOnlyList<WritableSubResource> EgressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.EgressVpnSiteLinkConnections);
        /// <summary> Gets or sets the IngressVpnSiteLinkConnections compatibility property. </summary>
        [WirePath("properties.ingressVpnSiteLinkConnections")]
        public IReadOnlyList<WritableSubResource> IngressVpnSiteLinkConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.IngressVpnSiteLinkConnections);
    }
}
