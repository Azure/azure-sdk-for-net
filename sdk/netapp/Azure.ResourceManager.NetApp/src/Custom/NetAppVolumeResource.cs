// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    // Restore GA-shipped operation method names that the new spec renamed or moved.
    // - GetBackupStatus / GetLatestStatusBackup     -> delegate to generated GetLatestStatus
    // - GetRestoreStatus / GetVolumeLatestRestoreStatusBackup -> delegate to GetVolumeLatestRestoreStatus
    // - GetReplicationStatus                        -> delegate to generated ReplicationStatus
    // - MigrateBackupsBackupsUnderVolume            -> delegate to generated MigrateBackups
    // - GetReplications(CancellationToken)          -> overload resolving to generated GetReplications(content, ct)
    // - GetNetAppVolumeBackup(s)                    -> throw: backup collection moved to NetAppBackupVaultBackupResource
    public partial class NetAppVolumeResource
    {
        /// <summary> Get the status of the backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetLatestStatus instead.", false)]
        public virtual Response<NetAppVolumeBackupStatus> GetBackupStatus(CancellationToken cancellationToken = default)
            => GetLatestStatus(cancellationToken);

        /// <summary> Get the status of the backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetLatestStatusAsync instead.", false)]
        public virtual Task<Response<NetAppVolumeBackupStatus>> GetBackupStatusAsync(CancellationToken cancellationToken = default)
            => GetLatestStatusAsync(cancellationToken);

        /// <summary> Get the status of the latest backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetLatestStatus instead.", false)]
        public virtual Response<NetAppVolumeBackupStatus> GetLatestStatusBackup(CancellationToken cancellationToken = default)
            => GetLatestStatus(cancellationToken);

        /// <summary> Get the status of the latest backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetLatestStatusAsync instead.", false)]
        public virtual Task<Response<NetAppVolumeBackupStatus>> GetLatestStatusBackupAsync(CancellationToken cancellationToken = default)
            => GetLatestStatusAsync(cancellationToken);

        /// <summary> Get the status of the restore for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetVolumeLatestRestoreStatus instead.", false)]
        public virtual Response<NetAppRestoreStatus> GetRestoreStatus(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatus(cancellationToken);

        /// <summary> Get the status of the restore for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetVolumeLatestRestoreStatusAsync instead.", false)]
        public virtual Task<Response<NetAppRestoreStatus>> GetRestoreStatusAsync(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatusAsync(cancellationToken);

        /// <summary> Get the status of the latest restore for a volume's backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetVolumeLatestRestoreStatus instead.", false)]
        public virtual Response<NetAppRestoreStatus> GetVolumeLatestRestoreStatusBackup(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatus(cancellationToken);

        /// <summary> Get the status of the latest restore for a volume's backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use GetVolumeLatestRestoreStatusAsync instead.", false)]
        public virtual Task<Response<NetAppRestoreStatus>> GetVolumeLatestRestoreStatusBackupAsync(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatusAsync(cancellationToken);

        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use ReplicationStatus instead.", false)]
        public virtual Response<NetAppVolumeReplicationStatus> GetReplicationStatus(CancellationToken cancellationToken = default)
            => ReplicationStatus(cancellationToken);

        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use ReplicationStatusAsync instead.", false)]
        public virtual Task<Response<NetAppVolumeReplicationStatus>> GetReplicationStatusAsync(CancellationToken cancellationToken = default)
            => ReplicationStatusAsync(cancellationToken);

        /// <summary> List replications for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeReplication> GetReplications(CancellationToken cancellationToken)
            => GetReplications(content: default, cancellationToken);

        /// <summary> List replications for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeReplication> GetReplicationsAsync(CancellationToken cancellationToken)
            => GetReplicationsAsync(content: default, cancellationToken);

        /// <summary> Migrate backups under a volume to a backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use MigrateBackups instead.", false)]
        public virtual ArmOperation MigrateBackupsBackupsUnderVolume(WaitUntil waitUntil, BackupsMigrationContent content, CancellationToken cancellationToken = default)
            => MigrateBackups(waitUntil, content, cancellationToken);

        /// <summary> Migrate backups under a volume to a backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Use MigrateBackupsAsync instead.", false)]
        public virtual Task<ArmOperation> MigrateBackupsBackupsUnderVolumeAsync(WaitUntil waitUntil, BackupsMigrationContent content, CancellationToken cancellationToken = default)
            => MigrateBackupsAsync(waitUntil, content, cancellationToken);

        // Backups are no longer a child collection of volumes in the new spec; the GA-shipped
        // child accessors throw with guidance to use NetAppBackupVaultBackupResource instead.
        /// <summary> Gets a collection of NetAppVolumeBackupResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Volume-scoped backups have moved to NetAppBackupVaultBackupResource.", false)]
        public virtual NetAppVolumeBackupCollection GetNetAppVolumeBackups()
            => throw new NotSupportedException("Volume-scoped backups have moved to NetAppBackupVaultBackupResource. Use NetAppBackupVaultResource.GetNetAppBackupVaultBackups() instead.");

        /// <summary> Gets a NetAppVolumeBackupResource by name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Volume-scoped backups have moved to NetAppBackupVaultBackupResource.", false)]
        public virtual Response<NetAppVolumeBackupResource> GetNetAppVolumeBackup(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Volume-scoped backups have moved to NetAppBackupVaultBackupResource. Use NetAppBackupVaultResource.GetNetAppBackupVaultBackup(...) instead.");

        /// <summary> Gets a NetAppVolumeBackupResource by name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        [Obsolete("This method is obsolete and will be removed in a future release. Volume-scoped backups have moved to NetAppBackupVaultBackupResource.", false)]
        public virtual Task<Response<NetAppVolumeBackupResource>> GetNetAppVolumeBackupAsync(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Volume-scoped backups have moved to NetAppBackupVaultBackupResource. Use NetAppBackupVaultResource.GetNetAppBackupVaultBackupAsync(...) instead.");
    }
}
