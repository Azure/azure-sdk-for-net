// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// A state of a server that is visible to user.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is retained only for backward compatibility with the legacy PostgreSQL single-server API.")]
public enum PostgreSqlServerState
{
    /// <summary>
    /// Ready.
    /// </summary>
    Ready,

    /// <summary>
    /// Dropping.
    /// </summary>
    Dropping,

    /// <summary>
    /// Disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// Inaccessible.
    /// </summary>
    Inaccessible,
}
