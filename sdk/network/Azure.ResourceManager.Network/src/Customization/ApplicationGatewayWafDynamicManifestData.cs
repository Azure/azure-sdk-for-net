// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class ApplicationGatewayWafDynamicManifestData
    {
        // Native flattening exposes IList<T>; 1.15 requires a read-only view of the same deserialized rule sets.
        /// <summary> The available rulesets. </summary>
        [CodeGenMember("AvailableRuleSets")]
        [WirePath("properties.availableRuleSets")]
        public IReadOnlyList<ApplicationGatewayFirewallManifestRuleSet> AvailableRuleSets
        {
            get
            {
                IList<ApplicationGatewayFirewallManifestRuleSet> ruleSets = Properties?.AvailableRuleSets;
                return ruleSets is null ? null : new ReadOnlyCollection<ApplicationGatewayFirewallManifestRuleSet>(ruleSets);
            }
        }
    }
}
