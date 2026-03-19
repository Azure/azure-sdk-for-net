// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp;
using Azure.ResourceManager.NetApp.Models;

#pragma warning disable CS1591

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppResourceQuotaLimitsAccountAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = await GetNetAppSubscriptionQuotaItemAsync(quotaLimitName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccount(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = GetNetAppSubscriptionQuotaItem(quotaLimitName, cancellationToken);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccountsAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Page<NetAppSubscriptionQuotaItem>> Pages()
            {
                foreach (Page<NetAppSubscriptionQuotaItemResource> page in GetNetAppSubscriptionQuotaItems().GetAll(cancellationToken).AsPages())
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(), page.ContinuationToken, page.GetRawResponse());
                }
            }

            return AsyncPageable<NetAppSubscriptionQuotaItem>.FromPages(Pages());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccounts(CancellationToken cancellationToken = default)
        {
            IEnumerable<Page<NetAppSubscriptionQuotaItem>> Pages()
            {
                foreach (Page<NetAppSubscriptionQuotaItemResource> page in GetNetAppSubscriptionQuotaItems().GetAll(cancellationToken).AsPages())
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(), page.ContinuationToken, page.GetRawResponse());
                }
            }

            return Pageable<NetAppSubscriptionQuotaItem>.FromPages(Pages());
        }

        private static NetAppSubscriptionQuotaItem ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData data)
        {
            if (data == null)
            {
                return null;
            }

            return new NetAppSubscriptionQuotaItem(data.Id, data.Name, data.ResourceType, data.SystemData, data.Current, data.Default, data.Usage);
        }
    }
}
