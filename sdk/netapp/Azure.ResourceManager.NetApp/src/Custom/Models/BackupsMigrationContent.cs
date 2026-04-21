// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Backup migration content. </summary>
    public partial class BackupsMigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault as string. </param>
        public BackupsMigrationContent(string backupVaultId)
        {
            Argument.AssertNotNull(backupVaultId, nameof(backupVaultId));
            BackupVaultId = backupVaultId;
        }

        /// <summary> Initializes a new instance of <see cref="BackupsMigrationContent"/>. </summary>
        /// <param name="backupVaultId"> The resource ID of the backup vault. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackupsMigrationContent(ResourceIdentifier backupVaultId) : this(backupVaultId?.ToString()) { }
    }
}
