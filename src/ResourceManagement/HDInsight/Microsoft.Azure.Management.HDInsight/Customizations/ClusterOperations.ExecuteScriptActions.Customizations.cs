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

using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight
{
    internal partial class ClusterOperations : IClusterOperations
    {
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
        public async Task<OperationResource> ExecuteScriptActionsAsync(string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions,
            bool persistOnSuccess, CancellationToken cancellationToken)
        {
            try
            {
                var executeScriptActionsParams = new ExecuteScriptActionParameters { ScriptActions = scriptActions, PersistOnSuccess = persistOnSuccess };
                return await ExecuteScriptActionsAsync(resourceGroupName, clusterName, executeScriptActionsParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begins Executing script actions on specified HDInsight Running cluster
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
        public async Task<HDInsightOperationResponse> BeginExecuteScriptActionsAsync(string resourceGroupName, string clusterName, IList<RuntimeScriptAction> scriptActions,
            bool persistOnSuccess, CancellationToken cancellationToken)
        {
            try
            {
                var executeScriptActionsParams = new ExecuteScriptActionParameters { ScriptActions = scriptActions, PersistOnSuccess = persistOnSuccess };
                return await BeginExecuteScriptActionsAsync(resourceGroupName, clusterName, executeScriptActionsParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }
    }
}
