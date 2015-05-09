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

using System;
using System.Collections.Generic;
using Hyak.Common;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.WindowsAzure.Management.Storage.Testing
{
    /// <summary>
    /// Undo Handler for StorageManagementClient StorageAccount operations
    /// </summary>
    public class StorageAccountUndoHandler : ComplexTypedOperationUndoHandler<IStorageAccountOperations, StorageManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given StorageAccount management operation
        /// </summary>
        /// <param name="client">The IStorageAccountOperations instance used for the operation</param>
        /// <param name="method">The name of the storage account method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<StorageManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "BeginCreatingAsync":
                    return TryHandleBeginCreatingAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginCreatingAsync(IServiceOperations<StorageManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            StorageAccountCreateParameters createParameters;
            if (TryAssignParameter<StorageAccountCreateParameters>("parameters", parameters, out createParameters)
                && createParameters != null
                && createParameters.Name != null)
            {
                undoAction = () =>
                    {
                        using (StorageManagementClient storage = GetClientFromOperations(client))
                        {
                            storage.StorageAccounts.Delete(createParameters.Name);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "BeginCreatingAsync", parameters);
            return false;
        }

        protected override StorageManagementClient GetClientFromOperations(IServiceOperations<StorageManagementClient> operations)
        {
            return new StorageManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }
}
