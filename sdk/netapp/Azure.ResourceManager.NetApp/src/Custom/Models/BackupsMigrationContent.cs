// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // v1.15 exposed BackupVaultId as string. The generated model now uses
    // ResourceIdentifier, so keep the old string constructor/property as aliases.
    public partial class BackupsMigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault as string. </param>
        public BackupsMigrationContent(string backupVaultId)
        {
            Argument.AssertNotNull(backupVaultId, nameof(backupVaultId));
            BackupVaultResourceId = new ResourceIdentifier(backupVaultId);
        }

        /// <summary> The ResourceId of the Backup Vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackupVaultId => BackupVaultResourceId?.ToString();
    }
}
