// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Response containing search results from an Azure Search index.
    /// </summary>
    /// <typeparam name="TDoc">
    /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
    /// from the index.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// Type of the model class that encapsulates documents in a search response.
    /// </typeparam>
    public class DocumentSearchResultBase<TResult, TDoc>
        where TResult : SearchResultBase<TDoc>
        where TDoc : class
    {
        /// <summary>
        /// Gets the total count of results found by the search operation, or null if the count was not requested.
        /// </summary>
        /// <remarks>
        /// If present, the count may be greater than the number of results in this response. This can happen if you
        /// use the <c cref="SearchParameters.Top">Top</c> or <c cref="SearchParameters.Skip">Skip</c> parameters, or
        /// if Azure Search can't return all the requested documents in a single Search response.
        /// </remarks>
        public long? Count { get; set; }

        /// <summary>
        /// Gets a value indicating the percentage of the index that was included in the query, or null if
        /// MinimumCoverage was not set in the <c cref="SearchParameters">SearchParameters</c>.
        /// </summary>
        public double? Coverage { get; set; }

        /// <summary>
        /// Gets the facet query results for the search operation, or null if the query did not include any facet
        /// expressions.
        /// </summary>
        public FacetResults Facets { get; set; }

        /// <summary>
        /// Gets the sequence of results returned by the query.
        /// </summary>
        public IList<TResult> Results { get; set; }

        /// <summary>
        /// Gets a continuation token that is used to continue fetching search results. This is necessary when Azure
        /// Search cannot fulfill a search request with a single response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property will be null unless Azure Search can't return all the requested documents in a single Search
        /// response. That can happen for different reasons which are implementation-specific and subject to change.
        /// Robust clients should always be ready to handle cases where fewer documents than expected are returned and
        /// a continuation token is included to continue retrieving documents. If this property is not null, you can
        /// pass its value to the
        /// <c cref="IDocumentsOperations.ContinueSearchWithHttpMessagesAsync(SearchContinuationToken, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, System.Threading.CancellationToken)">ContinueSearchAsync</c>
        /// method to retrieve more search results.
        /// </para>
        /// <para>
        /// Note that this property is not meant to help you implement paging of search results. You can implement
        /// paging using the <c cref="SearchParameters.Top">Top</c> and <c cref="SearchParameters.Skip">Skip</c>
        /// search parameters.
        /// </para>
        /// </remarks>
        public SearchContinuationToken ContinuationToken { get; set; }
    }
}
