// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The key type like &apos;AzureKeyVault&apos;.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer.DataEncryption with PostgreSqlFlexibleServerKeyType instead.")]
public enum PostgreSqlServerKeyType
{
    /// <summary>
    /// AzureKeyVault.
    /// </summary>
    AzureKeyVault,
}
