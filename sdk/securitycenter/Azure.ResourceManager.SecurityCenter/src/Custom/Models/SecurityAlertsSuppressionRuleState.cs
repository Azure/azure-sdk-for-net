// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    // Backward compatibility: preserve the previous non-extensible enum shape for suppression rule state.
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
