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
    [CodeGenSuppress("EgressNatRules")]
    [CodeGenSuppress("IngressNatRules")]
    public partial class VpnSiteLinkConnectionData
    {
        [WirePath("properties.egressNatRules")] public IList<WritableSubResource> EgressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.EgressNatRules);
        [WirePath("properties.ingressNatRules")] public IList<WritableSubResource> IngressNatRules => WritableSubResourceCollectionCompatibility.AsList(Properties?.IngressNatRules);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
