// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    public partial class AppServiceEnvironmentResource : ArmResource
    {
        /// <summary>
        /// Description for Get IP addresses assigned to an App Service Environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/capacities/virtualip</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_GetVipInfo</description>
        /// </item>
        /// </list>
        /// GA-compatibility shim. The new SDK exposes this through the singleton
        /// <see cref="AppServiceEnvironmentAddressResource"/> sub-resource returning
        /// <see cref="AppServiceEnvironmentAddressData"/>. This method converts to the
        /// original <see cref="AppServiceEnvironmentAddressResult"/> model for source compatibility.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AppServiceEnvironmentAddressResult>> GetVipInfoAsync(CancellationToken cancellationToken = default)
        {
            Response<AppServiceEnvironmentAddressResource> response = await GetAppServiceEnvironmentAddress().GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ConvertAddress(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Description for Get IP addresses assigned to an App Service Environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/capacities/virtualip</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceEnvironments_GetVipInfo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AppServiceEnvironmentAddressResult> GetVipInfo(CancellationToken cancellationToken = default)
        {
            Response<AppServiceEnvironmentAddressResource> response = GetAppServiceEnvironmentAddress().Get(cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAddress(response.Value.Data), response.GetRawResponse());
        }

        private static AppServiceEnvironmentAddressResult ConvertAddress(AppServiceEnvironmentAddressData data) => AppServiceCompatShims.ConvertAddress(data);

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
                using var scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _appServiceEnvironmentResourcesRestClient.CreateGetAllWebAppDataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, propertiesToInclude, context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppListResult result = WebAppListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WebSiteData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _appServiceEnvironmentResourcesRestClient.CreateNextGetAllWebAppDataRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, propertiesToInclude, context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppListResult result = WebAppListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
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
                using var scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _appServiceEnvironmentResourcesRestClient.CreateGetAllWebAppDataRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, propertiesToInclude, context);
                    var response = Pipeline.ProcessMessage(message, context);
                    WebAppListResult result = WebAppListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WebSiteData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetAllWebAppData");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _appServiceEnvironmentResourcesRestClient.CreateNextGetAllWebAppDataRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, propertiesToInclude, context);
                    var response = Pipeline.ProcessMessage(message, context);
                    WebAppListResult result = WebAppListResult.FromResponse(response);
                    return Page.FromValues(result.Value, result.NextLink?.AbsoluteUri, response);
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
