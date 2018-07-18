//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace ApiManagement.Tests
{
    using System;
    using System.Collections.Generic;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement;
    using Microsoft.Azure.Test;

    public class ApiManagementResourceProviderUndoHandler : ComplexTypedOperationUndoHandler<IResourceProviderOperations, ApiManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given ApiManagement operation
        /// </summary>
        /// <param name="client">The IServiceOperations instance used for the operation</param>
        /// <param name="method">The name of the ApiManagement method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ApiManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "BeginCreatingOrUpdatingAsync":
                    return TryHandleBeginCreatingOrUpdatingAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginCreatingOrUpdatingAsync(IServiceOperations<ApiManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string resourceGroupName;
            string name;
            if (TryAssignParameter("resourceGroupName", parameters, out resourceGroupName) &&
                TryAssignParameter("name", parameters, out name) &&
                !string.IsNullOrWhiteSpace(resourceGroupName) &&
                !string.IsNullOrWhiteSpace(name))
            {
                undoAction = () =>
                {
                    using (var apiManagementClient = GetClientFromOperations(client))
                    {
                        apiManagementClient.RefreshAccessToken();
                        apiManagementClient.ResourceProvider.Delete(resourceGroupName, name);
                    }
                };

                return true;
            }

            TraceParameterError(this, "CreateOrUpdateAsync", parameters);
            return false;
        }

        protected override ApiManagementClient GetClientFromOperations(IServiceOperations<ApiManagementClient> operations)
        {
            return new ApiManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }
}