// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppBackupVaultBackupResource. </summary>
    public partial class NetAppBackupVaultBackupResource : ArmResource
    {
        /// <summary> Restore the specified files from the specified backup to the active filesystem. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="body"> Restore payload supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RestoreFilesBackupsUnderBackupVaultAsync(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            var restoreFiles = new BackupRestoreFiles(body.FileList, body.DestinationVolumeId?.ToString());
            return await RestoreFilesAsync(waitUntil, restoreFiles, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Restore the specified files from the specified backup to the active filesystem. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="body"> Restore payload supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation RestoreFilesBackupsUnderBackupVault(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        {
            var restoreFiles = new BackupRestoreFiles(body.FileList, body.DestinationVolumeId?.ToString());
            return RestoreFiles(waitUntil, restoreFiles, cancellationToken);
        }
    }
}
