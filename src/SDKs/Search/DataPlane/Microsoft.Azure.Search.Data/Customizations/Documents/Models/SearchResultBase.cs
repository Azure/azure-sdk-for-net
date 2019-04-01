// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Abstract base class for a result containing a document found by a search query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    public abstract class SearchResultBase<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the SearchResultBase class.
        /// </summary>
        protected SearchResultBase()
        {
            // Do nothing.
        }

        /// <summary>
        /// Gets the relevance score of the document compared to other documents returned by the query.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Gets text snippets from the document that indicate the matching search terms; null if hit highlighting
        /// was not enabled for the query.
        /// </summary>
        public HitHighlights Highlights { get; set; }

        /// <summary>
        /// Gets the document found by the search query.
        /// </summary>
        public T Document { get; set; }
    }
}
