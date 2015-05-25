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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
{
    public partial interface IDocumentOperations
    {
        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798936.aspx"/>
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest and SuggestAsync methods make a best-effort attempt to map JSON
        /// types in the response payload to .NET types. See
        /// <see cref="IDocumentOperations.GetAsync(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        Task<DocumentSuggestResponse> SuggestAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798936.aspx"/>
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest and SuggestAsync methods support mapping of Azure Search field types
        /// to .NET types via the type parameter T. See 
        /// <see cref="IDocumentOperations.GetAsync&lt;T&gt;(string, IEnumerable&lt;string&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        Task<DocumentSuggestResponse<T>> SuggestAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            CancellationToken cancellationToken) where T : class;
    }
}
