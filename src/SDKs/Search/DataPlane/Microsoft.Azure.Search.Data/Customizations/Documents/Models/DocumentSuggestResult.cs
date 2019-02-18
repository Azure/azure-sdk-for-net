// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Response containing suggestion query results from an Azure Search index.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
    /// from the index.
    /// </typeparam>
    public class DocumentSuggestResult<T>
    {
        /// <summary>
        /// Gets a value indicating the percentage of the index that was included in the query, or null if
        /// MinimumCoverage was not set in the <c cref="SuggestParameters">SuggestParameters</c>.
        /// </summary>
        public double? Coverage { get; set; }

        /// <summary>
        /// Gets the sequence of results returned by the query.
        /// </summary>
        public IList<SuggestResult<T>> Results { get; set; }
    }
}
