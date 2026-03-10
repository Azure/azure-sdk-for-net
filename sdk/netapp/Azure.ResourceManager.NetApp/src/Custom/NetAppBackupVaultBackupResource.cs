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
        // TODO: BackupRestoreFiles type and RestoreFilesAsync/RestoreFiles methods no longer exist
        // on NetAppBackupVaultBackupResource after TypeSpec migration. The equivalent is on BackupResource.
        // These backward compat shims need to be reworked if they are still needed.
        //
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public virtual async Task<ArmOperation> RestoreFilesBackupsUnderBackupVaultAsync(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        // {
        //     var restoreFiles = new BackupRestoreFiles(body.FileList, body.DestinationVolumeId?.ToString());
        //     return await RestoreFilesAsync(waitUntil, restoreFiles, cancellationToken).ConfigureAwait(false);
        // }
        //
        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public virtual ArmOperation RestoreFilesBackupsUnderBackupVault(WaitUntil waitUntil, NetAppVolumeBackupBackupRestoreFilesContent body, CancellationToken cancellationToken = default)
        // {
        //     var restoreFiles = new BackupRestoreFiles(body.FileList, body.DestinationVolumeId?.ToString());
        //     return RestoreFiles(waitUntil, restoreFiles, cancellationToken);
        // }
    }
}
