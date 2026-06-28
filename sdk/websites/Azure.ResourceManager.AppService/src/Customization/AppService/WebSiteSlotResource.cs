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
    public partial class WebSiteSlotResource : ArmResource
    {
        // Compatibility shim: GA 1.5.0 exposed GetAllConfigurationSlotData[Async] on WebSiteSlotResource.
        // The new TypeSpec emission does not bind WebApps_ListConfigurationsSlot here because the
        // listConfigurations operation is hosted on a singleton sub-resource. The REST methods are
        // generated on WebAppsRestOperations; we wrap them here with custom CollectionResult classes
        // to preserve the GA public surface.
        /// <summary>
        /// Description for List the configurations of an app.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteConfigData> GetAllConfigurationSlotDataAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new WebAppsGetAllConfigurationSlotDataAsyncCollectionResultOfT(
                _webAppsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "WebSiteSlotResource.GetAllConfigurationSlotData");
        }

        /// <summary>
        /// Description for List the configurations of an app.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteConfigData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteConfigData> GetAllConfigurationSlotData(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new WebAppsGetAllConfigurationSlotDataCollectionResultOfT(
                _webAppsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "WebSiteSlotResource.GetAllConfigurationSlotData");
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

        // The SiteAuthSettingsV2 class is a GA-compatibility shim for the original SiteAuthSettingsV2 model, which was a plain payload returned by WebSiteResource.GetAuthSettingsV2* / UpdateAuthSettingsV2* (and slot variants).
        // After the TypeSpec migration, the underlying API surfaced as a singleton sub-resource (WebSiteAuthSettingsV2Resource) with a *Data model (SiteAuthSettingsV2Data).
        // To preserve the GA API surface, these methods keep the origninal shim.

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2/list</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2Slot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> GetAuthSettingsV2SlotAsync(CancellationToken cancellationToken = default)
        {
            Response<WebSiteSlotAuthSettingsV2Resource> r = await GetWebSiteSlotAuthSettingsV2().GetAuthSettingsV2SlotAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2/list</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2Slot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> GetAuthSettingsV2Slot(CancellationToken cancellationToken = default)
        {
            Response<WebSiteSlotAuthSettingsV2Resource> r = GetWebSiteSlotAuthSettingsV2().GetAuthSettingsV2Slot(cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2WithoutSecretsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> GetAuthSettingsV2WithoutSecretsSlotAsync(CancellationToken cancellationToken = default)
        {
            Response<WebSiteSlotAuthSettingsV2Resource> r = await GetWebSiteSlotAuthSettingsV2().GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Gets site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetAuthSettingsV2WithoutSecretsSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> GetAuthSettingsV2WithoutSecretsSlot(CancellationToken cancellationToken = default)
        {
            Response<WebSiteSlotAuthSettingsV2Resource> r = GetWebSiteSlotAuthSettingsV2().Get(cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(r.Value.Data), r.GetRawResponse());
        }

        /// <summary>
        /// Description for Updates site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_UpdateAuthSettingsV2Slot</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteSlotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="siteAuthSettingsV2"> Auth settings associated with web app. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteAuthSettingsV2"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SiteAuthSettingsV2>> UpdateAuthSettingsV2SlotAsync(SiteAuthSettingsV2 siteAuthSettingsV2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteAuthSettingsV2, nameof(siteAuthSettingsV2));
            SiteAuthSettingsV2Data data = AppServiceCompatShims.ConvertAuthBack(siteAuthSettingsV2);
            ArmOperation<WebSiteSlotAuthSettingsV2Resource> op = await GetWebSiteSlotAuthSettingsV2().CreateOrUpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(op.Value.Data), op.GetRawResponse());
        }

        /// <summary>
        /// Description for Updates site's Authentication / Authorization settings for apps via the V2 format
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_UpdateAuthSettingsV2Slot</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteSlotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="siteAuthSettingsV2"> Auth settings associated with web app. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteAuthSettingsV2"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SiteAuthSettingsV2> UpdateAuthSettingsV2Slot(SiteAuthSettingsV2 siteAuthSettingsV2, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteAuthSettingsV2, nameof(siteAuthSettingsV2));
            SiteAuthSettingsV2Data data = AppServiceCompatShims.ConvertAuthBack(siteAuthSettingsV2);
            ArmOperation<WebSiteSlotAuthSettingsV2Resource> op = GetWebSiteSlotAuthSettingsV2().CreateOrUpdate(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(AppServiceCompatShims.ConvertAuth(op.Value.Data), op.GetRawResponse());
        }

        /// <summary>
        /// List deployment statuses for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSlotSiteDeploymentStatusesSlot</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteSlotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CsmDeploymentStatus"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CsmDeploymentStatus> GetSlotSiteDeploymentStatusesSlotAsync(CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectAsyncPageable(GetCsmSiteSlotDeploymentStatuses().GetAllAsync(cancellationToken), r => AppServiceCompatShims.ConvertCsm(r.Data));

        /// <summary>
        /// List deployment statuses for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListSlotSiteDeploymentStatusesSlot</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WebSiteSlotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CsmDeploymentStatus"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CsmDeploymentStatus> GetSlotSiteDeploymentStatusesSlot(CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectPageable(GetCsmSiteSlotDeploymentStatuses().GetAll(cancellationToken), r => AppServiceCompatShims.ConvertCsm(r.Data));

        /// <summary>
        /// Gets the deployment status for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus/{deploymentStatusId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetSlotSiteDeploymentStatusSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentStatusId"> GUID of the deployment operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentStatusId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentStatusId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<CsmDeploymentStatus>> GetSlotSiteDeploymentStatusSlotAsync(WaitUntil waitUntil, string deploymentStatusId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentStatusId, nameof(deploymentStatusId));
            ArmOperation<CsmSiteSlotDeploymentStatusResource> op = await GetCsmSiteSlotDeploymentStatuses().GetAsync(waitUntil, deploymentStatusId, cancellationToken).ConfigureAwait(false);
            return AppServiceCompatShims.ProjectOperation(op, r => AppServiceCompatShims.ConvertCsm(r.Data));
        }

        /// <summary>
        /// Gets the deployment status for an app (or deployment slot, if specified).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus/{deploymentStatusId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_GetSlotSiteDeploymentStatusSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="deploymentStatusId"> GUID of the deployment operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentStatusId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentStatusId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<CsmDeploymentStatus> GetSlotSiteDeploymentStatusSlot(WaitUntil waitUntil, string deploymentStatusId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentStatusId, nameof(deploymentStatusId));
            ArmOperation<CsmSiteSlotDeploymentStatusResource> op = GetCsmSiteSlotDeploymentStatuses().Get(waitUntil, deploymentStatusId, cancellationToken);
            return AppServiceCompatShims.ProjectOperation(op, r => AppServiceCompatShims.ConvertCsm(r.Data));
        }
    }
}
