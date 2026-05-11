// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // The generated model has only an internal constructor because BackupVaultId is read-only.
    // v1.15 exposed this public string constructor, so keep it for source compatibility.
    public partial class BackupsMigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault as string. </param>
        public BackupsMigrationContent(string backupVaultId)
        {
            Argument.AssertNotNull(backupVaultId, nameof(backupVaultId));
            BackupVaultId = backupVaultId;
        }
    }
}
