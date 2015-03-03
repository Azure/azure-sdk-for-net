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
        /// Retrieves the next page of search results from the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798927.aspx for more information)
        /// </summary>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the ContinueSearch and ContinueSearchAsync methods make a best-effort attempt
        /// to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSearchResponse ContinueSearch(
            this IDocumentOperations operations, 
            SearchContinuationToken continuationToken)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).ContinueSearchAsync(continuationToken);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798927.aspx for more information)
        /// </summary>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the ContinueSearch and ContinueSearchAsync methods make a best-effort attempt
        /// to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentSearchResponse> ContinueSearchAsync(
            this IDocumentOperations operations,
            SearchContinuationToken continuationToken)
        {
            return operations.ContinueSearchAsync(continuationToken, CancellationToken.None);
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798927.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the ContinueSearch and ContinueSearchAsync methods support mapping of
        /// Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSearchResponse<T> ContinueSearch<T>(
            this IDocumentOperations operations, 
            SearchContinuationToken continuationToken)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).ContinueSearchAsync<T>(continuationToken);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798927.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the ContinueSearch and ContinueSearchAsync methods support mapping of
        /// Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentSearchResponse<T>> ContinueSearchAsync<T>(
            this IDocumentOperations operations,
            SearchContinuationToken continuationToken) where T : class
        {
            return operations.ContinueSearchAsync<T>(continuationToken, CancellationToken.None);
        }
    }
}
