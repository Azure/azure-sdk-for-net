// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayFirewallRule type. </summary>
    public partial class ApplicationGatewayFirewallRule
    {
        /// <summary> Gets or sets the Action compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleActionType> Action
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the Description compatibility property. </summary>
        public System.String Description
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the RuleId compatibility property. </summary>
        public System.Int32 RuleId
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the RuleIdString compatibility property. </summary>
        public System.String RuleIdString
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the Sensitivity compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleSensitivityType> Sensitivity
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }

        /// <summary> Gets or sets the State compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.ApplicationGatewayWafRuleStateType> State
        {
            get => default;
            set
            {
                // Compatibility setter for previous GA surface; service value remains read-only.
            }
        }
    }
}
