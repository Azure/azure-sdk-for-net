// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec changed the suppression rule state representation from the GA non-extensible enum; custom code keeps the previous enum type used by constructors and model factory overloads.
    /// <summary> Possible states of the rule. </summary>
    public enum SecurityAlertsSuppressionRuleState
    {
        /// <summary> Enabled. </summary>
        Enabled,
        /// <summary> Disabled. </summary>
        Disabled,
        /// <summary> Expired. </summary>
        Expired
    }
}
