// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Search.Models
{
    public partial class DocumentSearchResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the DocumentSearchResult class. This constructor is intended to be used for test purposes, since
        /// the properties of this class are immutable.
        /// </summary>
        /// <param name="results">The sequence of results returned by the query.</param>
        /// <param name="count">The total count of results found by the search operation, or null if the count was not requested.</param>
        /// <param name="coverage">A value indicating the percentage of the index that was included in the query, or null if
        /// MinimumCoverage was not set in the <see cref="SearchParameters" />.</param>
        /// <param name="facets">The facet query results for the search operation, or null if the query did not include any facet
        /// expressions.</param>
        /// <param name="continuationToken">A continuation token that is used to continue fetching search results. This is necessary when
        /// Azure Cognitive Search cannot fulfill a search request with a single response.</param>
        public DocumentSearchResult(
            IList<SearchResult<T>> results, 
            long? count, 
            double? coverage, 
            IDictionary<string, IList<FacetResult>> facets, 
            SearchContinuationToken continuationToken)
        {
            Count = count;
            Coverage = coverage;
            Facets = facets;
            Results = results;
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Gets a continuation token that is used to continue fetching search results. This is necessary when Azure
        /// Search cannot fulfill a search request with a single response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property will be null unless Azure Cognitive Search can't return all the requested documents in a single Search
        /// response. That can happen for different reasons which are implementation-specific and subject to change.
        /// Robust clients should always be ready to handle cases where fewer documents than expected are returned and
        /// a continuation token is included to continue retrieving documents. If this property is not null, you can
        /// pass its value to the
        /// <see cref="IDocumentsOperations.ContinueSearchWithHttpMessagesAsync(SearchContinuationToken, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, System.Threading.CancellationToken)" />
        /// method to retrieve more search results.
        /// </para>
        /// <para>
        /// Note that this property is not meant to help you implement paging of search results. You can implement
        /// paging using the <see cref="SearchParameters.Top" /> and <see cref="SearchParameters.Skip" />
        /// search parameters.
        /// </para>
        /// </remarks>
        public SearchContinuationToken ContinuationToken { get; private set; }

        partial void CustomInit()
        {
            // Ensure ContinuationToken is initialized.
            ContinuationToken = NextLink != null ? new SearchContinuationToken(NextLink, NextPageParameters) : null;
        }

        // Without this, CustomInit() won't be called on deserialization because no constructors are called.
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) => CustomInit();
    }
}
