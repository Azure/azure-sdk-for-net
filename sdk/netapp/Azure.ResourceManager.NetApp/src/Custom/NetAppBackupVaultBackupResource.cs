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
        /// <summary> Gets the data representing this Feature (old API type). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppBackupData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new System.InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                var d = BackupVaultBackupData;
                return new NetAppBackupData(d.Id, d.Name, d.ResourceType, d.SystemData, default(Azure.Core.AzureLocation), d.BackupId, d.CreatedOn, d.ProvisioningState, d.Size, d.Label, d.BackupType, d.FailureReason, d.VolumeResourceId, d.UseExistingSnapshot, d.SnapshotName, d.BackupPolicyResourceId);
            }
        }

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
