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
    [CodeGenSuppress("InboundNatPools")]
    [CodeGenSuppress("InboundNatRules")]
    [CodeGenSuppress("LoadBalancingRules")]
    [CodeGenSuppress("OutboundRules")]
    public partial class FrontendIPConfigurationData
    {
        [WirePath("properties.inboundNatPools")] public IReadOnlyList<WritableSubResource> InboundNatPools => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatPools);
        [WirePath("properties.inboundNatRules")] public IReadOnlyList<WritableSubResource> InboundNatRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatRules);
        [WirePath("properties.loadBalancingRules")] public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
        [WirePath("properties.outboundRules")] public IReadOnlyList<WritableSubResource> OutboundRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.OutboundRules);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
