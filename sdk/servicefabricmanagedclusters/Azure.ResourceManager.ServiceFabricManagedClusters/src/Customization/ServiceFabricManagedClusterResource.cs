// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    /// <summary>
    /// A Class representing a ServiceFabricManagedCluster along with the instance operations that can be performed on it.
    /// </summary>
    public partial class ServiceFabricManagedClusterResource: ArmResource
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
        public virtual Response<ManagedMaintenanceWindowStatus> GetManagedMaintenanceWindowStatus(CancellationToken cancellationToken = default)
        {
            return GetManagedMaintenanceWindowStatu(cancellationToken);
        }
    }
}
