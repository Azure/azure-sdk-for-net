// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/sites
        /// Operation Id: AppServiceEnvironments_ListWebApps
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/sites
        /// Operation Id: AppServiceEnvironments_ListWebApps
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

        /// <summary>
        /// Description for Get Hosting Environment Detector Response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<HostingEnvironmentDetectorResource>> GetHostingEnvironmentDetectorAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            await GetHostingEnvironmentDetectorAsync(new HostingEnvironmentDetectorCollectionGetOptions(detectorName)
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Get Hosting Environment Detector Response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<HostingEnvironmentDetectorResource> GetHostingEnvironmentDetector(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            GetHostingEnvironmentDetector(new HostingEnvironmentDetectorCollectionGetOptions(detectorName)
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken);
    }
}
