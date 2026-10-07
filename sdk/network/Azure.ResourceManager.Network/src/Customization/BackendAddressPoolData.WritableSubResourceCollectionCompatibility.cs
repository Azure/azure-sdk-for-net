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
    /// <summary> Compatibility declaration for the BackendAddressPoolData type. </summary>
    [CodeGenSuppress("InboundNatRules")]
    [CodeGenSuppress("LoadBalancingRules")]
    [CodeGenSuppress("OutboundRules")]
    public partial class BackendAddressPoolData
    {
        /// <summary> Gets or sets the InboundNatRules compatibility property. </summary>
        [WirePath("properties.inboundNatRules")]
        public IReadOnlyList<WritableSubResource> InboundNatRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.InboundNatRules);
        /// <summary> Gets or sets the LoadBalancingRules compatibility property. </summary>
        [WirePath("properties.loadBalancingRules")]
        public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
        /// <summary> Gets or sets the OutboundRules compatibility property. </summary>
        [WirePath("properties.outboundRules")]
        public IReadOnlyList<WritableSubResource> OutboundRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.OutboundRules);
    }
}
