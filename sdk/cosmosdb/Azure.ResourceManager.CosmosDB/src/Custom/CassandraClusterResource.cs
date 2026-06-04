// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB
{
    // Preserve the previously shipped overloads without duplicating generated request logic.
    // The generated overload now includes the x-ms-force-deallocate header; these overloads
    // delegate with a null header value to keep the old API surface behavior.
    public partial class CassandraClusterResource
    {
        /// <summary>
        /// Deallocate the Managed Cassandra Cluster and Associated Data Centers. Deallocation will deallocate the host virtual machine of this cluster, and reserved the data disk. This won't do anything on an already deallocated cluster. Use Start to restart the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ClusterResources_Deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CassandraClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return DeallocateAsync(waitUntil, xMsForceDeallocate: null, cancellationToken);
        }

        /// <summary>
        /// Deallocate the Managed Cassandra Cluster and Associated Data Centers. Deallocation will deallocate the host virtual machine of this cluster, and reserved the data disk. This won't do anything on an already deallocated cluster. Use Start to restart the cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}/deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ClusterResources_Deallocate. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="CassandraClusterResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return Deallocate(waitUntil, xMsForceDeallocate: null, cancellationToken);
        }
    }
}
