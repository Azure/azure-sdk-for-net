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

using System;
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
        /// Resizes the specified HDInsight cluster.
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
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightLongRunningOperationResponse Resize(this IClusterOperations operations, string resourceGroupName, string clusterName, int targetInstanceCount)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IClusterOperations)s).ResizeAsync(resourceGroupName, clusterName, targetInstanceCount);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Resizes the specified HDInsight cluster.
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
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightLongRunningOperationResponse> ResizeAsync(this IClusterOperations operations, string resourceGroupName, string clusterName, int targetInstanceCount)
        {
            return operations.ResizeAsync(resourceGroupName, clusterName, targetInstanceCount, CancellationToken.None);
        }

        /// <summary>
        /// Begins resizing the specified HDInsight cluster.
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
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightOperationResponse BeginResizing(this IClusterOperations operations, string resourceGroupName, string clusterName, int targetInstanceCount)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IClusterOperations)s).BeginResizingAsync(resourceGroupName, clusterName, targetInstanceCount);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins resizing the specified HDInsight cluster.
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
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightOperationResponse> BeginResizingAsync(this IClusterOperations operations, string resourceGroupName, string clusterName, int targetInstanceCount)
        {
            return operations.BeginResizingAsync(resourceGroupName, clusterName, targetInstanceCount, CancellationToken.None);
        }
    }
}
