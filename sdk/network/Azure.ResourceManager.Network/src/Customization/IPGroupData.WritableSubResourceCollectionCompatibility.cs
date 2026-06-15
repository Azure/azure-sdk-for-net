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
    [CodeGenSuppress("FirewallPolicies")]
    [CodeGenSuppress("Firewalls")]
    public partial class IPGroupData
    {
        [WirePath("properties.firewallPolicies")] public IReadOnlyList<WritableSubResource> FirewallPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.FirewallPolicies);
        [WirePath("properties.firewalls")] public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
