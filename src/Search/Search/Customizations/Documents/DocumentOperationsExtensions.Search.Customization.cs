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
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Search and SearchAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSearchResponse Search(this IDocumentOperations operations, string searchText)
        {
            return operations.Search(searchText, new SearchParameters());
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Search and SearchAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSearchResponse Search(
            this IDocumentOperations operations, 
            string searchText,
            SearchParameters searchParameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).SearchAsync(searchText, searchParameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Search and SearchAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentSearchResponse> SearchAsync(this IDocumentOperations operations, string searchText)
        {
            return operations.SearchAsync(searchText, new SearchParameters());
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Search and SearchAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentSearchResponse> SearchAsync(
            this IDocumentOperations operations,
            string searchText,
            SearchParameters searchParameters)
        {
            return operations.SearchAsync(searchText, searchParameters, CancellationToken.None);
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Search and SearchAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSearchResponse<T> Search<T>(this IDocumentOperations operations, string searchText)
            where T : class
        {
            return operations.Search<T>(searchText, new SearchParameters());
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Search and SearchAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSearchResponse<T> Search<T>(
            this IDocumentOperations operations,
            string searchText,
            SearchParameters searchParameters)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).SearchAsync<T>(searchText, searchParameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Search and SearchAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentSearchResponse<T>> SearchAsync<T>(
            this IDocumentOperations operations,
            string searchText) where T : class
        {
            return operations.SearchAsync<T>(searchText, new SearchParameters());
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Search.IDocumentOperations.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Search and SearchAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentSearchResponse<T>> SearchAsync<T>(
            this IDocumentOperations operations,
            string searchText,
            SearchParameters searchParameters) where T : class
        {
            return operations.SearchAsync<T>(searchText, searchParameters, CancellationToken.None);
        }
    }
}
