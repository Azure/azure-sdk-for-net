namespace Microsoft.Azure.Management.AzureStackHCI
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ClustersOperations.
    /// </summary>
    public static partial class ClustersOperationsExtensions
    {
        /// <summary>
        /// Update an HCI cluster.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='clusterName'>
        /// The name of the cluster.
        /// </param>
        /// <param name='tags'>
            /// Resource tags.
        /// </param>
        public static Cluster Update(this IClustersOperations operations, string resourceGroupName, string clusterName, IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            var clusterPatch = new ClusterPatch();
            if (tags != null)
            {
                clusterPatch.Tags = tags;
            }

            return operations.Update(resourceGroupName, clusterName, clusterPatch);
        }
    }
}