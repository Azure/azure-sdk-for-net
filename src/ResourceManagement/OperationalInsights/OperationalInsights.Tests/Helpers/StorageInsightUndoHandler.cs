// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Hyak.Common;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Test;

namespace OperationalInsights.Tests.Helpers
{
    /// <summary>
    /// Undo Handler for storage insight operations
    /// </summary>
    public class StorageInsightUndoHandler : ComplexTypedOperationUndoHandler<IStorageInsightOperations, OperationalInsightsManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given storage insight operation
        /// </summary>
        /// <param name="client">The IWorkspaceOperations instance used for the operation</param>
        /// <param name="method">The name of the workspace method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<OperationalInsightsManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateOrUpdateAsync":
                    return TryHandleCreateOrUpdateAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleCreateOrUpdateAsync(IServiceOperations<OperationalInsightsManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            StorageInsightCreateOrUpdateParameters createParameters;
            string resourceGroupName;
            string workspaceName;
            if (TryAssignParameter<StorageInsightCreateOrUpdateParameters>(TestHelper.ParametersParameter, parameters, out createParameters)
                && createParameters != null
                && createParameters.StorageInsight != null
                && createParameters.StorageInsight.Name != null
                && TryAssignParameter<string>(TestHelper.ResourceGroupNameParameter, parameters, out resourceGroupName)
                && TryAssignParameter<string>(TestHelper.WorkspaceNameParameter, parameters, out workspaceName))
            {
                undoAction = () =>
                {
                    using (OperationalInsightsManagementClient operationalInsights = GetClientFromOperations(client))
                    {
                        operationalInsights.StorageInsights.Delete(resourceGroupName, workspaceName, createParameters.StorageInsight.Name);
                    }
                };

                return true;
            }

            TraceParameterError(this, "CreateOrUpdateAsync", parameters);
            return false;
        }

        protected override OperationalInsightsManagementClient GetClientFromOperations(IServiceOperations<OperationalInsightsManagementClient> operations)
        {
            return new OperationalInsightsManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }
}
