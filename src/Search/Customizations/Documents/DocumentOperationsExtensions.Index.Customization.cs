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
    public static partial class DocumentOperationsExtensions
    {
        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexResponse">IndexResponse</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static DocumentIndexResponse Index(this IDocumentOperations operations, IndexBatch batch)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).IndexAsync(batch);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/> for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexResponse">IndexResponse</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static Task<DocumentIndexResponse> IndexAsync(this IDocumentOperations operations, IndexBatch batch)
        {
            return operations.IndexAsync(batch, CancellationToken.None);
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexResponse">IndexResponse</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentIndexResponse Index<T>(this IDocumentOperations operations, IndexBatch<T> batch)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).IndexAsync<T>(batch);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.  (see
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/> for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexResponse">IndexResponse</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentIndexResponse> IndexAsync<T>(
            this IDocumentOperations operations, 
            IndexBatch<T> batch) where T : class
        {
            return operations.IndexAsync<T>(batch, CancellationToken.None);
        }
    }
}
