// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Add this custom code to avoid breaking changes for PromoteReadReplica method overloads
    // New overloads with additional parameter 'CosmosDBForPostgreSqlClusterPromoteReadReplicaContent content' added
    public partial class CosmosDBForPostgreSqlClusterResource
    {
        /// <summary>
        /// Promotes read replica cluster to an independent read-write cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/promote</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_PromoteReadReplica</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-11-08</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CosmosDBForPostgreSqlClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> PromoteReadReplicaAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return await PromoteReadReplicaAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Promotes read replica cluster to an independent read-write cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/promote</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Clusters_PromoteReadReplica</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-11-08</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CosmosDBForPostgreSqlClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation PromoteReadReplica(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return PromoteReadReplica(waitUntil, null, cancellationToken);
        }
    }
}
