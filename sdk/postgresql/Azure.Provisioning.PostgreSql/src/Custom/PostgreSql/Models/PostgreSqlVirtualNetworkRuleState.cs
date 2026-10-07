// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Virtual Network Rule State.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer.Network with DelegatedSubnetResourceId for flexible-server networking instead.")]
public enum PostgreSqlVirtualNetworkRuleState
{
    /// <summary>
    /// Initializing.
    /// </summary>
    Initializing,

    /// <summary>
    /// InProgress.
    /// </summary>
    InProgress,

    /// <summary>
    /// Ready.
    /// </summary>
    Ready,

    /// <summary>
    /// Deleting.
    /// </summary>
    Deleting,

    /// <summary>
    /// Unknown.
    /// </summary>
    Unknown,
}
