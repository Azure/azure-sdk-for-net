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
using System.Collections.Generic;

namespace Microsoft.Azure.Management.HDInsight
{
    /// <summary>
    /// Contains all the cluster operations.
    /// </summary>
    public partial interface IClusterOperations
    {
        /// <summary>
        /// Creates a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The GetCluster operation response.
        /// </returns>
        Task<ClusterGetResponse> CreateAsync(string resourceGroupName, string clusterName, ClusterCreateParameters clusterCreateParameters, CancellationToken cancellationToken);

        /// <summary>
        /// Begins creating a new HDInsight cluster with the specified parameters.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='clusterCreateParameters'>
        /// Required. The cluster create request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The GetCluster operation response.
        /// </returns>
        Task<ClusterCreateResponse> BeginCreatingAsync(string resourceGroupName, string clusterName, ClusterCreateParameters clusterCreateParameters, CancellationToken cancellationToken);

        /// <summary>
        /// Enables HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='username'>
        /// Required. The HTTP username.
        /// </param>
        /// <param name='password'>
        /// Required. The HTTP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<OperationResource> EnableHttpAsync(string resourceGroupName, string clusterName,
            string username, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Begins enabling HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='username'>
        /// Required. The HTTP username.
        /// </param>
        /// <param name='password'>
        /// Required. The HTTP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<HDInsightOperationResponse> BeginEnablingHttpAsync(string resourceGroupName, string clusterName,
            string username, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Disables HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<OperationResource> DisableHttpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken);

        /// <summary>
        /// Begins disabling HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<HDInsightOperationResponse> BeginDisablingHttpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken);

        /// <summary>
        /// Enables RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='rdpUsername'>
        /// Required. The RDP username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<OperationResource> EnableRdpAsync(string resourceGroupName, string clusterName,
            string rdpUsername, string rdpPassword, DateTime rdpExpiryDate, CancellationToken cancellationToken);

        /// <summary>
        /// Begins enabling RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='rdpUsername'>
        /// Required. The RDP username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<HDInsightOperationResponse> BeginEnablingRdpAsync(string resourceGroupName, string clusterName,
            string rdpUsername, string rdpPassword, DateTime rdpExpiryDate, CancellationToken cancellationToken);

        /// <summary>
        /// Disables RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<OperationResource> DisableRdpAsync(string resourceGroupName, string clusterName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Begins disabling RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<HDInsightOperationResponse> BeginDisablingRdpAsync(string resourceGroupName, string clusterName,
            CancellationToken cancellationToken);

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
        Task<OperationResource> ResizeAsync(string resourceGroupName, string clusterName, int targetInstanceCount,
            CancellationToken cancellationToken);

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
        Task<HDInsightOperationResponse> BeginResizingAsync(string resourceGroupName, string clusterName,
            int targetInstanceCount, CancellationToken cancellationToken);

        /// <summary>
        /// Executes script actions on specified HDInsight Running cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<OperationResource> ExecuteScriptActionsAsync(string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions,
            bool persistOnSuccess, CancellationToken cancellationToken);

        /// <summary>
        /// Begins Executing script actions on specified HDInsight Running cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        Task<HDInsightOperationResponse> BeginExecuteScriptActionsAsync(string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions,
            bool persistOnSuccess, CancellationToken cancellationToken);

    }
}
