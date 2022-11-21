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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config
        /// Operation Id: WebApps_ListConfigurationsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config
        /// Operation Id: WebApps_ListConfigurationsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays
        /// Operation Id: WebApps_ListHybridConnectionsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<HybridConnectionData>> GetAllHybridConnectionSlotDataAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllHybridConnectionSlotData");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.ListHybridConnectionsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays
        /// Operation Id: WebApps_ListHybridConnectionsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<HybridConnectionData> GetAllHybridConnectionSlotData(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetAllHybridConnectionSlotData");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.ListHybridConnectionsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection
        /// Operation Id: WebApps_ListRelayServiceConnectionsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection
        /// Operation Id: WebApps_ListRelayServiceConnectionsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups
        /// Operation Id: WebApps_ListSiteBackupsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups
        /// Operation Id: WebApps_ListSiteBackupsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons
        /// Operation Id: WebApps_ListPremierAddOnsSlot
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons
        /// Operation Id: WebApps_ListPremierAddOnsSlot
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

        /// <summary>
        /// Description for Get site detector response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetectorResponseSlot
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SiteSlotDetectorResource>> GetSiteSlotDetectorAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            return await GetSiteSlotDetectors().GetAsync(detectorName, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Get site detector response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetectorResponseSlot
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SiteSlotDetectorResource> GetSiteSlotDetector(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            return GetSiteSlotDetectors().Get(detectorName, startTime, endTime, timeGrain, cancellationToken);
        }

#pragma warning disable CA1054
        /// <summary>
        /// Description for Start capturing network packets for the site (To be deprecated).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/start
        /// Operation Id: WebApps_StartWebSiteNetworkTraceSlot
        /// </summary>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> StartWebSiteNetworkTraceSlotAsync(int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartWebSiteNetworkTraceSlot");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.StartWebSiteNetworkTraceSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Start capturing network packets for the site (To be deprecated).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/start
        /// Operation Id: WebApps_StartWebSiteNetworkTraceSlot
        /// </summary>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> StartWebSiteNetworkTraceSlot(int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartWebSiteNetworkTraceSlot");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.StartWebSiteNetworkTraceSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/startOperation
        /// Operation Id: WebApps_StartWebSiteNetworkTraceOperationSlot
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IList<WebAppNetworkTrace>>> StartWebSiteNetworkTraceOperationSlotAsync(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartWebSiteNetworkTraceOperationSlot");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.StartWebSiteNetworkTraceOperationSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<IList<WebAppNetworkTrace>>(new IListOperationSource(), _webSiteSlotWebAppsClientDiagnostics, Pipeline, _webSiteSlotWebAppsRestClient.CreateStartWebSiteNetworkTraceOperationSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/startOperation
        /// Operation Id: WebApps_StartWebSiteNetworkTraceOperationSlot
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IList<WebAppNetworkTrace>> StartWebSiteNetworkTraceOperationSlot(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartWebSiteNetworkTraceOperationSlot");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.StartWebSiteNetworkTraceOperationSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken);
                var operation = new AppServiceArmOperation<IList<WebAppNetworkTrace>>(new IListOperationSource(), _webSiteSlotWebAppsClientDiagnostics, Pipeline, _webSiteSlotWebAppsRestClient.CreateStartWebSiteNetworkTraceOperationSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/startNetworkTrace
        /// Operation Id: WebApps_StartNetworkTraceSlot
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IList<WebAppNetworkTrace>>> StartNetworkTraceSlotAsync(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartNetworkTraceSlot");
            scope.Start();
            try
            {
                var response = await _webSiteSlotWebAppsRestClient.StartNetworkTraceSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<IList<WebAppNetworkTrace>>(new IListOperationSource(), _webSiteSlotWebAppsClientDiagnostics, Pipeline, _webSiteSlotWebAppsRestClient.CreateStartNetworkTraceSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/startNetworkTrace
        /// Operation Id: WebApps_StartNetworkTraceSlot
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IList<WebAppNetworkTrace>> StartNetworkTraceSlot(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteSlotWebAppsClientDiagnostics.CreateScope("WebSiteSlotResource.StartNetworkTraceSlot");
            scope.Start();
            try
            {
                var response = _webSiteSlotWebAppsRestClient.StartNetworkTraceSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl, cancellationToken);
                var operation = new AppServiceArmOperation<IList<WebAppNetworkTrace>>(new IListOperationSource(), _webSiteSlotWebAppsClientDiagnostics, Pipeline, _webSiteSlotWebAppsRestClient.CreateStartNetworkTraceSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, durationInSeconds, maxFrameLength, sasUrl).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
#pragma warning restore CA1054
    }
}
