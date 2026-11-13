// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Specifies the state of the policy, whether it is enabled or disabled.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use ServerThreatProtectionSettingsModel.State with ThreatProtectionState instead.")]
public enum PostgreSqlServerSecurityAlertPolicyState
{
    /// <summary>
    /// Enabled.
    /// </summary>
    Enabled,

    /// <summary>
    /// Disabled.
    /// </summary>
    Disabled,
}
