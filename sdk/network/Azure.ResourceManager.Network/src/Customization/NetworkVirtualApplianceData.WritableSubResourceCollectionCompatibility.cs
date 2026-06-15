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
    [CodeGenSuppress("InboundSecurityRules")]
    [CodeGenSuppress("VirtualApplianceConnections")]
    [CodeGenSuppress("VirtualApplianceSites")]
    public partial class NetworkVirtualApplianceData
    {
        [WirePath("properties.inboundSecurityRules")] public IReadOnlyList<WritableSubResource> InboundSecurityRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundSecurityRules);
        [WirePath("properties.virtualApplianceConnections")] public IReadOnlyList<WritableSubResource> VirtualApplianceConnections => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceConnections);
        [WirePath("properties.virtualApplianceSites")] public IReadOnlyList<WritableSubResource> VirtualApplianceSites => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.VirtualApplianceSites);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
