// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

// MPG MockableResourceProvider.BuildMethodsForResource looks up the canonical Get on
// `collection.Methods`, which only contains generator-emitted MethodProviders and does
// not include CustomCodeView partials. After CassandraClusterCollection suppresses the
// broken generator Get(string,CancellationToken) and re-emits a correct one in a custom
// partial (see Resources/CassandraClusterCollection.cs), the suppressed entry is gone
// from `collection.Methods` and the convenience getters
// MockableCosmosDBResourceGroupResource.GetCassandraCluster(Async) are silently
// dropped. Restore them here so the mockable extension matches sibling resources
// (GetCosmosDBAccount, GetGarnetCluster, GetCosmosDBThroughputPool).
//
// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59094

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    public partial class MockableCosmosDBResourceGroupResource
    {
        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CassandraClusters_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Task<Response<CassandraClusterResource>> GetCassandraClusterAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            return GetCassandraClusters().GetAsync(clusterName, cancellationToken);
        }

        /// <summary>
        /// Get the properties of a managed Cassandra cluster.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/cassandraClusters/{clusterName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CassandraClusters_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clusterName"> Managed Cassandra cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CassandraClusterResource> GetCassandraCluster(string clusterName, CancellationToken cancellationToken = default)
        {
            return GetCassandraClusters().Get(clusterName, cancellationToken);
        }
    }
}
