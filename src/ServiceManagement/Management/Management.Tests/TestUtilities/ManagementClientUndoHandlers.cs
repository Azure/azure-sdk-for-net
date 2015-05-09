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
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Testing
{
    /// <summary>
    /// Undo Handler for ManagementClient AffinityGroup operations
    /// </summary>
    public class AffinityGroupUndoHandler : ComplexTypedOperationUndoHandler<IAffinityGroupOperations, ManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given AffinityGroup operation
        /// </summary>
        /// <param name="client">The IAffinityGroupOperations instance used for the operation</param>
        /// <param name="method">The name of the affinity group method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateAsync":
                    return TryHandleCreateAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        protected override ManagementClient GetClientFromOperations(IServiceOperations<ManagementClient> operations)
        {
            return new ManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }

        private bool TryHandleCreateAsync(IServiceOperations<ManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            AffinityGroupCreateParameters createParameters;
            if (TryAssignParameter<AffinityGroupCreateParameters>("parameters", parameters, out createParameters)
                && createParameters != null
                && createParameters.Name != null)
            {
                undoAction = () => 
                    {
                        using(ManagementClient managment = GetClientFromOperations(client))
                        {
                            managment.AffinityGroups.Delete(createParameters.Name);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "CreateAsync", parameters);
            return false;
        }

    }
}
