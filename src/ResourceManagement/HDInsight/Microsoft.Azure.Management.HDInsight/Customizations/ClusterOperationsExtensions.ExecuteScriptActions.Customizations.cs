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

using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight
{
    /// <summary>
    /// The HDInsight Management Client.
    /// </summary>
    public static partial class ClusterOperationsExtensions
    {
        /// <summary>
        /// Executes script actions on specified HDInsight Running cluster.
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
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static OperationResource ExecuteScriptActions(this IClusterOperations operations, string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions, bool persistOnSuccess)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IClusterOperations)s).ExecuteScriptActionsAsync(resourceGroupName, clusterName, scriptActions, persistOnSuccess);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes script actions on specified HDInsight Running cluster.
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
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<OperationResource> ExecuteScriptActionsAsync(this IClusterOperations operations, string resourceGroupName, string clusterName,
            IList<RuntimeScriptAction> scriptActions, bool persistOnSuccess)
        {
            return operations.ExecuteScriptActionsAsync(resourceGroupName, clusterName, scriptActions, persistOnSuccess, CancellationToken.None);
        }

        /// <summary>
        /// Begins Executing script actions on specified HDInsight Running cluster.
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
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static HDInsightOperationResponse BeginExecuteScriptActions(this IClusterOperations operations, string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions, bool persistOnSuccess)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IClusterOperations)s).BeginExecuteScriptActionsAsync(resourceGroupName, clusterName, scriptActions, persistOnSuccess);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Begins Executing script actions on specified HDInsight Running cluster.
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
        /// <param name='scriptActions'>
        /// Required. The list of script actions that needs to be executed.
        /// </param>      
        /// <param name='persistOnSuccess'>
        /// Required. Flag indicating if the script needs to be persisted.
        /// </param>   
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public static Task<HDInsightOperationResponse> BeginExecuteScriptActionsAsync(this IClusterOperations operations, string resourceGroupName, string clusterName,
            IList<RuntimeScriptAction> scriptActions, bool persistOnSuccess)
        {
            return operations.BeginExecuteScriptActionsAsync(resourceGroupName, clusterName, scriptActions, persistOnSuccess, CancellationToken.None);
        }
    }
}
