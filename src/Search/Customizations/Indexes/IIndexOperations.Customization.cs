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

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    public partial interface IIndexOperations
    {
        /// <summary>
        /// Creates a new index client for querying and managing documents in a given index.
        /// </summary>
        /// <param name="indexName">The name of the index.</param>
        /// <returns>A new <c cref="Microsoft.Azure.Search.SearchIndexClient">SearchIndexClient</c> instance.</returns>
        /// <remarks>
        /// The new client is configured with full read-write access to the index. If you are only planning to use the
        /// client for query operations, we recommend directly creating a 
        /// <c cref="Microsoft.Azure.Search.SearchIndexClient">SearchIndexClient</c> instance instead.
        /// </remarks>
        SearchIndexClient GetClient(string indexName);

        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        Task<bool> ExistsAsync(string indexName, CancellationToken cancellationToken);

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798923.aspx"/> for
        /// more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response from a List Index Names request. If successful, it
        /// includes the name of each index.
        /// </returns>
        Task<IndexListNamesResponse> ListNamesAsync(CancellationToken cancellationToken);
    }
}
