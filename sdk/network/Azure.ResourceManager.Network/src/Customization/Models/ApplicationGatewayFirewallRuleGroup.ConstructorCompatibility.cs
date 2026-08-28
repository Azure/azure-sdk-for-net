// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayFirewallRuleGroup type. </summary>
    [CodeGenSuppress("ApplicationGatewayFirewallRuleGroup")]
    public partial class ApplicationGatewayFirewallRuleGroup
    {
        /// <summary> Initializes a new instance of the ApplicationGatewayFirewallRuleGroup class. </summary>
        public ApplicationGatewayFirewallRuleGroup(string ruleGroupName, System.Collections.Generic.IEnumerable<ApplicationGatewayFirewallRule> rules)
        {
            RuleGroupName = ruleGroupName;
            foreach (var rule in rules ?? System.Linq.Enumerable.Empty<ApplicationGatewayFirewallRule>())
            {
                Rules.Add(rule);
            }
        }
    }
}
