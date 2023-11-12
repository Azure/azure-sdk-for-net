// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchClient.SearchAsync(string, SearchOptions, CancellationToken)"/> that
    /// allow specifying filtering, sorting, faceting, paging, and other search
    /// query behaviors.
    /// </summary>
    /// <seealso href="https://docs.microsoft.com/rest/api/searchservice/search-documents#query-parameters">Query Parameters.</seealso>
    [CodeGenModel("SearchRequest")]
    public partial class SearchOptions
    {
        /// <summary>
        /// Initializes a new instance of SearchOptions from a continuation
        /// token to continue fetching results from a previous search.
        /// </summary>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search
        /// results from the index.
        /// </param>
        internal SearchOptions(string continuationToken) =>
            Copy(SearchContinuationToken.Deserialize(continuationToken), this);

        /// <summary>
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.
        /// </summary>
        [CodeGenMember("Search")]
        internal string SearchText { get; set; }

        /// <summary>
        /// The OData $filter expression to apply to the search query.  You can
        /// use <see cref="SearchFilter.Create(FormattableString)"/> to help
        /// construct the filter expression.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/azure/search/search-filters">Filters in Azure Cognitive Search</seealso>
        [CodeGenMember("Filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The list of field names to use for hit highlights.  Only searchable
        /// fields can be used for hit highlighting.
        /// </summary>
        public IList<string> HighlightFields { get; internal set; } = new List<string>();

        /// <summary>
        /// Join HighlightFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("HighlightFields")]
        internal string HighlightFieldsRaw
        {
            get => HighlightFields.CommaJoin();
            set => HighlightFields = SearchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// The list of field names to which to scope the full-text search.
        /// When using fielded search (fieldName:searchExpression) in a full
        /// Lucene query, the field names of each fielded search expression
        /// take precedence over any field names listed in this parameter.
        /// </summary>
        public IList<string> SearchFields { get; internal set; } = new List<string>();

        /// <summary>
        /// Join SearchFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("SearchFields")]
        internal string SearchFieldsRaw
        {
            get => SearchFields.CommaJoin();
            set => SearchFields = SearchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// The list of fields to retrieve.  If unspecified, all fields marked
        /// as retrievable in the schema are included.
        /// </summary>
        public IList<string> Select { get; internal set; } = new List<string>();

        /// <summary>
        /// Join Select so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("Select")]
        internal string SelectRaw
        {
            get => Select.CommaJoin();
            set => Select = SearchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// The number of search results to retrieve. This can be used in
        /// conjunction with <see cref="Skip"/> to implement client-side
        /// paging of search results.  If results are truncated due to
        /// server-side paging, the response will include a continuation token
        /// that can be used to issue another Search request for the next page
        /// of results.
        /// </summary>
        [CodeGenMember("Top")]
        public int? Size { get; set; }

        /// <summary>
        /// The list of OData $orderby expressions by which to sort the
        /// results. Each expression can be either a field name or a call to
        /// either the geo.distance() or the search.score() functions. Each
        /// expression can be followed by asc to indicate ascending, or desc to
        /// indicate descending. The default is ascending order. Ties will be
        /// broken by the match scores of documents. If no $orderby is
        /// specified, the default sort order is descending by document match
        /// score. There can be at most 32 $orderby clauses.
        /// </summary>
        public IList<string> OrderBy { get; internal set; } = new List<string>();

        /// <summary>
        /// Join OrderBy so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("OrderBy")]
        internal string OrderByRaw
        {
            get => OrderBy.CommaJoin();
            set => OrderBy = SearchExtensions.CommaSplit(value);
        }

        /// <summary>
        /// A value that specifies whether to fetch the total count of results
        /// as the <see cref="Models.SearchResults{T}.TotalCount"/> property.
        /// The default value is false.  Setting this value to true may have a
        /// performance impact.  Note that the count returned is an
        /// approximation.
        /// </summary>
        [CodeGenMember("IncludeTotalResultCount")]
        public bool? IncludeTotalCount { get; set; }

        /// <summary>
        /// The list of facet expressions to apply to the search query. Each
        /// facet expression contains a field name, optionally followed by a
        /// comma-separated list of name:value pairs.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/azure/search/search-filters-facets">How to build a facet filter in Azure Cognitive Search.</seealso>
        [CodeGenMember("Facets")]
        public IList<string> Facets { get; internal set; } = new List<string>();

        /// <summary>
        /// The list of parameter values to be used in scoring functions (for
        /// example, referencePointParameter) using the format name-values. For
        /// example, if the scoring profile defines a function with a parameter
        /// called &apos;mylocation&apos; the parameter string would be
        /// &quot;mylocation--122.2,44.8&quot; (without the quotes).
        /// </summary>
        [CodeGenMember("ScoringParameters")]
        public IList<string> ScoringParameters { get; internal set; } = new List<string>();

        /// <summary> Options for performing Semantic Search. </summary>
        public SemanticSearchOptions SemanticSearch { get; set; }

        /// <summary> Options for performing Vector Search. </summary>
        public VectorSearchOptions VectorSearch { get; set; }

        /// <summary> The name of a semantic configuration that will be used when processing documents for queries of type semantic. </summary>
        [CodeGenMember("SemanticConfiguration")]
        private string SemanticConfigurationName
        {
            get { return SemanticSearch?.SemanticConfigurationName; }
            set
            {
                if (SemanticSearch?.SemanticConfigurationName != null)
                {
                    SemanticSearch.SemanticConfigurationName = value;
                }
            }
        }

        /// <summary> Constructed from <see cref="QueryAnswer.AnswerType"/>, <see cref="QueryAnswer.Count"/> and <see cref="QueryAnswer.Threshold"/>. For example: "extractive|count-1,threshold-0.7"</summary>
        [CodeGenMember("Answers")]
        private string QueryAnswerRaw
        {
            get { return SemanticSearch?.QueryAnswer?.QueryAnswerRaw; }
            set
            {
                if (SemanticSearch?.QueryAnswer?.QueryAnswerRaw != null)
                {
                    SemanticSearch.QueryAnswer.QueryAnswerRaw = value;
                }
            }
        }

        /// <summary> Constructed from <see cref="QueryCaption.CaptionType"/> and <see cref="QueryCaption.HighlightEnabled"/>.</summary>
        [CodeGenMember("Captions")]
        private string QueryCaptionRaw
        {
            get { return SemanticSearch?.QueryCaption?.QueryCaptionRaw; }
            set
            {
                if (SemanticSearch?.QueryCaption?.QueryCaptionRaw != null)
                {
                    SemanticSearch.QueryCaption.QueryCaptionRaw = value;
                }
            }
        }

        /// <summary> Allows the user to choose whether a semantic call should fail completely (default / current behavior), or to return partial results. </summary>
        [CodeGenMember("SemanticErrorHandling")]
        private SemanticErrorMode? SemanticErrorMode
        {
            get { return SemanticSearch?.ErrorMode; }
            set
            {
                if (SemanticSearch?.ErrorMode != null)
                {
                    SemanticSearch.ErrorMode = value;
                }
            }
        }

        /// <summary> Allows the user to set an upper bound on the amount of time it takes for semantic enrichment to finish processing before the request fails. </summary>
        private int? SemanticMaxWaitInMilliseconds
        {
            get
            {
                return (int?)SemanticSearch?.MaxWait?.TotalMilliseconds;
            }
            set
            {
                if (SemanticSearch?.MaxWait != null)
                {
                    SemanticSearch.MaxWait = value.HasValue ? TimeSpan.FromMilliseconds(value.Value) : null;
                }
            }
        }

        /// <summary> The query parameters for multi-vector search queries. </summary>
        private IList<VectorQuery> VectorQueries
        {
            get { return VectorSearch?.Queries != null? VectorSearch.Queries : new ChangeTrackingList<VectorQuery>(); }
            set
            {
                if (VectorSearch?.Queries != null)
                {
                    VectorSearch.Queries = value;
                }
            }
        }

        /// <summary> Determines whether or not filters are applied before or after the vector search is performed. Default is <see cref="VectorFilterMode.PreFilter" /> for new indexes. </summary>
        [CodeGenMember("VectorFilterMode")]
        private VectorFilterMode? FilterMode
        {
            get { return VectorSearch?.FilterMode; }
            set
            {
                if (VectorSearch?.FilterMode != null)
                {
                    VectorSearch.FilterMode = value;
                }
            }
        }

        /// <summary>
        /// Shallow copy one SearchOptions instance to another.
        /// </summary>
        /// <param name="source">The source options.</param>
        /// <param name="destination">The destination options.</param>
        private static void Copy(SearchOptions source, SearchOptions destination)
        {
            System.Diagnostics.Debug.Assert(source != null);
            System.Diagnostics.Debug.Assert(destination != null);

            destination.Facets = source.Facets;
            destination.Filter = source.Filter;
            destination.HighlightFields = source.HighlightFields;
            destination.HighlightPostTag = source.HighlightPostTag;
            destination.HighlightPreTag = source.HighlightPreTag;
            destination.IncludeTotalCount = source.IncludeTotalCount;
            destination.MinimumCoverage = source.MinimumCoverage;
            destination.OrderBy = source.OrderBy;
            destination.QueryType = source.QueryType;
            destination.ScoringParameters = source.ScoringParameters;
            destination.ScoringProfile = source.ScoringProfile;
            destination.ScoringStatistics = source.ScoringStatistics;
            destination.SearchFields = source.SearchFields;
            destination.SearchMode = source.SearchMode;
            destination.SearchText = source.SearchText;
            destination.Select = source.Select;
            destination.SessionId = source.SessionId;
            destination.Size = source.Size;
            destination.Skip = source.Skip;
            destination.SemanticSearch = source.SemanticSearch;
            destination.VectorSearch = source.VectorSearch;
        }

        /// <summary>
        /// Creates a shallow copy of the SearchOptions.
        /// </summary>
        /// <returns>The cloned SearchOptions.</returns>
        internal SearchOptions Clone()
        {
            SearchOptions clone = new SearchOptions();
            Copy(this, clone);
            return clone;
        }
    }
}
