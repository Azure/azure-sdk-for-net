// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Enable Storage Auto Grow.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer.Storage with StorageAutoGrow instead.")]
public enum PostgreSqlStorageAutogrow
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
