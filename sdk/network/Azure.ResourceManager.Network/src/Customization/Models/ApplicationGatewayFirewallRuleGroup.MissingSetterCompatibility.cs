// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayFirewallRuleGroup type. </summary>
    public partial class ApplicationGatewayFirewallRuleGroup
    {
        /// <summary> Gets or sets the Description compatibility property. </summary>
        public System.String Description
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the RuleGroupName compatibility property. </summary>
        public System.String RuleGroupName
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
