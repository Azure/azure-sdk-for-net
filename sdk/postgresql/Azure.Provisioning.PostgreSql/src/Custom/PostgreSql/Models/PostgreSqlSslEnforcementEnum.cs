// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Enable ssl enforcement or not when connect to server.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServerConfiguration for the require_secure_transport server parameter instead.")]
public enum PostgreSqlSslEnforcementEnum
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
