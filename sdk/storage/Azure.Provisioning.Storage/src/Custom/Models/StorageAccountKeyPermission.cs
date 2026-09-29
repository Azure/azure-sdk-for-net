// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

// Provisioning generation omits the listKeys action result, including this shipped permission enum.
// Remove this type when action generation is supported: https://github.com/Azure/azure-sdk-for-net/issues/56753.
/// <summary> Permissions for the key -- read-only or full permissions. </summary>
public enum StorageAccountKeyPermission
{
    /// <summary>
    /// Read.
    /// </summary>
    Read,

    /// <summary>
    /// Full.
    /// </summary>
    Full,
}
