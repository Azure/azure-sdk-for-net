// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Whether or not public network access is allowed for this server. Value is
/// optional but if passed in, must be &apos;Enabled&apos; or
/// &apos;Disabled&apos;.
/// </summary>
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
