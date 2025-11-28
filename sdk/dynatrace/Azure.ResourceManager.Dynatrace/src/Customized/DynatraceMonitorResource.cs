// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
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
        /// <term>Resource</term>
        /// <description><see cref="DynatraceMonitorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // Add this custom code due to the api compatibility for operation: Monitors_GetAccountCredentials.
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DynatraceAccountCredentialsInfo>> GetAccountCredentialsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
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
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DynatraceAccountCredentialsInfo> GetAccountCredentials(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
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
        // Add this custom code due to previous version didn't have request body parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DynatraceMonitoredResourceDetails> GetMonitoredResourcesAsync(CancellationToken cancellationToken)=> GetMonitoredResourcesAsync(null, cancellationToken);

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
        // Add this custom code due to previous version didn't have request body parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DynatraceMonitoredResourceDetails> GetMonitoredResources(CancellationToken cancellationToken)=> GetMonitoredResources(null, cancellationToken);
    }
}
