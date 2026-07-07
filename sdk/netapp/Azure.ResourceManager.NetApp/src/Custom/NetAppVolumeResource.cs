// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    // Restore GA-shipped operation method names that the new spec renamed or moved. The
    // current spec can only choose one generated name for each operation; several old SDK
    // methods below are aliases for the same generated operation or target legacy routes, so
    // they remain SDK-side compatibility methods instead of @@clientName customizations.
    // - GetBackupStatus / GetLatestStatusBackup     -> delegate to generated GetLatestStatus
    // - GetRestoreStatus / GetVolumeLatestRestoreStatusBackup -> delegate to GetVolumeLatestRestoreStatus
    // - GetReplicationStatus                        -> SDK-side implementation; generated ReplicationStatus name is suppressed
    // - MigrateBackupsBackupsUnderVolume            -> delegate to generated MigrateBackups
    // - GetReplications(CancellationToken)          -> overload resolving to generated GetReplications(content, ct)
    // - GetNetAppVolumeBackup(s)                    -> throw: backup collection moved to NetAppBackupVaultBackupResource
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ReplicationStatus", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ReplicationStatusAsync", typeof(CancellationToken))]
    public partial class NetAppVolumeResource
    {
        /// <summary> Get the status of the backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeBackupStatus> GetBackupStatus(CancellationToken cancellationToken = default)
            => GetLatestStatus(cancellationToken);

        /// <summary> Get the status of the backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppVolumeBackupStatus>> GetBackupStatusAsync(CancellationToken cancellationToken = default)
            => GetLatestStatusAsync(cancellationToken);

        /// <summary> Get the status of the latest backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeBackupStatus> GetLatestStatusBackup(CancellationToken cancellationToken = default)
            => GetLatestStatus(cancellationToken);

        /// <summary> Get the status of the latest backup for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppVolumeBackupStatus>> GetLatestStatusBackupAsync(CancellationToken cancellationToken = default)
            => GetLatestStatusAsync(cancellationToken);

        /// <summary> Get the status of the restore for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppRestoreStatus> GetRestoreStatus(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatus(cancellationToken);

        /// <summary> Get the status of the restore for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppRestoreStatus>> GetRestoreStatusAsync(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatusAsync(cancellationToken);

        /// <summary> Get the status of the latest restore for a volume's backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppRestoreStatus> GetVolumeLatestRestoreStatusBackup(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatus(cancellationToken);

        /// <summary> Get the status of the latest restore for a volume's backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppRestoreStatus>> GetVolumeLatestRestoreStatusBackupAsync(CancellationToken cancellationToken = default)
            => GetVolumeLatestRestoreStatusAsync(cancellationToken);

        // The generated `ReplicationStatus` / `ReplicationStatusAsync` method names drop
        // the `Get` verb prefix, so suppress them and keep the GA-shipped verb-style names.
        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeReplicationStatus> GetReplicationStatus(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _volumesClientDiagnostics.CreateScope("NetAppVolumeResource.GetReplicationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _volumesRestClient.CreateReplicationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetAppVolumeReplicationStatus> response = Response.FromValue(NetAppVolumeReplicationStatus.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeReplicationStatus>> GetReplicationStatusAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _volumesClientDiagnostics.CreateScope("NetAppVolumeResource.GetReplicationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _volumesRestClient.CreateReplicationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetAppVolumeReplicationStatus> response = Response.FromValue(NetAppVolumeReplicationStatus.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
        public virtual ArmOperation MigrateBackupsBackupsUnderVolume(WaitUntil waitUntil, BackupsMigrationContent content, CancellationToken cancellationToken = default)
            => MigrateBackups(waitUntil, content, cancellationToken);

        /// <summary> Migrate backups under a volume to a backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
