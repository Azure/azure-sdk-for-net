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
    public partial class AppServicePlanResource
    {
        /// <summary>
        /// Description for Retrieve all Hybrid Connections in use in an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionRelays
        /// Operation Id: AppServicePlans_ListHybridConnections
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="HybridConnectionData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<HybridConnectionData> GetHybridConnectionRelaysAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<HybridConnectionData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetHybridConnectionRelays");
                scope.Start();
                try
                {
                    var response = await _appServicePlanRestClient.ListHybridConnectionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<HybridConnectionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetHybridConnectionRelays");
                scope.Start();
                try
                {
                    var response = await _appServicePlanRestClient.ListHybridConnectionsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Description for Retrieve all Hybrid Connections in use in an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionRelays
        /// Operation Id: AppServicePlans_ListHybridConnections
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="HybridConnectionData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<HybridConnectionData> GetHybridConnectionRelays(CancellationToken cancellationToken = default)
        {
            Page<HybridConnectionData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetHybridConnectionRelays");
                scope.Start();
                try
                {
                    var response = _appServicePlanRestClient.ListHybridConnections(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<HybridConnectionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetHybridConnectionRelays");
                scope.Start();
                try
                {
                    var response = _appServicePlanRestClient.ListHybridConnectionsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
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
        /// Description for Get all apps associated with an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites
        /// Operation Id: AppServicePlans_ListWebApps
        /// </summary>
        /// <param name="skipToken"> Skip to a web app in the list of webapps associated with app service plan. If specified, the resulting list will contain web apps starting from (including) the skipToken. Otherwise, the resulting list contains web apps from the start of the list. </param>
        /// <param name="filter"> Supported filter: $filter=state eq running. Returns only web apps that are currently running. </param>
        /// <param name="top"> List page size. If specified, results are paged. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<WebSiteData> GetWebAppsAsync(string skipToken = null, string filter = null, string top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<WebSiteData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetWebApps");
                scope.Start();
                try
                {
                    var response = await _appServicePlanRestClient.ListWebAppsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WebSiteData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetWebApps");
                scope.Start();
                try
                {
                    var response = await _appServicePlanRestClient.ListWebAppsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Description for Get all apps associated with an App Service plan.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites
        /// Operation Id: AppServicePlans_ListWebApps
        /// </summary>
        /// <param name="skipToken"> Skip to a web app in the list of webapps associated with app service plan. If specified, the resulting list will contain web apps starting from (including) the skipToken. Otherwise, the resulting list contains web apps from the start of the list. </param>
        /// <param name="filter"> Supported filter: $filter=state eq running. Returns only web apps that are currently running. </param>
        /// <param name="top"> List page size. If specified, results are paged. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<WebSiteData> GetWebApps(string skipToken = null, string filter = null, string top = null, CancellationToken cancellationToken = default)
        {
            Page<WebSiteData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetWebApps");
                scope.Start();
                try
                {
                    var response = _appServicePlanRestClient.ListWebApps(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WebSiteData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServicePlanClientDiagnostics.CreateScope("AppServicePlanResource.GetWebApps");
                scope.Start();
                try
                {
                    var response = _appServicePlanRestClient.ListWebAppsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, top, cancellationToken: cancellationToken);
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
    }
}
