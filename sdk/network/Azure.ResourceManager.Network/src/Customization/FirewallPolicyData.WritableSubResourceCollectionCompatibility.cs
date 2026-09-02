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
    /// <summary> Compatibility declaration for the FirewallPolicyData type. </summary>
    [CodeGenSuppress("ChildPolicies")]
    [CodeGenSuppress("Firewalls")]
    [CodeGenSuppress("RuleCollectionGroups")]
    public partial class FirewallPolicyData
    {
        /// <summary> Gets or sets the ChildPolicies compatibility property. </summary>
        [WirePath("properties.childPolicies")]
        public IReadOnlyList<WritableSubResource> ChildPolicies => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.ChildPolicies);
        /// <summary> Gets or sets the Firewalls compatibility property. </summary>
        [WirePath("properties.firewalls")]
        public IReadOnlyList<WritableSubResource> Firewalls => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Firewalls);
        /// <summary> Gets or sets the RuleCollectionGroups compatibility property. </summary>
        [WirePath("properties.ruleCollectionGroups")]
        public IReadOnlyList<WritableSubResource> RuleCollectionGroups => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.RuleCollectionGroups);
    }
}
