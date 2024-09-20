// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a WebSiteSlot along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="WebSiteSlotResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetWebSiteSlotResource method.
    /// Otherwise you can get one from its parent resource <see cref="WebSiteResource" /> using the GetWebSiteSlot method.
    /// </summary>
    public partial class WebSiteSlotResource : ArmResource
    {
        /// <summary>
        /// Description for List the configurations of an app
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListConfigurationsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationSlotDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteConfigData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllConfigurationSlotData");
                scope.Start();
                try
                {
                    var response = await _webSiteSlotWebAppsRestClient.ListConfigurationsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteConfigData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllConfigurationSlotData");
                scope.Start();
                try
                {
                    var response = await _webSiteSlotWebAppsRestClient.ListConfigurationsSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List the configurations of an app
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListConfigurationsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteConfigData> GetAllConfigurationSlotData(CancellationToken cancellationToken = default)
        {
            Page<SiteConfigData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllConfigurationSlotData");
                scope.Start();
                try
                {
                    var response = _webSiteSlotWebAppsRestClient.ListConfigurationsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteConfigData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllConfigurationSlotData");
                scope.Start();
                try
                {
                    var response = _webSiteSlotWebAppsRestClient.ListConfigurationsSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for Retrieves all Service Bus Hybrid Connections used by this Web App.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListHybridConnectionsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        ///due to this isssue https://github.com/Azure/azure-sdk-for-net/issues/43813, and this method doesn't work,so just throw Exception.
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsSlotAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridConnectionData>> GetAllHybridConnectionSlotDataAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("Obsolete method, Use GetHybridConnectionsSlotAsync instead.");
        }

        /// <summary>
        /// Description for Retrieves all Service Bus Hybrid Connections used by this Web App.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListHybridConnectionsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// due to this isssue https://github.com/Azure/azure-sdk-for-net/issues/43813, and this method doesn't work,so just throw Exception.
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsSlot` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridConnectionData> GetAllHybridConnectionSlotData(CancellationToken cancellationToken = default)
        {
            throw new Exception("Obsolete method, Use GetHybridConnectionsSlot instead.");
        }

        /// <summary>
        /// Description for Gets hybrid connections configured for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListRelayServiceConnectionsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionSlotDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllRelayServiceConnectionSlotData");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.ListRelayServiceConnectionsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets hybrid connections configured for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListRelayServiceConnectionsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RelayServiceConnectionEntityData> GetAllRelayServiceConnectionSlotData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllRelayServiceConnectionSlotData");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.ListRelayServiceConnectionsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets existing backups of an app.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSiteBackupsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebAppBackupData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WebAppBackupData> GetAllSiteBackupSlotDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WebAppBackupData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllSiteBackupSlotData");
                scope.Start();
                try
                {
                    var response = await _webSiteSlotWebAppsRestClient.ListSiteBackupsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WebAppBackupData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllSiteBackupSlotData");
                scope.Start();
                try
                {
                    var response = await _webSiteSlotWebAppsRestClient.ListSiteBackupsSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for Gets existing backups of an app.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSiteBackupsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebAppBackupData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WebAppBackupData> GetAllSiteBackupSlotData(CancellationToken cancellationToken = default)
        {
            Page<WebAppBackupData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllSiteBackupSlotData");
                scope.Start();
                try
                {
                    var response = _webSiteSlotWebAppsRestClient.ListSiteBackupsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WebAppBackupData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllSiteBackupSlotData");
                scope.Start();
                try
                {
                    var response = _webSiteSlotWebAppsRestClient.ListSiteBackupsSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for Gets the premier add-ons of an app.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListPremierAddOnsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PremierAddOnData>> GetAllPremierAddOnSlotDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllPremierAddOnSlotData");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.ListPremierAddOnsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the premier add-ons of an app.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListPremierAddOnsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PremierAddOnData> GetAllPremierAddOnSlotData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllPremierAddOnSlotData");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.ListPremierAddOnsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a collection of WebSiteTriggeredwebJobResources in the WebSiteSlot. </summary>
        /// <returns> An object representing collection of WebSiteTriggeredwebJobResources and their operations over a WebSiteTriggeredwebJobResource. </returns>
        public virtual WebSiteTriggeredwebJobCollection GetWebSiteTriggeredwebJobs()
        {
            return GetCachedClient(Client => new WebSiteTriggeredwebJobCollection(Client, Id));
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetTriggeredWebJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<WebSiteTriggeredwebJobResource>> GetWebSiteTriggeredwebJobAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            return await GetWebSiteTriggeredwebJobs().GetAsync(webJobName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetTriggeredWebJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<WebSiteTriggeredwebJobResource> GetWebSiteTriggeredwebJob(string webJobName, CancellationToken cancellationToken = default)
        {
            return GetWebSiteTriggeredwebJobs().Get(webJobName, cancellationToken);
        }
    }
}
