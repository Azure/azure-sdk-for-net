// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The private link service connection status.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus instead.")]
public enum PostgreSqlPrivateLinkServiceConnectionStateStatus
{
    /// <summary>
    /// Approved.
    /// </summary>
    Approved,

    /// <summary>
    /// Pending.
    /// </summary>
    Pending,

    /// <summary>
    /// Rejected.
    /// </summary>
    Rejected,

    /// <summary>
    /// Disconnected.
    /// </summary>
    Disconnected,
}
