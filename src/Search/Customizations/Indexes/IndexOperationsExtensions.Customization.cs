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
    public static partial class IndexOperationsExtensions
    {
        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IIndexOperations.
        /// </param>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(this IIndexOperations operations, string indexName)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IIndexOperations)s).ExistsAsync(indexName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IIndexOperations.
        /// </param>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        public static Task<bool> ExistsAsync(this IIndexOperations operations, string indexName)
        {
            return operations.ExistsAsync(indexName, CancellationToken.None);
        }

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798923.aspx"/> for
        /// more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IIndexOperations.
        /// </param>
        /// <returns>
        /// Response from a List Index Names request. If successful, it
        /// includes the name of each index.
        /// </returns>
        public static IndexListNamesResponse ListNames(this IIndexOperations operations)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IIndexOperations)s).ListNamesAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798923.aspx"/> for
        /// more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IIndexOperations.
        /// </param>
        /// <returns>
        /// Response from a List Index Names request. If successful, it
        /// includes the name of each index.
        /// </returns>
        public static Task<IndexListNamesResponse> ListNamesAsync(this IIndexOperations operations)
        {
            return operations.ListNamesAsync(CancellationToken.None);
        }
    }
}
