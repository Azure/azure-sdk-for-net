// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// <summary> Initializes a new instance of <see cref="SearchOptions"/>. </summary>
        /// <param name="includeTotalCount"> A value that specifies whether to fetch the total count of results. Default is false. Setting this value to true may have a performance impact. Note that the count returned is an approximation. </param>
        /// <param name="facets"> The list of facet expressions to apply to the search query. Each facet expression contains a field name, optionally followed by a comma-separated list of name:value pairs. </param>
        /// <param name="filter"> The OData $filter expression to apply to the search query. </param>
        /// <param name="highlightFieldsRaw"> The comma-separated list of field names to use for hit highlights. Only searchable fields can be used for hit highlighting. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. Default is &lt;/em&gt;. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. Default is &lt;em&gt;. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by a search query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 100. </param>
        /// <param name="orderByRaw"> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </param>
        /// <param name="queryType"> A value that specifies the syntax of the search query. The default is 'simple'. Use 'full' if your query uses the Lucene query syntax. </param>
        /// <param name="scoringStatistics"> A value that specifies whether we want to calculate scoring statistics (such as document frequency) globally for more consistent scoring, or locally, for lower latency. The default is 'local'. Use 'global' to aggregate scoring statistics globally before scoring. Using global scoring statistics can increase latency of search queries. </param>
        /// <param name="sessionId"> A value to be used to create a sticky session, which can help getting more consistent results. As long as the same sessionId is used, a best-effort attempt will be made to target the same replica set. Be wary that reusing the same sessionID values repeatedly can interfere with the load balancing of the requests across replicas and adversely affect the performance of the search service. The value used as sessionId cannot start with a '_' character. </param>
        /// <param name="scoringParameters"> The list of parameter values to be used in scoring functions (for example, referencePointParameter) using the format name-values. For example, if the scoring profile defines a function with a parameter called 'mylocation' the parameter string would be "mylocation--122.2,44.8" (without the quotes). </param>
        /// <param name="scoringProfile"> The name of a scoring profile to evaluate match scores for matching documents in order to sort the results. </param>
        /// <param name="semanticQuery"> Allows setting a separate search query that will be solely used for semantic reranking, semantic captions and semantic answers. Is useful for scenarios where there is a need to use different queries between the base retrieval and ranking phase, and the L2 semantic phase. </param>
        /// <param name="semanticConfigurationName"> The name of a semantic configuration that will be used when processing documents for queries of type semantic. </param>
        /// <param name="semanticErrorMode"> Allows the user to choose whether a semantic call should fail completely, or to return partial results (default). </param>
        /// <param name="semanticMaxWaitInMilliseconds"> Allows the user to set an upper bound on the amount of time it takes for semantic enrichment to finish processing before the request fails. </param>
        /// <param name="debug"> Enables a debugging tool that can be used to further explore your reranked results. </param>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchFieldsRaw"> The comma-separated list of field names to which to scope the full-text search. When using fielded search (fieldName:searchExpression) in a full Lucene query, the field names of each fielded search expression take precedence over any field names listed in this parameter. </param>
        /// <param name="searchMode"> A value that specifies whether any or all of the search terms must be matched in order to count the document as a match. </param>
        /// <param name="queryLanguage"> A value that specifies the language of the search query. </param>
        /// <param name="querySpeller"> A value that specified the type of the speller to use to spell-correct individual search query terms. </param>
        /// <param name="queryAnswerRaw"> A value that specifies whether answers should be returned as part of the search response. </param>
        /// <param name="selectRaw"> The comma-separated list of fields to retrieve. If unspecified, all fields marked as retrievable in the schema are included. </param>
        /// <param name="skip"> The number of search results to skip. This value cannot be greater than 100,000. If you need to scan documents in sequence, but cannot use skip due to this limitation, consider using orderby on a totally-ordered key and filter with a range query instead. </param>
        /// <param name="size"> The number of search results to retrieve. This can be used in conjunction with $skip to implement client-side paging of search results. If results are truncated due to server-side paging, the response will include a continuation token that can be used to issue another Search request for the next page of results. </param>
        /// <param name="queryCaptionRaw"> A value that specifies whether captions should be returned as part of the search response. </param>
        /// <param name="queryRewritesRaw"> A value that specifies whether query rewrites should be generated to augment the search query. </param>
        /// <param name="semanticFieldsRaw"> The comma-separated list of field names used for semantic ranking. </param>
        /// <param name="vectorQueries">
        /// The query parameters for vector and hybrid search queries.
        /// Please note <see cref="VectorQuery"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="VectorizableImageBinaryQuery"/>, <see cref="VectorizableImageUrlQuery"/>, <see cref="VectorizableTextQuery"/> and <see cref="VectorizedQuery"/>.
        /// </param>
        /// <param name="filterMode"> Determines whether or not filters are applied before or after the vector search is performed. Default is 'preFilter'. </param>
        /// <param name="hybridSearch"> The query parameters to configure hybrid search behaviors. </param>
        internal SearchOptions(bool? includeTotalCount, IList<string> facets, string filter, string highlightFieldsRaw, string highlightPostTag, string highlightPreTag, double? minimumCoverage, string orderByRaw, SearchQueryType? queryType, ScoringStatistics? scoringStatistics, string sessionId, IList<string> scoringParameters, string scoringProfile, QueryDebugMode? debug, string searchText, string searchFieldsRaw, SearchMode? searchMode, QueryLanguage? queryLanguage, QuerySpellerType? querySpeller, string selectRaw, int? skip, int? size, string semanticConfigurationName, SemanticErrorMode? semanticErrorMode, int? semanticMaxWaitInMilliseconds, string semanticQuery, string queryAnswerRaw, string queryCaptionRaw, string queryRewritesRaw, string semanticFieldsRaw, IList<VectorQuery> vectorQueries, VectorFilterMode? filterMode, HybridSearch hybridSearch)
        {
            SemanticSearch = (semanticConfigurationName != null || semanticErrorMode != null || semanticMaxWaitInMilliseconds != null || queryAnswerRaw != null || queryCaptionRaw != null || semanticQuery != null || semanticFieldsRaw != null) ? new SemanticSearchOptions() : null;
            if (SemanticSearch != null)
            {
                SemanticSearch.QueryAnswer = queryAnswerRaw != null ? new QueryAnswer() : null;
                SemanticSearch.QueryCaption = queryCaptionRaw != null ? new QueryCaption() : null;
                SemanticSearch.QueryRewrites = queryRewritesRaw != null ? new QueryRewrites() : null;
            }

            VectorSearch = (vectorQueries != null || filterMode != null) ? new VectorSearchOptions() : null;

            IncludeTotalCount = includeTotalCount;
            Facets = facets;
            Filter = filter;
            HighlightFieldsRaw = highlightFieldsRaw;
            HighlightPostTag = highlightPostTag;
            HighlightPreTag = highlightPreTag;
            MinimumCoverage = minimumCoverage;
            OrderByRaw = orderByRaw;
            QueryType = queryType;
            ScoringStatistics = scoringStatistics;
            SessionId = sessionId;
            ScoringParameters = scoringParameters;
            ScoringProfile = scoringProfile;
            Debug = debug;
            SearchText = searchText;
            SearchFieldsRaw = searchFieldsRaw;
            SearchMode = searchMode;
            QueryLanguage = queryLanguage;
            QuerySpeller = querySpeller;
            SelectRaw = selectRaw;
            Skip = skip;
            Size = size;
            SemanticConfigurationName = semanticConfigurationName;
            SemanticErrorMode = semanticErrorMode;
            SemanticMaxWaitInMilliseconds = semanticMaxWaitInMilliseconds;
            SemanticQuery = semanticQuery;
            QueryAnswerRaw = queryAnswerRaw;
            QueryCaptionRaw = queryCaptionRaw;
            QueryRewritesRaw = queryRewritesRaw;
            SemanticFieldsRaw = semanticFieldsRaw;
            VectorQueries = vectorQueries;
            FilterMode = filterMode;
            HybridSearch = hybridSearch;
        }

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
            set => HighlightFields = InternalSearchExtensions.CommaSplit(value);
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
            set => SearchFields = InternalSearchExtensions.CommaSplit(value);
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
            set => Select = InternalSearchExtensions.CommaSplit(value);
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
            set => OrderBy = InternalSearchExtensions.CommaSplit(value);
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

        /// <summary> A value that specifies the language of the search query. </summary>
        [CodeGenMember("QueryLanguage")]
        public QueryLanguage? QueryLanguage { get; set; }

        /// <summary> A value that specifies the type of the speller to use to spell-correct individual search query terms. </summary>
        [CodeGenMember("Speller")]
        public QuerySpellerType? QuerySpeller { get; set; }

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
                if (SemanticSearch != null)
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
                if (SemanticSearch?.QueryAnswer != null)
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
                if (SemanticSearch?.QueryCaption != null)
                {
                    SemanticSearch.QueryCaption.QueryCaptionRaw = value;
                }
            }
        }

        /// <summary> Constructed from <see cref="QueryRewrites.RewritesType"/> and <see cref="QueryRewrites.Count"/>. For example: "generative|count-3"</summary>
        [CodeGenMember("QueryRewrites")]
        private string QueryRewritesRaw
        {
            get { return SemanticSearch?.QueryRewrites?.QueryRewritesRaw; }
            set
            {
                if (SemanticSearch?.QueryRewrites != null)
                {
                    SemanticSearch.QueryRewrites.QueryRewritesRaw = value;
                }
            }
        }

        /// <summary> The comma-separated list of field names used for semantic ranking. </summary>
        [CodeGenMember("SemanticFields")]
        private string SemanticFieldsRaw
        {
            get { return SemanticSearch?.SemanticFieldsRaw; }
            set
            {
                if (SemanticSearch != null)
                {
                    SemanticSearch.SemanticFieldsRaw = value;
                }
            }
        }

        /// <summary> Allows setting a separate search query that will be solely used for semantic reranking, semantic captions and semantic answers. Is useful for scenarios where there is a need to use different queries between the base retrieval and ranking phase, and the L2 semantic phase. </summary>
        [CodeGenMember("SemanticQuery")]
        private string SemanticQuery
        {
            get { return SemanticSearch?.SemanticQuery; }
            set
            {
                if (SemanticSearch != null)
                {
                    SemanticSearch.SemanticQuery = value;
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
                if (SemanticSearch != null)
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
                if (SemanticSearch != null)
                {
                    SemanticSearch.MaxWait = value.HasValue ? TimeSpan.FromMilliseconds(value.Value) : null;
                }
            }
        }

        /// <summary> The query parameters for multi-vector search queries. </summary>
        private IList<VectorQuery> VectorQueries
        {
            get { return VectorSearch?.Queries != null ? VectorSearch.Queries : new ChangeTrackingList<VectorQuery>(); }
            set
            {
                if (VectorSearch != null)
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
                if (VectorSearch != null)
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
            destination.QueryLanguage = source.QueryLanguage;
            destination.QuerySpeller = source.QuerySpeller;
            destination.SemanticSearch = source.SemanticSearch;
            destination.VectorSearch = source.VectorSearch;
            destination.HybridSearch  = source.HybridSearch;
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
