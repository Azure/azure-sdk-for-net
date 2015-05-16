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
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Test;

namespace Microsoft.Azure.Search.Tests
{
    /// <summary>
    /// Undo handler that can automatically delete an Azure Search index.
    /// </summary>
    public class IndexUndoHandler :
        ComplexTypedOperationUndoHandler<IIndexOperations, SearchServiceClient>
    {
        protected override bool DoLookup(
            IServiceOperations<SearchServiceClient> client,
            string method,
            IDictionary<string, object> parameters,
            out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "CreateOrUpdateAsync":
                case "CreateAsync":
                    return TryHandleCreateAsync(client, parameters, method, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        protected override SearchServiceClient GetClientFromOperations(
            IServiceOperations<SearchServiceClient> operations)
        {
            return new SearchServiceClient(
                operations.Client.Credentials, 
                operations.Client.BaseUri);
        }

        private bool TryHandleCreateAsync(
            IServiceOperations<SearchServiceClient> client,
            IDictionary<string, object> parameters,
            string method,
            out Action undoAction)
        {
            undoAction = null;
            Index index;
            if (TryAssignParameter<Index>("index", parameters, out index))
            {
                undoAction =
                    () =>
                    {
                        using (SearchServiceClient undoClient = GetClientFromOperations(client))
                        {
                            undoClient.Indexes.Delete(index.Name);
                        }
                    };

                return true;
            }

            TraceParameterError(this, method, parameters);
            return false;
        }
    }
}
