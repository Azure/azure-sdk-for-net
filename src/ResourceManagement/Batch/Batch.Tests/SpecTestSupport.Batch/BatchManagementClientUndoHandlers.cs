//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;

namespace Microsoft.Azure.Batch.Test
{
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Test;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Undo handler for Account Operations
    /// </summary>
    public class AccountUndoHandler : ComplexTypedOperationUndoHandler<IAccountOperations, BatchManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given Account operation
        /// </summary>
        /// <param name="client">The IDeploymentOperations instance used for the operation</param>
        /// <param name="method">The name of the deployment method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<BatchManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "BeginCreatingAsync":
                    return TryHandleBeginCreatingAsync(client, parameters, out undoAction);
                case "CreateAsync":
                    return false;       // no need to have two undo calls for the same account
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginCreatingAsync(IServiceOperations<BatchManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string resGroupName;
            string acctName;
            BatchAccountCreateParameters createParams;
            
            if (TryAssignParameter<string>("resourceGroupName", parameters, out resGroupName) &&
                TryAssignParameter<string>("accountName", parameters, out acctName) &&
                TryAssignParameter<BatchAccountCreateParameters>("parameters", parameters, out createParams) &&
                !string.IsNullOrEmpty(resGroupName) && !string.IsNullOrEmpty(acctName) &&
                createParams != null && !string.IsNullOrEmpty(createParams.Location))
            {
                undoAction = () =>
                    {
                        using (BatchManagementClient batchClient = GetClientFromOperations(client))
                        {
                            batchClient.Accounts.Delete(resGroupName, acctName);
                        }
                    };
                return true;
            }

            TraceParameterError(this, "BeginCreatingAsync", parameters);
            return false;
        }

        protected override BatchManagementClient GetClientFromOperations(IServiceOperations<BatchManagementClient> operations)
        {
            return new BatchManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Discovery extensions - used to discover and construct available undo handlers 
    /// in the current app domain
    /// </summary>

    [UndoHandlerFactory]
    public static class UndoContextDiscoveryExtensions
    {
        /// <summary>
        /// Create the undo handler for deployment operations
        /// </summary>
        /// <returns>An undo handler for deployment operations</returns>
        public static OperationUndoHandler CreateAccountUndoHandler()
        {
            return new AccountUndoHandler();
        }
    }
}
