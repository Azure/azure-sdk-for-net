// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayFirewallRule type. </summary>
    [CodeGenSuppress("ApplicationGatewayFirewallRule", typeof(int))]
    public partial class ApplicationGatewayFirewallRule
    {
        /// <summary> Initializes a new instance of the ApplicationGatewayFirewallRule class. </summary>
        public ApplicationGatewayFirewallRule(int ruleId)
        {
            RuleId = ruleId;
        }
    }
}
