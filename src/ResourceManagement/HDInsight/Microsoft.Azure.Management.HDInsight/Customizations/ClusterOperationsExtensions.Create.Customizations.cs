// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Management.HDInsight
{
    /// <summary>
    /// The HDInsight Management Client.
    /// </summary>
    public static partial class ClusterOperationsExtensions
    {
        /// <summary>
        /// Creates a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.IClusterOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <returns>
        /// The GetCluster operation response.
        /// </returns>
        public static ClusterGetResponse Create(this IClusterOperations operations, string resourceGroupName,
            string clusterName, ClusterCreateParameters clusterCreateParameters)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).CreateAsync(resourceGroupName, clusterName, clusterCreateParameters),
                    operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Creates a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.IClusterOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <returns>
        /// The GetCluster operation response.
        /// </returns>
        public static Task<ClusterGetResponse> CreateAsync(this IClusterOperations operations, string resourceGroupName,
            string clusterName, ClusterCreateParameters clusterCreateParameters)
        {
            return operations.CreateAsync(resourceGroupName, clusterName, clusterCreateParameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Begins creating a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <summary>
        /// Creates a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.IClusterOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <returns>
        /// The CreateCluster operation response.
        /// </returns>
        public static ClusterCreateResponse BeginCreating(this IClusterOperations operations, string resourceGroupName,
            string clusterName, ClusterCreateParameters clusterCreateParameters)
        {
            return
                Task.Factory.StartNew(
                    (object s) => ((IClusterOperations) s).BeginCreatingAsync(resourceGroupName, clusterName,
                        clusterCreateParameters), operations, CancellationToken.None, TaskCreationOptions.None,
                    TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Begins creating a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.IClusterOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <returns>
        /// The CreateCluster operation response.
        /// </returns>
        public static Task<ClusterCreateResponse> BeginCreatingAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName, ClusterCreateParameters clusterCreateParameters)
        {
            return operations.BeginCreatingAsync(resourceGroupName, clusterName, clusterCreateParameters,
                CancellationToken.None);
        }
    }
}
