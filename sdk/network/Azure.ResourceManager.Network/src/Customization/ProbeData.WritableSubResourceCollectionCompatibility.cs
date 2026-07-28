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
    /// <summary> Compatibility declaration for the ProbeData type. </summary>
    [CodeGenSuppress("LoadBalancingRules")]
    public partial class ProbeData
    {
        /// <summary> Gets or sets the LoadBalancingRules compatibility property. </summary>
        [WirePath("properties.loadBalancingRules")]
        public IReadOnlyList<WritableSubResource> LoadBalancingRules => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.LoadBalancingRules);
    }
}
