// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Response containing search results from an Azure Search index.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
    /// from the index.
    /// </typeparam>
    public class DocumentSearchResult<T> : DocumentSearchResultBase<SearchResult<T>, T> where T : class
    {
    }
}
