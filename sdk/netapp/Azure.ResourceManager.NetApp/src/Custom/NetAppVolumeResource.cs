// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A Class representing a NetAppVolume along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="NetAppVolumeResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetNetAppVolumeResource method.
    /// Otherwise you can get one from its parent resource <see cref="CapacityPoolResource" /> using the GetNetAppVolume method.
    /// </summary>
    public partial class NetAppVolumeResource : ArmResource
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeResource"/> for mocking. </summary>
        protected NetAppVolumeResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeResource"/>. </summary>
        internal NetAppVolumeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
        private VaultsRestOperations _vaultsRestClient;
        private ClientDiagnostics _vaultsClientDiagnostics;

        private ClientDiagnostics VaultsClientDiagnostics => _vaultsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppAccountResource.ResourceType.Namespace, Diagnostics);
        private VaultsRestOperations VaultsRestClient => _vaultsRestClient ??= new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(NetAppAccountResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        private BackupsRestOperations _netAppVolumeBackupBackupsRestClient;
        private ClientDiagnostics _netAppVolumeBackupBackupsClientDiagnostics;

        private ClientDiagnostics NetAppVolumeBackupBackupsClientDiagnostics => _netAppVolumeBackupBackupsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppAccountResource.ResourceType.Namespace, Diagnostics);
        private BackupsRestOperations NetAppVolumeBackupBackupsRestClient => _netAppVolumeBackupBackupsRestClient ??= new BackupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(NetAppAccountResource.ResourceType));

        /// <summary> Gets a collection of NetAppVolumeBackupResources in the NetAppVolume. </summary>
        /// <returns> An object representing collection of NetAppVolumeBackupResources and their operations over a NetAppVolumeBackupResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeBackupCollection GetNetAppVolumeBackups()
        {
            return GetCachedClient(Client => new NetAppVolumeBackupCollection(Client, Id));
        }

        /// <summary>
        /// Get the status of the backup for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backupStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_GetStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeBackupStatus>> GetBackupStatusAsync(CancellationToken cancellationToken = default)
        {
            using var scope = NetAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeResource.GetBackupStatus");
            scope.Start();
            try
            {
                var response = await NetAppVolumeBackupBackupsRestClient.GetStatusAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status of the backup for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backupStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_GetStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeBackupStatus> GetBackupStatus(CancellationToken cancellationToken = default)
        {
            using var scope = NetAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeResource.GetBackupStatus");
            scope.Start();
            try
            {
                var response = NetAppVolumeBackupBackupsRestClient.GetStatus(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified backup of the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeBackupResource> GetNetAppVolumeBackup(string backupName, CancellationToken cancellationToken = default)
        {
            return GetNetAppVolumeBackups().Get(backupName, cancellationToken);
        }

        /// <summary>
        /// Gets the specified backup of the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeBackupResource>> GetNetAppVolumeBackupAsync(string backupName, CancellationToken cancellationToken = default)
        {
            return await GetNetAppVolumeBackups().GetAsync(backupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the status of the restore for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/restoreStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_GetVolumeRestoreStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-07-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetAppRestoreStatus>> GetRestoreStatusAsync(CancellationToken cancellationToken = default)
        {
            using var scope = NetAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeResource.GetVolumeLatestRestoreStatusBackup");
            scope.Start();
            try
            {
                var response = await NetAppVolumeBackupBackupsRestClient.GetVolumeLatestRestoreStatusAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status of the restore for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/restoreStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_GetVolumeRestoreStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-07-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetAppRestoreStatus> GetRestoreStatus(CancellationToken cancellationToken = default)
        {
            using var scope = NetAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeResource.GetVolumeLatestRestoreStatusBackup");
            scope.Start();
            try
            {
                var response = NetAppVolumeBackupBackupsRestClient.GetVolumeLatestRestoreStatus(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all replications for a specified volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/listReplications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_ListReplications</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetAppVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppVolumeReplication"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeReplication> GetReplicationsAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetReplicationsAsync instead.");
        }

        /// <summary>
        /// List all replications for a specified volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/listReplications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Volumes_ListReplications</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetAppVolumeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppVolumeReplication"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeReplication> GetReplications(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetReplications instead.");
        }

        // ---- Static members ----

        /// <summary> Generate the resource identifier of a <see cref="NetAppVolumeResource"/> instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName)
        {
            return VolumeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, poolName, volumeName);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceType ResourceType => VolumeResource.ResourceType;

        // ---- Instance property ----

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeData Data
        {
            get => throw new NotSupportedException("This property is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Data instead.");
        }

        /// <summary> Gets whether this resource has data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool HasData => false;

        // ---- Non-LRO methods ----

        /// <summary> Get the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Get instead.");
        }

        /// <summary> Get the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetAsync instead.");
        }

        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeReplicationStatus> GetReplicationStatus(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetReplicationStatus instead.");
        }

        /// <summary> Get the replication status for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeReplicationStatus>> GetReplicationStatusAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetReplicationStatusAsync instead.");
        }

        /// <summary> Get the quota report for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeQuotaReport> GetQuotaReport(QuotaReportFilterContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetQuotaReport instead.");
        }

        /// <summary> Get the quota report for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeQuotaReport> GetQuotaReportAsync(QuotaReportFilterContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetQuotaReportAsync instead.");
        }

        /// <summary> Returns the list of group Ids for a specific LDAP User. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GetGroupIdListForLdapUserResult> GetGroupIdListForLdapUser(GetGroupIdListForLdapUserContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetGroupIdListForLdapUser instead.");
        }

        /// <summary> Returns the list of group Ids for a specific LDAP User. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<GetGroupIdListForLdapUserResult>> GetGroupIdListForLdapUserAsync(GetGroupIdListForLdapUserContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.GetGroupIdListForLdapUserAsync instead.");
        }

        /// <summary> Get a NetAppVolumeQuotaRuleResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppVolumeQuotaRuleResource> GetNetAppVolumeQuotaRule(string quotaRuleName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get a NetAppVolumeQuotaRuleResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppVolumeQuotaRuleResource>> GetNetAppVolumeQuotaRuleAsync(string quotaRuleName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Gets a collection of NetAppVolumeQuotaRuleResources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeQuotaRuleCollection GetNetAppVolumeQuotaRules()
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get a NetAppVolumeSnapshotResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppVolumeSnapshotResource> GetNetAppVolumeSnapshot(string snapshotName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get a NetAppVolumeSnapshotResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppVolumeSnapshotResource>> GetNetAppVolumeSnapshotAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Gets a collection of NetAppVolumeSnapshotResources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppVolumeSnapshotCollection GetNetAppVolumeSnapshots()
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        // ---- LRO operation methods (returning ArmOperation) ----

        /// <summary> Authorize the replication connection on the source volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation AuthorizeReplication(WaitUntil waitUntil, NetAppVolumeAuthorizeReplicationContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.AuthorizeReplication instead.");
        }

        /// <summary> Authorize the replication connection on the source volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> AuthorizeReplicationAsync(WaitUntil waitUntil, NetAppVolumeAuthorizeReplicationContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.AuthorizeReplicationAsync instead.");
        }

        /// <summary> Break file locks. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation BreakFileLocks(WaitUntil waitUntil, NetAppVolumeBreakFileLocksContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.BreakFileLocks instead.");
        }

        /// <summary> Break file locks. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> BreakFileLocksAsync(WaitUntil waitUntil, NetAppVolumeBreakFileLocksContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.BreakFileLocksAsync instead.");
        }

        /// <summary> Break the replication connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation BreakReplication(WaitUntil waitUntil, NetAppVolumeBreakReplicationContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.BreakReplication instead.");
        }

        /// <summary> Break the replication connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> BreakReplicationAsync(WaitUntil waitUntil, NetAppVolumeBreakReplicationContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.BreakReplicationAsync instead.");
        }

        /// <summary> Delete the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? forceDelete, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Delete instead.");
        }

        /// <summary> Delete the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? forceDelete, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.DeleteAsync instead.");
        }

        /// <summary> Delete the replication connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation DeleteReplication(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.DeleteReplication instead.");
        }

        /// <summary> Delete the replication connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteReplicationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.DeleteReplicationAsync instead.");
        }

        /// <summary> Finalize the external replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation FinalizeExternalReplication(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.FinalizeExternalReplication instead.");
        }

        /// <summary> Finalize the external replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FinalizeExternalReplicationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.FinalizeExternalReplicationAsync instead.");
        }

        /// <summary> Finalize relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation FinalizeRelocation(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.FinalizeRelocation instead.");
        }

        /// <summary> Finalize relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> FinalizeRelocationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.FinalizeRelocationAsync instead.");
        }

        /// <summary> Migrate backups under volume to backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation MigrateBackupsBackupsUnderVolume(WaitUntil waitUntil, BackupsMigrationContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.MigrateBackupsBackupsUnderVolume instead.");
        }

        /// <summary> Migrate backups under volume to backup vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> MigrateBackupsBackupsUnderVolumeAsync(WaitUntil waitUntil, BackupsMigrationContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.MigrateBackupsBackupsUnderVolumeAsync instead.");
        }

        /// <summary> Perform a replication transfer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation PerformReplicationTransfer(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.PerformReplicationTransfer instead.");
        }

        /// <summary> Perform a replication transfer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> PerformReplicationTransferAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.PerformReplicationTransferAsync instead.");
        }

        /// <summary> Change pool for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation PoolChange(WaitUntil waitUntil, NetAppVolumePoolChangeContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.PoolChange instead.");
        }

        /// <summary> Change pool for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> PoolChangeAsync(WaitUntil waitUntil, NetAppVolumePoolChangeContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.PoolChangeAsync instead.");
        }

        /// <summary> Re-initialize replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ReInitializeReplication(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReInitializeReplication instead.");
        }

        /// <summary> Re-initialize replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ReInitializeReplicationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReInitializeReplicationAsync instead.");
        }

        /// <summary> Re-establish replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ReestablishReplication(WaitUntil waitUntil, NetAppVolumeReestablishReplicationContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReestablishReplication instead.");
        }

        /// <summary> Re-establish replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ReestablishReplicationAsync(WaitUntil waitUntil, NetAppVolumeReestablishReplicationContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReestablishReplicationAsync instead.");
        }

        /// <summary> Relocate volume to a new stamp. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Relocate(WaitUntil waitUntil, RelocateVolumeContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Relocate instead.");
        }

        /// <summary> Relocate volume to a new stamp. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RelocateAsync(WaitUntil waitUntil, RelocateVolumeContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.RelocateAsync instead.");
        }

        /// <summary> Reset CIFS password. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ResetCifsPassword(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ResetCifsPassword instead.");
        }

        /// <summary> Reset CIFS password. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ResetCifsPasswordAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ResetCifsPasswordAsync instead.");
        }

        /// <summary> Resync the connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ResyncReplication(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ResyncReplication instead.");
        }

        /// <summary> Resync the connection on the destination volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ResyncReplicationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ResyncReplicationAsync instead.");
        }

        /// <summary> Revert a volume to the snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Revert(WaitUntil waitUntil, NetAppVolumeRevertContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Revert instead.");
        }

        /// <summary> Revert a volume to the snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RevertAsync(WaitUntil waitUntil, NetAppVolumeRevertContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.RevertAsync instead.");
        }

        /// <summary> Reverse relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ReverseRelocation(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReverseRelocation instead.");
        }

        /// <summary> Reverse relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ReverseRelocationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ReverseRelocationAsync instead.");
        }

        /// <summary> Revert relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation RevertRelocation(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.RevertRelocation instead.");
        }

        /// <summary> Revert relocation of a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> RevertRelocationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.RevertRelocationAsync instead.");
        }

        // ---- LRO operation methods returning typed result ----

        /// <summary> Update the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeResource> Update(WaitUntil waitUntil, NetAppVolumePatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.Update instead.");
        }

        /// <summary> Update the specified volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeResource>> UpdateAsync(WaitUntil waitUntil, NetAppVolumePatch patch, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.UpdateAsync instead.");
        }

        /// <summary> Transition encryption. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation EncryptionTransition(WaitUntil waitUntil, NetAppEncryptionTransitionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.EncryptionTransition instead.");
        }

        /// <summary> Transition encryption. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> EncryptionTransitionAsync(WaitUntil waitUntil, NetAppEncryptionTransitionContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.EncryptionTransitionAsync instead.");
        }

        /// <summary> Change zone for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ChangeZone(WaitUntil waitUntil, ChangeZoneContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ChangeZone instead.");
        }

        /// <summary> Change zone for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ChangeZoneAsync(WaitUntil waitUntil, ChangeZoneContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource.ChangeZoneAsync instead.");
        }

        // --- Additional backward-compat stubs ---

        /// <summary> GetReplications with content filter. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeReplication> GetReplicationsAsync(ListReplicationsContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> GetReplications with content filter. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeReplication> GetReplications(ListReplicationsContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Peer external cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ClusterPeerCommandResult> PeerExternalCluster(WaitUntil waitUntil, PeerClusterForVolumeMigrationContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Peer external cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ClusterPeerCommandResult>> PeerExternalClusterAsync(WaitUntil waitUntil, PeerClusterForVolumeMigrationContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Authorize external replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SvmPeerCommandResult> AuthorizeExternalReplication(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Authorize external replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<SvmPeerCommandResult>> AuthorizeExternalReplicationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Populate availability zone. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeResource> PopulateAvailabilityZone(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Populate availability zone. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeResource>> PopulateAvailabilityZoneAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Split clone from parent. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetAppVolumeResource> SplitCloneFromParent(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Split clone from parent. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetAppVolumeResource>> SplitCloneFromParentAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get LDAP group ID list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<GetGroupIdListForLdapUserResult> GetGetGroupIdListForLdapUser(WaitUntil waitUntil, GetGroupIdListForLdapUserContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get LDAP group ID list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<GetGroupIdListForLdapUserResult>> GetGetGroupIdListForLdapUserAsync(WaitUntil waitUntil, GetGroupIdListForLdapUserContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get quota report (LRO version). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ListQuotaReportResult> GetQuotaReport(WaitUntil waitUntil, QuotaReportFilterContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get quota report (LRO version). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ListQuotaReportResult>> GetQuotaReportAsync(WaitUntil waitUntil, QuotaReportFilterContent content, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get subvolume infos collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubvolumeInfoCollection GetNetAppSubvolumeInfos()
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get subvolume info. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppSubvolumeInfoResource> GetNetAppSubvolumeInfo(string subvolumeName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get subvolume info. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppSubvolumeInfoResource>> GetNetAppSubvolumeInfoAsync(string subvolumeName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get ransomware reports collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual RansomwareReportCollection GetRansomwareReports()
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get a ransomware report. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<RansomwareReportResource> GetRansomwareReport(string ransomwareReportName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get a ransomware report. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<RansomwareReportResource>> GetRansomwareReportAsync(string ransomwareReportName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get latest backup restore status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppRestoreStatus> GetVolumeLatestRestoreStatusBackup(CancellationToken cancellationToken = default)
        {
            return GetRestoreStatus(cancellationToken);
        }

        /// <summary> Get latest backup restore status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppRestoreStatus>> GetVolumeLatestRestoreStatusBackupAsync(CancellationToken cancellationToken = default)
        {
            return await GetRestoreStatusAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get latest backup status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeBackupStatus> GetLatestStatusBackup(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Get latest backup status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeBackupStatus>> GetLatestStatusBackupAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Add a tag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Add a tag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Remove a tag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Remove a tag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Set tags. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppVolumeResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }

        /// <summary> Set tags. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppVolumeResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppVolumeResource type. Use VolumeResource instead.");
        }
    }
}
