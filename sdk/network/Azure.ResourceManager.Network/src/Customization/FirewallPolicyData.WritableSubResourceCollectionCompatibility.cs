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
    [CodeGenSuppress("ChildPolicies")]
    [CodeGenSuppress("Firewalls")]
    [CodeGenSuppress("RuleCollectionGroups")]
    public partial class FirewallPolicyData
    {
        [WirePath("properties.childPolicies")] public IReadOnlyList<WritableSubResource> ChildPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.ChildPolicies);
        [WirePath("properties.firewalls")] public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
        [WirePath("properties.ruleCollectionGroups")] public IReadOnlyList<WritableSubResource> RuleCollectionGroups => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.RuleCollectionGroups);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
