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
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest and SuggestAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSuggestResponse Suggest(
            this IDocumentOperations operations, 
            string searchText,
            string suggesterName)
        {
            return operations.Suggest(searchText, suggesterName, new SuggestParameters());
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest and SuggestAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSuggestResponse Suggest(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).SuggestAsync(searchText, suggesterName, suggestParameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest and SuggestAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentSuggestResponse> SuggestAsync(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName)
        {
            return operations.SuggestAsync(searchText, suggesterName, new SuggestParameters());
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest and SuggestAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Task<DocumentSuggestResponse> SuggestAsync(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters)
        {
            return operations.SuggestAsync(searchText, suggesterName, suggestParameters, CancellationToken.None);
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest and SuggestAsync methods support mapping of Azure Search field types
        /// to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSuggestResponse<T> Suggest<T>(
            this IDocumentOperations operations, 
            string searchText,
            string suggesterName)
            where T : class
        {
            return operations.Suggest<T>(searchText, suggesterName, new SuggestParameters());
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest and SuggestAsync methods support mapping of Azure Search field types
        /// to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSuggestResponse<T> Suggest<T>(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters)
            where T : class
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IDocumentOperations)s).SuggestAsync<T>(searchText, suggesterName, suggestParameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest and SuggestAsync methods support mapping of Azure Search field types
        /// to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentSuggestResponse<T>> SuggestAsync<T>(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName) where T : class
        {
            return operations.SuggestAsync<T>(searchText, suggesterName, new SuggestParameters());
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.  (see
        /// https://msdn.microsoft.com/en-us/library/azure/dn798936.aspx for more information)
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest and SuggestAsync methods support mapping of Azure Search field types
        /// to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static Task<DocumentSuggestResponse<T>> SuggestAsync<T>(
            this IDocumentOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters) where T : class
        {
            return operations.SuggestAsync<T>(searchText, suggesterName, suggestParameters, CancellationToken.None);
        }
    }
}
