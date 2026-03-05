// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> Backward-compat shims for NetAppBackupVaultBackupCollection. </summary>
    public partial class NetAppBackupVaultBackupCollection : ArmCollection
    {
        /// <summary> Create a backup under the Backup Vault. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup data supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppBackupVaultBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            var vaultData = new NetAppBackupVaultBackupData(data.VolumeResourceId)
            {
                Label = data.Label,
                SnapshotName = data.SnapshotName,
            };
            if (data.UseExistingSnapshot.HasValue)
            {
                vaultData.UseExistingSnapshot = data.UseExistingSnapshot.Value;
            }
            return await CreateOrUpdateAsync(waitUntil, backupName, vaultData, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Create a backup under the Backup Vault. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup data supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppBackupVaultBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            var vaultData = new NetAppBackupVaultBackupData(data.VolumeResourceId)
            {
                Label = data.Label,
                SnapshotName = data.SnapshotName,
            };
            if (data.UseExistingSnapshot.HasValue)
            {
                vaultData.UseExistingSnapshot = data.UseExistingSnapshot.Value;
            }
            return CreateOrUpdate(waitUntil, backupName, vaultData, cancellationToken);
        }
    }
}
