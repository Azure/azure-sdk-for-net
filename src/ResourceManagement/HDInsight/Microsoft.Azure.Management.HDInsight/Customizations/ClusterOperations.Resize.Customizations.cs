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
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Management.HDInsight
{
    internal partial class ClusterOperations : IClusterOperations
    {
        /// <summary>
        /// Resizes the specified HDInsight cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count for the resize operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<OperationResource> ResizeAsync(string resourceGroupName, string clusterName, int targetInstanceCount,
            CancellationToken cancellationToken)
        {
            try
            {
                var resizeParams = new ClusterResizeParameters {TargetInstanceCount = targetInstanceCount};
                return await ResizeAsync(resourceGroupName, clusterName, resizeParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begins resizing the specified HDInsight cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='targetInstanceCount'>
        /// Required. The target instance count for the resize operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<HDInsightOperationResponse> BeginResizingAsync(string resourceGroupName, string clusterName, int targetInstanceCount,
            CancellationToken cancellationToken)
        {
            try
            {
                var resizeParams = new ClusterResizeParameters { TargetInstanceCount = targetInstanceCount };
                return await BeginResizingAsync(resourceGroupName, clusterName, resizeParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }
    }
}
