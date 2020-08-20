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
        [CodeGenMember("search")]
        internal string SearchText { get; set; }

        /// <summary>
        /// The OData $filter expression to apply to the search query.  You can
        /// use <see cref="SearchFilter.Create(FormattableString)"/> to help
        /// construct the filter expression.
        /// </summary>
        [CodeGenMember("filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The list of field names to use for hit highlights.  Only searchable
        /// fields can be used for hit highlighting.
        /// </summary>
        public IList<string> HighlightFields { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join HighlightFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("HighlightFields")]
        internal string HighlightFieldsRaw
        {
            get => HighlightFields.CommaJoin();
            set => HighlightFields = SearchExtensions.CommaSplit(value);
        }
        #pragma warning restore CA1822

        /// <summary>
        /// The list of field names to which to scope the full-text search.
        /// When using fielded search (fieldName:searchExpression) in a full
        /// Lucene query, the field names of each fielded search expression
        /// take precedence over any field names listed in this parameter.
        /// </summary>
        public IList<string> SearchFields { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join SearchFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("searchFields")]
        internal string SearchFieldsRaw
        {
            get => SearchFields.CommaJoin();
            set => SearchFields = SearchExtensions.CommaSplit(value);
        }
        #pragma warning restore CA1822

        /// <summary>
        /// The list of fields to retrieve.  If unspecified, all fields marked
        /// as retrievable in the schema are included.
        /// </summary>
        public IList<string> Select { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join Select so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("select")]
        internal string SelectRaw
        {
            get => Select.CommaJoin();
            set => Select = SearchExtensions.CommaSplit(value);
        }
        #pragma warning restore CA1822

        /// <summary>
        /// The number of search results to retrieve. This can be used in
        /// conjunction with <see cref="Skip"/> to implement client-side
        /// paging of search results.  If results are truncated due to
        /// server-side paging, the response will include a continuation token
        /// that can be used to issue another Search request for the next page
        /// of results.
        /// </summary>
        [CodeGenMember("top")]
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

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join OrderBy so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("orderby")]
        internal string OrderByRaw
        {
            get => OrderBy.CommaJoin();
            set => OrderBy = SearchExtensions.CommaSplit(value);
        }
        #pragma warning restore CA1822

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
        [CodeGenMember("facets")]
        public IList<string> Facets { get; internal set; } = new List<string>();

        /// <summary>
        /// The list of parameter values to be used in scoring functions (for
        /// example, referencePointParameter) using the format name-values. For
        /// example, if the scoring profile defines a function with a parameter
        /// called &apos;mylocation&apos; the parameter string would be
        /// &quot;mylocation--122.2,44.8&quot; (without the quotes).
        /// </summary>
        [CodeGenMember("scoringParameters")]
        public IList<string> ScoringParameters { get; internal set; } = new List<string>();

        /// <summary>
        /// Shallow copy one SearchOptions instance to another.
        /// </summary>
        /// <param name="source">The source options.</param>
        /// <param name="destination">The destination options.</param>
        private static void Copy(SearchOptions source, SearchOptions destination)
        {
            Debug.Assert(source != null);
            Debug.Assert(destination != null);

            destination.SearchText = source.SearchText;
            destination.Filter = source.Filter;
            destination.HighlightFields = source.HighlightFields;
            destination.SearchFields = source.SearchFields;
            destination.Select = source.Select;
            destination.Size = source.Size;
            destination.OrderBy = source.OrderBy;
            destination.IncludeTotalCount = source.IncludeTotalCount;
            destination.Facets = source.Facets;
            destination.ScoringParameters = source.ScoringParameters;
            destination.HighlightPostTag = source.HighlightPostTag;
            destination.HighlightPreTag = source.HighlightPreTag;
            destination.MinimumCoverage = source.MinimumCoverage;
            destination.QueryType = source.QueryType;
            destination.ScoringProfile = source.ScoringProfile;
            destination.SearchMode = source.SearchMode;
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
