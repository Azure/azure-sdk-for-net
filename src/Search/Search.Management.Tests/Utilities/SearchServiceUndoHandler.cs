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
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Test;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    /// <summary>
    /// Undo handler that can automatically delete an Azure Search service.
    /// </summary>
    public class SearchServiceUndoHandler : 
        ComplexTypedOperationUndoHandler<ISearchServiceOperations, SearchManagementClient>
    {
        protected override bool DoLookup(
            IServiceOperations<SearchManagementClient> client, 
            string method, 
            IDictionary<string, object> parameters, 
            out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "CreateOrUpdateAsync":
                    return TryHandleCreateOrUpdateAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        protected override SearchManagementClient GetClientFromOperations(
            IServiceOperations<SearchManagementClient> operations)
        {
            return new SearchManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }

        private bool TryHandleCreateOrUpdateAsync(
            IServiceOperations<SearchManagementClient> client, 
            IDictionary<string, object> parameters, 
            out Action undoAction)
        {
            undoAction = null;
            string serviceName;
            string resourceGroupName;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<string>("resourceGroupName", parameters, out resourceGroupName))
            {
                undoAction = 
                    () =>
                    {
                        using (SearchManagementClient undoClient = GetClientFromOperations(client))
                        {
                            undoClient.Services.Delete(resourceGroupName, serviceName);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "CreateOrUpdateAsync", parameters);
            return false;
        }
    }
}
