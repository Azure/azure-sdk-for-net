// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a WebSite along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="WebSiteResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetWebSiteResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetWebSite method.
    /// </summary>
    public partial class WebSiteResource : ArmResource
    {
        /// <summary>
        /// Description for List the configurations of an app
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteConfigData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllConfigurationData");
                scope.Start();
                try
                {
                    var response = await _webSiteWebAppsRestClient.ListConfigurationsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllConfigurationData");
                scope.Start();
                try
                {
                    var response = await _webSiteWebAppsRestClient.ListConfigurationsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteConfigData> GetAllConfigurationData(CancellationToken cancellationToken = default)
        {
            Page<SiteConfigData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllConfigurationData");
                scope.Start();
                try
                {
                    var response = _webSiteWebAppsRestClient.ListConfigurations(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
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
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllConfigurationData");
                scope.Start();
                try
                {
                    var response = _webSiteWebAppsRestClient.ListConfigurationsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListHybridConnections</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<HybridConnectionData>> GetAllHybridConnectionDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllHybridConnectionData");
            scope.Start();
            try
            {
                var response = await _webSiteWebAppsRestClient.ListHybridConnectionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Retrieves all Service Bus Hybrid Connections used by this Web App.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListHybridConnections</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<HybridConnectionData> GetAllHybridConnectionData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllHybridConnectionData");
            scope.Start();
            try
            {
                var response = _webSiteWebAppsRestClient.ListHybridConnections(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListRelayServiceConnections</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RelayServiceConnectionEntityData>> GetAllRelayServiceConnectionDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllRelayServiceConnectionData");
            scope.Start();
            try
            {
                var response = await _webSiteWebAppsRestClient.ListRelayServiceConnectionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListRelayServiceConnections</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RelayServiceConnectionEntityData> GetAllRelayServiceConnectionData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllRelayServiceConnectionData");
            scope.Start();
            try
            {
                var response = _webSiteWebAppsRestClient.ListRelayServiceConnections(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSiteBackups</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebAppBackupData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WebAppBackupData> GetAllSiteBackupDataAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WebAppBackupData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllSiteBackupData");
                scope.Start();
                try
                {
                    var response = await _webSiteWebAppsRestClient.ListSiteBackupsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllSiteBackupData");
                scope.Start();
                try
                {
                    var response = await _webSiteWebAppsRestClient.ListSiteBackupsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSiteBackups</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebAppBackupData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WebAppBackupData> GetAllSiteBackupData(CancellationToken cancellationToken = default)
        {
            Page<WebAppBackupData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllSiteBackupData");
                scope.Start();
                try
                {
                    var response = _webSiteWebAppsRestClient.ListSiteBackups(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
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
                using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllSiteBackupData");
                scope.Start();
                try
                {
                    var response = _webSiteWebAppsRestClient.ListSiteBackupsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListPremierAddOns</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PremierAddOnData>> GetAllPremierAddOnDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllPremierAddOnData");
            scope.Start();
            try
            {
                var response = await _webSiteWebAppsRestClient.ListPremierAddOnsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListPremierAddOns</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PremierAddOnData> GetAllPremierAddOnData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteWebAppsClientDiagnostics.CreateScope("WebSiteResource.GetAllPremierAddOnData");
            scope.Start();
            try
            {
                var response = _webSiteWebAppsRestClient.ListPremierAddOns(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
