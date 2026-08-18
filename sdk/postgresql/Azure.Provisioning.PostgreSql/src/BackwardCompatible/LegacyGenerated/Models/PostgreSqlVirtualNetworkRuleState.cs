// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Virtual Network Rule State.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is retained only for backward compatibility with the legacy PostgreSQL single-server API.")]
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
