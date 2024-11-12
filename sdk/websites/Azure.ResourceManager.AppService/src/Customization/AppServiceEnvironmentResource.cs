// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing an AppServiceEnvironment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AppServiceEnvironmentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAppServiceEnvironmentResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetAppServiceEnvironment method.
    /// </summary>
    public partial class AppServiceEnvironmentResource : ArmResource
    {
        /// <summary>
        /// Description for Get all apps in an App Service Environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/sites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_ListWebApps</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="propertiesToInclude"> Comma separated list of app properties to include. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WebSiteData> GetAllWebAppDataAsync(string propertiesToInclude = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<WebSiteData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServiceEnvironmentClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    var response = await _appServiceEnvironmentRestClient.ListWebAppsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, propertiesToInclude, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _appServiceEnvironmentClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    var response = await _appServiceEnvironmentRestClient.ListWebAppsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, propertiesToInclude, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Description for Get all apps in an App Service Environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/sites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_ListWebApps</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="propertiesToInclude"> Comma separated list of app properties to include. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WebSiteData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WebSiteData> GetAllWebAppData(string propertiesToInclude = null, CancellationToken cancellationToken = default)
        {
            Page<WebSiteData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _appServiceEnvironmentClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    var response = _appServiceEnvironmentRestClient.ListWebApps(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, propertiesToInclude, cancellationToken: cancellationToken);
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
                using var scope = _appServiceEnvironmentClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    var response = _appServiceEnvironmentRestClient.ListWebAppsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, propertiesToInclude, cancellationToken: cancellationToken);
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
