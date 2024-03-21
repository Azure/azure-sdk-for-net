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
    }
}
