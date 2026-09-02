// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    // NetAppBackupVaultBackupResource itself is generated from the current Backup.tsp
    // backup-vault child resource. This partial only keeps custom compatibility members:
    // - RestoreFilesBackupsUnderBackupVault* preserve the previous SDK's longer method names.
    public partial class NetAppBackupVaultBackupResource
    {
        /// <summary> Restore files from a backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RestoreFilesBackupsUnderBackupVaultAsync(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            return await RestoreFilesAsync(waitUntil, body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Restore files from a backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation RestoreFilesBackupsUnderBackupVault(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            return RestoreFiles(waitUntil, body, cancellationToken);
        }
    }
}
