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
        /// Enables HTTP on the specified cluster.
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
        /// <param name='username'>
        /// Required. The http username.
        /// </param>
        /// <param name='password'>
        /// Required. The http password.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightLongRunningOperationResponse EnableHttp(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string username, string password)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).EnableHttpAsync(resourceGroupName, clusterName, username, password),
                    operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Enables HTTP on the specified cluster.
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
        /// <param name='username'>
        /// Required. The http username.
        /// </param>
        /// <param name='password'>
        /// Required. The http password.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightLongRunningOperationResponse> EnableHttpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string username, string password)
        {
            return operations.EnableHttpAsync(resourceGroupName, clusterName, username, password, CancellationToken.None);
        }

        /// <summary>
        /// Begins enabling HTTP on the specified cluster.
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
        /// <param name='username'>
        /// Required. The http username.
        /// </param>
        /// <param name='password'>
        /// Required. The http password.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightOperationResponse BeginEnablingHttp(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string username, string password)
        {
            return
                Task.Factory.StartNew(
                    (object s) =>
                        ((IClusterOperations) s).BeginEnablingHttpAsync(resourceGroupName, clusterName, username,
                            password), operations, CancellationToken.None, TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins enabling HTTP on the specified cluster.
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
        /// <param name='username'>
        /// Required. The http username.
        /// </param>
        /// <param name='password'>
        /// Required. The http password.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightOperationResponse> BeginEnablingHttpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName, string username, string password)
        {
            return operations.BeginEnablingHttpAsync(resourceGroupName, clusterName, username, password,
                CancellationToken.None);
        }

        /// <summary>
        /// Disables HTTP on the specified cluster.
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
        public static HDInsightLongRunningOperationResponse DisableHttp(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return
                Task.Factory.StartNew(
                    (object s) => ((IClusterOperations) s).DisableHttpAsync(resourceGroupName, clusterName), operations,
                    CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Disables HTTP on the specified cluster.
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
        public static Task<HDInsightLongRunningOperationResponse> DisableHttpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return operations.DisableHttpAsync(resourceGroupName, clusterName, CancellationToken.None);
        }

        /// <summary>
        /// Begins disabling HTTP on the specified cluster.
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
        public static HDInsightOperationResponse BeginDisablingHttp(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return
                Task.Factory.StartNew(
                    (object s) => ((IClusterOperations) s).BeginDisablingHttpAsync(resourceGroupName, clusterName),
                    operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Begins disabling HTTP on the specified cluster.
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
        public static Task<HDInsightOperationResponse> BeginDisablingHttpAsync(this IClusterOperations operations,
            string resourceGroupName, string clusterName)
        {
            return operations.BeginDisablingHttpAsync(resourceGroupName, clusterName, CancellationToken.None);
        }
    }
}
