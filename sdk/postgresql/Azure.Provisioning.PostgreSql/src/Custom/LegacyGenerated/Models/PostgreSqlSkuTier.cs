// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The tier of the particular SKU, e.g. Basic.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is retained only for backward compatibility with the legacy PostgreSQL single-server API.")]
public enum PostgreSqlSkuTier
{
    /// <summary>
    /// Basic.
    /// </summary>
    Basic,

    /// <summary>
    /// GeneralPurpose.
    /// </summary>
    GeneralPurpose,

    /// <summary>
    /// MemoryOptimized.
    /// </summary>
    MemoryOptimized,
}
