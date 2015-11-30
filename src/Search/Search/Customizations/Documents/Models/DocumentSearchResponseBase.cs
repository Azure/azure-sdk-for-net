// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Collections.Generic;
using Hyak.Common;

namespace Microsoft.Azure.Search.Models
{
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
    public class DocumentSearchResponseBase<TResult, TDoc> : AzureOperationResponse, IEnumerable<TResult>
        where TResult : SearchResultBase<TDoc>
        where TDoc : class
    {
        private IList<TResult> _results;

        /// <summary>
        /// Initializes a new instance of the DocumentSearchResponseBase class.
        /// </summary>
        protected DocumentSearchResponseBase()
        {
            _results = new LazyList<TResult>();
        }

        /// <summary>
        /// Gets the total count of results found by the search operation, or null if the count was not requested.
        /// </summary>
        /// <remarks>
        /// If present, the count may be greater than the number of results in this response. In that case, use the
        /// ContinuationToken property to fetch the next page of results.
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
        public IList<TResult> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        /// <summary>
        /// Gets a continuation token that can be used to fetch the next page of search results from an
        /// Azure Search index.
        /// </summary>
        /// <remarks>
        /// This property will be null unless you request more results than the page size. This can happen either when
        /// you do not specify <c cref="SearchParameters.Top">Top</c> and there are more than 50 results (default page
        /// size is 50), or when you specify a value greater than 1000 for <c cref="SearchParameters.Top">Top</c> and
        /// there are more than 1000 results (maximum page size is 1000). In either case, you can pass the value of
        /// this property to the
        /// <c cref="IDocumentOperations.ContinueSearchAsync(SearchContinuationToken, System.Threading.CancellationToken)">ContinueSearchAsync</c>
        /// method to retrieve the next page of results.
        /// </remarks>
        public SearchContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Gets the sequence of Results.
        /// </summary>
        public IEnumerator<TResult> GetEnumerator()
        {
            return this.Results.GetEnumerator();
        }

        /// <summary>
        /// Gets the sequence of Results.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
