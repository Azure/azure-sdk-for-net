// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.FrontDoor.Models;

namespace Azure.ResourceManager.FrontDoor
{
    public partial class FrontDoorWebApplicationFirewallPolicyData
    {
        // G4a — backward compat: baseline exposed customRules.rules as a flat IList<WebApplicationCustomRule> Rules.
        // The new generator names the flattened accessor CustomRuleListRules; expose it under the old name.
        /// <summary> List of rules. </summary>
        [WirePath("properties.customRules.rules")]
        public IList<WebApplicationCustomRule> Rules => CustomRuleListRules;

        // G4b — backward compat: baseline exposed managedRules.managedRuleSets as a flat IList<ManagedRuleSet> ManagedRuleSets.
        // The new generator exposes the wrapper object ManagedRules; unwrap and forward the inner list.
        /// <summary> Describes managed rule sets inside the policy. </summary>
        [WirePath("properties.managedRules.managedRuleSets")]
        public IList<ManagedRuleSet> ManagedRuleSets => ManagedRules?.ManagedRuleSets;
    }
}
