// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteResource : ArmResource
    {
        // Compatibility shim: GA 1.5.0 exposed GetAllConfigurationData[Async] on WebSiteResource,
        // returning Pageable<SiteConfigData> bound to WebApps_ListConfigurations. In the new TypeSpec
        // emission this operation is hosted on a singleton sub-resource and is not surfaced on
        // WebSiteResource. The REST methods are generated on SitesRestOperations; we wrap them here
        // with custom CollectionResult classes to preserve the GA public surface.
        /// <summary>
        /// Description for List the configurations of an app.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationDataAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new SitesGetAllConfigurationDataAsyncCollectionResultOfT(
                _sitesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                context,
                "WebSiteResource.GetAllConfigurationData");
        }

        /// <summary>
        /// Description for List the configurations of an app.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteConfigData> GetAllConfigurationData(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new SitesGetAllConfigurationDataCollectionResultOfT(
                _sitesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                context,
                "WebSiteResource.GetAllConfigurationData");
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
        /// due to this isssue https://github.com/Azure/azure-sdk-for-net/issues/43813, and this method doesn't work,so just throw Exception.
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridConnectionData>> GetAllHybridConnectionDataAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("Obsolete method, Use GetHybridConnectionsAsync instead.");
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
        ///due to this isssue https://github.com/Azure/azure-sdk-for-net/issues/43813, and this method doesn't work,so just throw Exception.
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetHybridConnectionsAsync` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridConnectionData> GetAllHybridConnectionData(CancellationToken cancellationToken = default)
        {
            throw new Exception("Obsolete method, Use GetHybridConnectionsAsync instead.");
        }

        /// <summary> Gets a collection of WebSiteSlotTriggeredWebJobResources in the WebSite. </summary>
        /// <returns> An object representing collection of WebSiteSlotTriggeredWebJobResources and their operations over a WebSiteSlotTriggeredWebJobResource. </returns>
        public virtual WebSiteSlotTriggeredWebJobCollection GetWebSiteSlotTriggeredWebJobs()
        {
            return GetCachedClient(Client => new WebSiteSlotTriggeredWebJobCollection(Client, Id));
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetTriggeredWebJobSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<WebSiteSlotTriggeredWebJobResource>> GetWebSiteSlotTriggeredWebJobAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            return await GetWebSiteSlotTriggeredWebJobs().GetAsync(webJobName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Gets a triggered web job by its ID for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetTriggeredWebJobSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<WebSiteSlotTriggeredWebJobResource> GetWebSiteSlotTriggeredWebJob(string webJobName, CancellationToken cancellationToken = default)
        {
            return GetWebSiteSlotTriggeredWebJobs().Get(webJobName, cancellationToken);
        }

        // The SiteAuthSettingsV2 class is a GA-compatibility shim for the original SiteAuthSettingsV2 model, which was a plain payload returned by WebSiteResource.GetAuthSettingsV2* / UpdateAuthSettingsV2* (and slot variants).
        // After the TypeSpec migration, the underlying API surfaced as a singleton sub-resource (WebSiteAuthSettingsV2Resource) with a *Data model (SiteAuthSettingsV2Data).
        // To preserve the GA API surface, these methods keep the origninal shim.

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2/list</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> GetAuthSettingsV2Async(CancellationToken cancellationToken = default)
        {
            Response<WebSiteAuthSettingsV2Resource> r = await GetWebSiteAuthSettingsV2().GetAuthSettingsV2Async(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2/list</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> GetAuthSettingsV2(CancellationToken cancellationToken = default)
        {
            Response<WebSiteAuthSettingsV2Resource> r = GetWebSiteAuthSettingsV2().GetAuthSettingsV2(cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2WithoutSecrets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> GetAuthSettingsV2WithoutSecretsAsync(CancellationToken cancellationToken = default)
        {
            Response<WebSiteAuthSettingsV2Resource> r = await GetWebSiteAuthSettingsV2().GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2WithoutSecrets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> GetAuthSettingsV2WithoutSecrets(CancellationToken cancellationToken = default)
        {
            Response<WebSiteAuthSettingsV2Resource> r = GetWebSiteAuthSettingsV2().Get(cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Updates site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_UpdateAuthSettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="siteAuthSettingsV2"> Auth settings associated with web app. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteAuthSettingsV2"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> UpdateAuthSettingsV2Async(SiteAuthSettingsV2 siteAuthSettingsV2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteAuthSettingsV2, nameof(siteAuthSettingsV2));
            SiteAuthSettingsV2Data data = AppServiceCompatShims.ConvertAuthBack(siteAuthSettingsV2);
            ArmOperation<WebSiteAuthSettingsV2Resource> op = await GetWebSiteAuthSettingsV2().CreateOrUpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(op.Value.Data), op.GetRawResponse());
        }

        /// <summary>
        /// Description for Updates site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_UpdateAuthSettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="siteAuthSettingsV2"> Auth settings associated with web app. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteAuthSettingsV2"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> UpdateAuthSettingsV2(SiteAuthSettingsV2 siteAuthSettingsV2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteAuthSettingsV2, nameof(siteAuthSettingsV2));
            SiteAuthSettingsV2Data data = AppServiceCompatShims.ConvertAuthBack(siteAuthSettingsV2);
            ArmOperation<WebSiteAuthSettingsV2Resource> op = GetWebSiteAuthSettingsV2().CreateOrUpdate(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(op.Value.Data), op.GetRawResponse());
        }

        // The CsmDeploymentStatus class is a GA-compatibility shim for the original CsmDeploymentStatus model, which was a plain payload returned by WebSiteResource.GetProductionSiteDeploymentStatus* (and slot variants).
        // After the TypeSpec migration, the underlying API surfaced as a resource (CsmSiteDeploymentStatusResource) with a *Data model (CsmDeploymentStatusData).
        // To preserve the GA API surface, these methods keep the origninal shim.

        /// <summary>
        /// List deployment statuses for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListProductionSiteDeploymentStatuses</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CsmDeploymentStatus"/> that may take multiple service requests to iterate over. </returns>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CsmDeploymentStatus> GetProductionSiteDeploymentStatusesAsync(CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectAsyncPageable(GetCsmSiteDeploymentStatuses().GetAllAsync(cancellationToken), r => AppServiceCompatShims.ConvertCsm(r.Data));

        /// <summary>
        /// List deployment statuses for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListProductionSiteDeploymentStatuses</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CsmDeploymentStatus"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CsmDeploymentStatus> GetProductionSiteDeploymentStatuses(CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectPageable(GetCsmSiteDeploymentStatuses().GetAll(cancellationToken), r => AppServiceCompatShims.ConvertCsm(r.Data));

        /// <summary>
        /// Gets the deployment status for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus/{deploymentStatusId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetProductionSiteDeploymentStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentStatusId"> GUID of the deployment operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentStatusId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentStatusId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<CsmDeploymentStatus>> GetProductionSiteDeploymentStatusAsync(WaitUntil waitUntil, string deploymentStatusId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentStatusId, nameof(deploymentStatusId));
            ArmOperation<CsmSiteDeploymentStatusResource> op = await GetCsmSiteDeploymentStatuses().GetAsync(waitUntil, deploymentStatusId, cancellationToken).ConfigureAwait(false);
            return AppServiceCompatShims.ProjectOperation(op, r => AppServiceCompatShims.ConvertCsm(r.Data));
        }

        /// <summary>
        /// Gets the deployment status for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus/{deploymentStatusId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetProductionSiteDeploymentStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentStatusId"> GUID of the deployment operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentStatusId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentStatusId"/> is null. </exception>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<CsmDeploymentStatus> GetProductionSiteDeploymentStatus(WaitUntil waitUntil, string deploymentStatusId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentStatusId, nameof(deploymentStatusId));
            ArmOperation<CsmSiteDeploymentStatusResource> op = GetCsmSiteDeploymentStatuses().Get(waitUntil, deploymentStatusId, cancellationToken);
            return AppServiceCompatShims.ProjectOperation(op, r => AppServiceCompatShims.ConvertCsm(r.Data));
        }
    }
}
