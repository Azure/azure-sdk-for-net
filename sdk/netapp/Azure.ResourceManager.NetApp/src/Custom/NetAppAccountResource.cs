// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.NetApp;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppAccountResource : ArmResource
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

        /// <summary>
        /// List vaults for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppVault" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVault> GetVaultsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => NetAppVault.DeserializeNetAppVault(e), VaultsClientDiagnostics, Pipeline, "NetAppAccountResource.GetVaults", "value", null, cancellationToken);
        }

        /// <summary>
        /// List vaults for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppVault" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVault> GetVaults(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => NetAppVault.DeserializeNetAppVault(e), VaultsClientDiagnostics, Pipeline, "NetAppAccountResource.GetVaults", "value", null, cancellationToken);
        }

        /// <summary> Gets a collection of NetAppAccountBackupResources in the NetAppAccount. </summary>
        /// <returns> An object representing collection of NetAppAccountBackupResources and their operations over a NetAppAccountBackupResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppAccountBackupCollection GetNetAppAccountBackups()
        {
            return GetCachedClient(Client => new NetAppAccountBackupCollection(Client, Id));
        }

        /// <summary>
        /// Gets the specified backup for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppAccountBackupResource>> GetNetAppAccountBackupAsync(string backupName, CancellationToken cancellationToken = default)
        {
            return await GetNetAppAccountBackups().GetAsync(backupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified backup for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<NetAppAccountBackupResource> GetNetAppAccountBackup(string backupName, CancellationToken cancellationToken = default)
        {
            return GetNetAppAccountBackups().Get(backupName, cancellationToken);
        }

        /// <summary> List all volume groups for given account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVolumeGroupResult> GetVolumeGroupsAsync(CancellationToken cancellationToken = default)
        {
            return GetByNetAppAccountAsync(cancellationToken);
        }

        /// <summary> List all volume groups for given account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVolumeGroupResult> GetVolumeGroups(CancellationToken cancellationToken = default)
        {
            return GetByNetAppAccount(cancellationToken);
        }

        /// <summary> Migrate the backups under a NetApp account to backup vault. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="body"> The body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> MigrateBackupsBackupsUnderAccountAsync(WaitUntil waitUntil, BackupsMigrationContent body, CancellationToken cancellationToken = default)
        {
            return await MigrateBackupsAsync(waitUntil, body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Migrate the backups under a NetApp account to backup vault. </summary>
        /// <param name="waitUntil"> Completion mode. </param>
        /// <param name="body"> The body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation MigrateBackupsBackupsUnderAccount(WaitUntil waitUntil, BackupsMigrationContent body, CancellationToken cancellationToken = default)
        {
            return MigrateBackups(waitUntil, body, cancellationToken);
        }

        /// <summary> Gets the NetAppSubscriptionQuotaItems collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemCollection GetNetAppSubscriptionQuotaItems()
        {
            throw new NotSupportedException("This method is not supported. Use GetNetAppResourceQuotaLimits() instead.");
        }

        /// <summary> Gets a NetAppSubscriptionQuotaItem. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppSubscriptionQuotaItemResource> GetNetAppSubscriptionQuotaItem(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported. Use GetNetAppResourceQuotaLimit() instead.");
        }

        /// <summary> Gets a NetAppSubscriptionQuotaItem. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppSubscriptionQuotaItemResource>> GetNetAppSubscriptionQuotaItemAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported. Use GetNetAppResourceQuotaLimitAsync() instead.");
        }

        /// <summary> Gets quota limits for accounts. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccounts(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported. Use GetNetAppResourceQuotaLimitsAccounts() instead.");
        }

        /// <summary> Gets quota limits for accounts. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccountsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported. Use GetNetAppResourceQuotaLimitsAccounts() instead.");
        }
    }
}
