// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    public partial class ServiceFabricManagedClusterResource
    {
        /// <summary>
        /// Action to get Maintenance Window Status of the Service Fabric Managed Clusters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/getMaintenanceWindowStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>managedMaintenanceWindowStatus_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        ///
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ManagedMaintenanceWindowStatus>> GetManagedMaintenanceWindowStatusAsync(CancellationToken cancellationToken = default)
        {
            return await GetManagedMaintenanceWindowStatuAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Action to get Maintenance Window Status of the Service Fabric Managed Clusters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/managedClusters/{clusterName}/getMaintenanceWindowStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>managedMaintenanceWindowStatus_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ManagedMaintenanceWindowStatus> GetManagedMaintenanceWindowStatus(CancellationToken cancellationToken = default)
        {
            return GetManagedMaintenanceWindowStatu(cancellationToken);
        }
    }
}
