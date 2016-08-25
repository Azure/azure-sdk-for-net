// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Contains a document found by a search query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public class SearchResult<T> : SearchResultBase<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        public SearchResult()
        {
            // Do nothing.
        }
    }
}
