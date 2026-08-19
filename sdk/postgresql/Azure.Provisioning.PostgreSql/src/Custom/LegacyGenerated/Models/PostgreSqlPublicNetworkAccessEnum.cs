// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Whether or not public network access is allowed for this server. Value is
/// optional but if passed in, must be &apos;Enabled&apos; or
/// &apos;Disabled&apos;.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer.Network with PostgreSqlFlexibleServerPublicNetworkAccessState instead.")]
public enum PostgreSqlPublicNetworkAccessEnum
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
