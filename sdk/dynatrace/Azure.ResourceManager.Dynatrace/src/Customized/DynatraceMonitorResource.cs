// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.ResourceManager.Dynatrace.Models;

namespace Azure.ResourceManager.Dynatrace
{
    public partial class DynatraceMonitorResource
    {
        /// <summary>
        /// Gets the user account credentials for a Monitor
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/getAccountCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_GetAccountCredentials</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Add this custom code due to the api compatibility for operation: Monitors_GetAccountCredentials.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DynatraceAccountCredentialsInfo>> GetAccountCredentialsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _dynatraceMonitorMonitorsClientDiagnostics.CreateScope("DynatraceMonitorResource.GetAccountCredentials");
            scope.Start();
            try
            {
                var response = await _dynatraceMonitorMonitorsRestClient.GetAccountCredentialsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the user account credentials for a Monitor
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/getAccountCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_GetAccountCredentials</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Add this custom code due to the api compatibility for operation: Monitors_GetAccountCredentials.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DynatraceAccountCredentialsInfo> GetAccountCredentials(CancellationToken cancellationToken = default)
        {
            using var scope = _dynatraceMonitorMonitorsClientDiagnostics.CreateScope("DynatraceMonitorResource.GetAccountCredentials");
            scope.Start();
            try
            {
                var response = _dynatraceMonitorMonitorsRestClient.GetAccountCredentials(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the resources currently being monitored by the Dynatrace monitor resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/listMonitoredResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_ListMonitoredResources</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DynatraceMonitoredResourceDetails"/> that may take multiple service requests to iterate over. </returns>
        // Add this custom code due to previous veresion didn't have request body parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DynatraceMonitoredResourceDetails> GetMonitoredResourcesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _dynatraceMonitorMonitorsRestClient.CreateListMonitoredResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _dynatraceMonitorMonitorsRestClient.CreateListMonitoredResourcesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => DynatraceMonitoredResourceDetails.DeserializeDynatraceMonitoredResourceDetails(e), _dynatraceMonitorMonitorsClientDiagnostics, Pipeline, "DynatraceMonitorResource.GetMonitoredResources", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List the resources currently being monitored by the Dynatrace monitor resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Dynatrace.Observability/monitors/{monitorName}/listMonitoredResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Monitors_ListMonitoredResources</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DynatraceMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DynatraceMonitoredResourceDetails"/> that may take multiple service requests to iterate over. </returns>
        // Add this custom code due to previous veresion didn't have request body parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DynatraceMonitoredResourceDetails> GetMonitoredResources(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _dynatraceMonitorMonitorsRestClient.CreateListMonitoredResourcesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _dynatraceMonitorMonitorsRestClient.CreateListMonitoredResourcesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => DynatraceMonitoredResourceDetails.DeserializeDynatraceMonitoredResourceDetails(e), _dynatraceMonitorMonitorsClientDiagnostics, Pipeline, "DynatraceMonitorResource.GetMonitoredResources", "value", "nextLink", cancellationToken);
        }
    }
}
