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
        /// Enables RDP on the specified cluster.
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
        /// <param name='rdpUsername'>
        /// Required. The RDP Username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='rdpExpiryDate'>
        /// Required. The expiry date of the RDP user.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static OperationResource EnableRdp(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string rdpUsername, string rdpPassword, DateTime rdpExpiryDate)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations)s).EnableRdpAsync(resourceGroupName, clusterName, rdpUsername, rdpPassword, rdpExpiryDate),
                    operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Enables RDP on the specified cluster.
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
        /// <param name='rdpUsername'>
        /// Required. The RDP Username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='rdpExpiryDate'>
        /// Required. The expiry date of the RDP user.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<OperationResource> EnableRdpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string rdpUsername, string rdpPassword, DateTime rdpExpiryDate)
        {
            return operations.EnableRdpAsync(resourceGroupName, clusterName, rdpUsername, rdpPassword, rdpExpiryDate,
                CancellationToken.None);
        }

        /// <summary>
        /// Begins enabling RDP on the specified cluster.
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
        /// <param name='rdpUsername'>
        /// Required. The RDP Username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='rdpExpiryDate'>
        /// Required. The expiry date of the RDP user.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightOperationResponse BeginEnablingRdp(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string rdpUsername, string rdpPassword, DateTime rdpExpiryDate)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).BeginEnablingRdpAsync(resourceGroupName, clusterName, rdpUsername,
                            rdpPassword, rdpExpiryDate), operations, CancellationToken.None, TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins enabling RDP on the specified cluster.
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
        /// <param name='rdpUsername'>
        /// Required. The RDP Username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='rdpExpiryDate'>
        /// Required. The expiry date of the RDP user.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightOperationResponse> BeginEnablingRdpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string rdpUsername, string rdpPassword, DateTime rdpExpiryDate)
        {
            return operations.BeginEnablingRdpAsync(resourceGroupName, clusterName, rdpUsername, rdpPassword,
                rdpExpiryDate, CancellationToken.None);
        }

        /// <summary>
        /// Disables RDP on the specified cluster.
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
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static OperationResource DisableRdp(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).DisableRdpAsync(resourceGroupName, clusterName), operations,
                    CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Disables RDP on the specified cluster.
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
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<OperationResource> DisableRdpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return operations.DisableRdpAsync(resourceGroupName, clusterName, CancellationToken.None);
        }

        /// <summary>
        /// Begins disabling RDP on the specified cluster.
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
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightOperationResponse BeginDisablingRdp(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).BeginDisablingRdpAsync(resourceGroupName, clusterName), operations,
                    CancellationToken.None, TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins disabling RDP on the specified cluster.
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
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightOperationResponse> BeginDisablingRdpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return operations.BeginDisablingRdpAsync(resourceGroupName, clusterName, CancellationToken.None);
        }
    }
}
