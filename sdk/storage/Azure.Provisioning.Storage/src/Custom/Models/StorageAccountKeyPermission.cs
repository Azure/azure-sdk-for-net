// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

// TypeSpec omits the listKeys response enum. Preserve the shipped type and ordinal order.
/// <summary>
/// Permissions for a storage account key.
/// </summary>
public enum StorageAccountKeyPermission
{
    /// <summary> Read-only permissions. </summary>
    Read,

    /// <summary> Full permissions. </summary>
    Full,
}
