// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config
        /// Operation Id: WebApps_ListConfigurations
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config
        /// Operation Id: WebApps_ListConfigurations
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays
        /// Operation Id: WebApps_ListHybridConnections
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays
        /// Operation Id: WebApps_ListHybridConnections
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection
        /// Operation Id: WebApps_ListRelayServiceConnections
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection
        /// Operation Id: WebApps_ListRelayServiceConnections
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups
        /// Operation Id: WebApps_ListSiteBackups
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups
        /// Operation Id: WebApps_ListSiteBackups
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons
        /// Operation Id: WebApps_ListPremierAddOns
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons
        /// Operation Id: WebApps_ListPremierAddOns
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

        /// <summary>
        /// Description for Get site detector response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SiteDetectorResource>> GetSiteDetectorAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            await GetSiteDetectorAsync(new SiteDetectorCollectionGetOptions(detectorName)
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Get site detector response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SiteDetectorResource> GetSiteDetector(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            GetSiteDetector(new SiteDetectorCollectionGetOptions(detectorName)
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken);

#pragma warning disable CA1054
        /// <summary>
        /// Description for Start capturing network packets for the site (To be deprecated).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/start
        /// Operation Id: WebApps_StartWebSiteNetworkTrace
        /// </summary>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> StartWebSiteNetworkTraceAsync(int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            await StartWebSiteNetworkTraceAsync(new WebSiteResourceStartWebSiteNetworkTraceOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Start capturing network packets for the site (To be deprecated).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/start
        /// Operation Id: WebApps_StartWebSiteNetworkTrace
        /// </summary>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> StartWebSiteNetworkTrace(int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            StartWebSiteNetworkTrace(new WebSiteResourceStartWebSiteNetworkTraceOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken);

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/startOperation
        /// Operation Id: WebApps_StartWebSiteNetworkTraceOperation
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IList<WebAppNetworkTrace>>> StartWebSiteNetworkTraceOperationAsync(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            await StartWebSiteNetworkTraceOperationAsync(waitUntil, new WebSiteResourceStartWebSiteNetworkTraceOperationOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/startOperation
        /// Operation Id: WebApps_StartWebSiteNetworkTraceOperation
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IList<WebAppNetworkTrace>> StartWebSiteNetworkTraceOperation(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            StartWebSiteNetworkTraceOperation(waitUntil, new WebSiteResourceStartWebSiteNetworkTraceOperationOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken);

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/startNetworkTrace
        /// Operation Id: WebApps_StartNetworkTrace
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IList<WebAppNetworkTrace>>> StartNetworkTraceAsync(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            await StartNetworkTraceAsync(waitUntil, new WebSiteResourceStartNetworkTraceOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Start capturing network packets for the site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/startNetworkTrace
        /// Operation Id: WebApps_StartNetworkTrace
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="durationInSeconds"> The duration to keep capturing in seconds. </param>
        /// <param name="maxFrameLength"> The maximum frame length in bytes (Optional). </param>
        /// <param name="sasUrl"> The Blob URL to store capture file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IList<WebAppNetworkTrace>> StartNetworkTrace(WaitUntil waitUntil, int? durationInSeconds = null, int? maxFrameLength = null, string sasUrl = null, CancellationToken cancellationToken = default) =>
            StartNetworkTrace(waitUntil, new WebSiteResourceStartNetworkTraceOptions
            {
                DurationInSeconds = durationInSeconds,
                MaxFrameLength = maxFrameLength,
                SasUrl = sasUrl
            }, cancellationToken);
#pragma warning restore CA1054
    }
}
