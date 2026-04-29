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
    // [EditorBrowsable(Never)] attributes belong on the individual legacy methods (GetVaults/GetVaultsAsync) below,
    // not on the class declaration. Attributes on partial declarations are merged into the combined type, which would
    // otherwise hide the entire NetAppAccountResource (a primary public API) from IntelliSense.
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

        // The following six methods existed on NetAppAccountResource in v1.15 because the
        // SubscriptionQuotaItem resource was account-scoped at that time. The current spec moved
        // it to subscription/location scope, so the methods can no longer route to a real
        // operation; they are retained as Obsolete throwing stubs purely to keep the v1.15
        // ApiCompat surface intact. Callers should use the subscription-scoped extension methods
        // (e.g. SubscriptionResource.GetNetAppSubscriptionQuotaItems(AzureLocation)).

        /// <summary> Gets a collection of NetAppSubscriptionQuotaItemResources in the NetAppAccountResource (v1.15 surface). </summary>
        [Obsolete("This collection is no longer account-scoped. Use SubscriptionResource.GetNetAppSubscriptionQuotaItems(AzureLocation) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemCollection GetNetAppSubscriptionQuotaItems()
        {
            throw new NotSupportedException("NetAppSubscriptionQuotaItem is no longer scoped under NetAppAccountResource. Use SubscriptionResource.GetNetAppSubscriptionQuotaItems(AzureLocation) instead.");
        }

        /// <summary> Gets a NetAppSubscriptionQuotaItem (v1.15 surface). </summary>
        [Obsolete("This method is no longer account-scoped. Use SubscriptionResource.GetNetAppSubscriptionQuotaItem(AzureLocation, string) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppSubscriptionQuotaItemResource> GetNetAppSubscriptionQuotaItem(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("NetAppSubscriptionQuotaItem is no longer scoped under NetAppAccountResource. Use SubscriptionResource.GetNetAppSubscriptionQuotaItem(AzureLocation, string) instead.");
        }

        /// <summary> Gets a NetAppSubscriptionQuotaItem (v1.15 surface). </summary>
        [Obsolete("This method is no longer account-scoped. Use SubscriptionResource.GetNetAppSubscriptionQuotaItemAsync(AzureLocation, string) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppSubscriptionQuotaItemResource>> GetNetAppSubscriptionQuotaItemAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("NetAppSubscriptionQuotaItem is no longer scoped under NetAppAccountResource. Use SubscriptionResource.GetNetAppSubscriptionQuotaItemAsync(AzureLocation, string) instead.");
        }

        /// <summary> Gets account quota limits (v1.15 surface). </summary>
        [Obsolete("Use GetNetAppResourceQuotaLimitsAccounts() returning NetAppResourceQuotaLimitsAccountResource instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccounts(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This POCO-returning overload is no longer supported. Use GetNetAppResourceQuotaLimitsAccounts() instead.");
        }

        /// <summary> Gets account quota limits (v1.15 surface). </summary>
        [Obsolete("Use GetNetAppResourceQuotaLimitsAccounts() returning NetAppResourceQuotaLimitsAccountResource instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccountsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This POCO-returning overload is no longer supported. Use GetNetAppResourceQuotaLimitsAccounts() instead.");
        }

        /// <summary> Get account quota limit (v1.15 surface). </summary>
        [Obsolete("Use GetNetAppResourceQuotaLimitsAccountResource(name).Get() instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccount(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This POCO-returning overload is no longer supported. Use GetNetAppResourceQuotaLimitsAccountResource(name).Get() instead.");
        }

        /// <summary> Get account quota limit (v1.15 surface). </summary>
        [Obsolete("Use GetNetAppResourceQuotaLimitsAccountResource(name).GetAsync() instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppResourceQuotaLimitsAccountAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This POCO-returning overload is no longer supported. Use GetNetAppResourceQuotaLimitsAccountResource(name).GetAsync() instead.");
        }
    }
}
