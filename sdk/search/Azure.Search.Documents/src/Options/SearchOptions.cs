// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchClient.SearchAsync"/> that
    /// allow specifying filtering, sorting, faceting, paging, and other search
    /// query behaviors.
    /// </summary>
    /// <seealso href="https://docs.microsoft.com/rest/api/searchservice/search-documents#query-parameters">Query Parameters.</seealso>
    [CodeGenModel("SearchRequest")]
    public partial class SearchOptions
    {
        private const string QueryAnswerRawSplitter = "|count-";
        private const string QueryCaptionRawSplitter = "|highlight-";

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

        /// <summary> The list of field names used for semantic search. </summary>
        public IList<string> SemanticFields { get; internal set; } = new List<string>();

        /// <summary>
        /// Join SemanticFields so it can be sent as a comma-separated string.
        /// </summary>
        [CodeGenMember("SemanticFields")]
        internal string SemanticFieldsRaw
        {
            get => SemanticFields.CommaJoin();
            set => SemanticFields = SearchExtensions.CommaSplit(value);
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

        /// <summary> The name of a semantic configuration that will be used when processing documents for queries of type semantic. </summary>
        [CodeGenMember("SemanticConfiguration")]
        public string SemanticConfigurationName { get; set; }

        /// <summary> A value that specifies the language of the search query. </summary>
        [CodeGenMember("QueryLanguage")]
        public QueryLanguage? QueryLanguage { get; set; }

        /// <summary> A value that specifies the type of the speller to use to spell-correct individual search query terms. </summary>
        [CodeGenMember("Speller")]
        public QuerySpellerType? QuerySpeller { get; set; }

        /// <summary> A value that specifies whether <see cref="SearchResults{T}.Answers"/> should be returned as part of the search response. </summary>
        public QueryAnswerType? QueryAnswer { get; set; }

        /// <summary> A value that specifies the number of <see cref="SearchResults{T}.Answers"/> that should be returned as part of the search response. </summary>
        public int? QueryAnswerCount { get; set; }

        /// <summary> Constructed from <see cref="QueryAnswer"/> and <see cref="QueryAnswerCount"/>.</summary>
        [CodeGenMember("Answers")]
        internal string QueryAnswerRaw
        {
            get
            {
                string queryAnswerStringValue = null;

                if (QueryAnswer.HasValue)
                {
                    queryAnswerStringValue = $"{QueryAnswer.Value}{QueryAnswerRawSplitter}{QueryAnswerCount.GetValueOrDefault(1)}";
                }

                return queryAnswerStringValue;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    QueryAnswer = null;
                    QueryAnswerCount = null;
                }
                else
                {
                    if (value.Contains(QueryAnswerRawSplitter))
                    {
                        var queryAnswerPart = value.Substring(0, value.IndexOf(QueryAnswerRawSplitter, StringComparison.OrdinalIgnoreCase));
                        var countPart = value.Substring(value.IndexOf(QueryAnswerRawSplitter, StringComparison.OrdinalIgnoreCase) + QueryAnswerRawSplitter.Length);

                        if (string.IsNullOrEmpty(queryAnswerPart))
                        {
                            QueryAnswer = null;
                        }
                        else
                        {
                            QueryAnswer = new QueryAnswerType(queryAnswerPart);
                        }

                        if (int.TryParse(countPart, out int countValue))
                        {
                            QueryAnswerCount = countValue;
                        }
                    }
                    else
                    {
                        QueryAnswer = new QueryAnswerType(value);
                        QueryAnswerCount = null;
                    }
                }
            }
        }

        /// <summary>
        /// A value that specifies whether <see cref="SearchResults{T}.Captions"/> should be returned as part of the search response.
        /// <para>The default value is <see cref="QueryCaptionType.None"/>.</para>
        /// </summary>
        public QueryCaptionType? QueryCaption { get; set; }

        /// <summary>
        /// If <see cref="QueryCaption"/> is set to <see cref="QueryCaptionType.Extractive"/>, setting this to <c>true</c> enables highlighting of the returned captions.
        /// It populates <see cref="CaptionResult.Highlights"/>.
        /// <para>The default value is <c>true</c>.</para>
        /// </summary>
        public bool? QueryCaptionHighlightEnabled { get; set; }

        /// <summary> Constructed from <see cref="QueryCaption"/> and <see cref="QueryCaptionHighlightEnabled"/>.</summary>
        [CodeGenMember("Captions")]
        internal string QueryCaptionRaw
        {
            get
            {
                string queryCaptionStringValue = null;

                if (QueryCaption.HasValue)
                {
                    queryCaptionStringValue = $"{QueryCaption.Value}{QueryCaptionRawSplitter}{QueryCaptionHighlightEnabled.GetValueOrDefault(true)}";
                }

                return queryCaptionStringValue;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    QueryCaption = null;
                    QueryCaptionHighlightEnabled = null;
                }
                else
                {
                    int splitIndex = value.IndexOf(QueryCaptionRawSplitter, StringComparison.OrdinalIgnoreCase);
                    if (splitIndex >= 0)
                    {
                        var queryCaptionPart = value.Substring(0, splitIndex);
                        var highlightPart = value.Substring(splitIndex + QueryCaptionRawSplitter.Length);

                        QueryCaption = string.IsNullOrEmpty(queryCaptionPart) ? null : new QueryCaptionType(queryCaptionPart);
                        QueryCaptionHighlightEnabled = bool.TryParse(highlightPart, out bool highlightValue) ? highlightValue : null;
                    }
                    else
                    {
                        QueryCaption = new QueryCaptionType(value);
                        QueryCaptionHighlightEnabled = null;
                    }
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
            Debug.Assert(source != null);
            Debug.Assert(destination != null);

            destination.Facets = source.Facets;
            destination.Filter = source.Filter;
            destination.HighlightFields = source.HighlightFields;
            destination.HighlightPostTag = source.HighlightPostTag;
            destination.HighlightPreTag = source.HighlightPreTag;
            destination.IncludeTotalCount = source.IncludeTotalCount;
            destination.MinimumCoverage = source.MinimumCoverage;
            destination.OrderBy = source.OrderBy;
            destination.QueryAnswer = source.QueryAnswer;
            destination.QueryAnswerCount = source.QueryAnswerCount;
            destination.QueryCaption = source.QueryCaption;
            destination.QueryCaptionHighlightEnabled = source.QueryCaptionHighlightEnabled;
            destination.QueryLanguage = source.QueryLanguage;
            destination.QuerySpeller = source.QuerySpeller;
            destination.QueryType = source.QueryType;
            destination.ScoringParameters = source.ScoringParameters;
            destination.ScoringProfile = source.ScoringProfile;
            destination.ScoringStatistics = source.ScoringStatistics;
            destination.SearchFields = source.SearchFields;
            destination.SearchMode = source.SearchMode;
            destination.SearchText = source.SearchText;
            destination.Select = source.Select;
            destination.SemanticConfigurationName = source.SemanticConfigurationName;
            destination.SemanticFields = source.SemanticFields;
            destination.SessionId = source.SessionId;
            destination.Size = source.Size;
            destination.Skip = source.Skip;
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
