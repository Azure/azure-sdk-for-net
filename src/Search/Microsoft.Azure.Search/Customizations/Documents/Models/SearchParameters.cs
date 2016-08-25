// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters for filtering, sorting, faceting, paging, and other search
    /// query behaviors.
    /// </summary>
    public class SearchParameters
    {
        private static readonly IList<string> Empty = new string[0];

        /// <summary>
        /// Initializes a new instance of the SearchParameters class.
        /// </summary>
        public SearchParameters() { }

        /// <summary>
        /// Gets or sets the list of facet expressions to apply to the search query. Each facet expression contains a
        /// field name, optionally followed by a comma-separated list of name:value pairs.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        public IList<string> Facets { get; set; }

        /// <summary>
        /// Gets or sets the OData $filter expression to apply to the search
        /// query.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets the list of field names to use for hit highlights.
        /// Only searchable fields can be used for hit highlighting.
        /// </summary>
        public IList<string> HighlightFields { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is appended to hit highlights. Must
        /// be set with HighlightPreTag. Default is &amp;lt;/em&amp;gt;.
        /// </summary>
        public string HighlightPostTag { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is prepended to hit highlights.
        /// Must be set with HighlightPostTag. Default is &amp;lt;em&amp;gt;.
        /// </summary>
        public string HighlightPreTag { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies whether to fetch the total
        /// count of results. Default is false. Setting this value to true
        /// may have a performance impact. Note that the count returned is an
        /// approximation.
        /// </summary>
        public bool IncludeTotalResultCount { get; set; }

        /// <summary>
        /// Gets or sets a number between 0 and 100 indicating the percentage
        /// of the index that must be covered by a search query in order for
        /// the query to be reported as a success. This parameter can be
        /// useful for ensuring search availability even for services with
        /// only one replica. The default is 100.
        /// </summary>
        public double? MinimumCoverage { get; set; }

        /// <summary>
        /// Gets or sets the list of OData $orderby expressions by which to
        /// sort the results. Each expression can be either a field name or a
        /// call to the geo.distance() function. Each expression can be
        /// followed by asc to indicate ascending, and desc to indicate
        /// descending. The default is ascending order. Ties will be broken
        /// by the match scores of documents. If no OrderBy is specified, the
        /// default sort order is descending by document match score. There
        /// can be at most 32 Orderby clauses.
        /// </summary>
        public IList<string> OrderBy { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies the syntax of the search query.
        /// The default is 'simple'. Use 'full' if your query uses the Lucene
        /// query syntax. Possible values for this property include: 'simple', 'full'.
        /// </summary>
        public QueryType QueryType { get; set; }

        /// <summary>
        /// Gets or sets the list of parameter values to be used in scoring
        /// functions (for example, referencePointParameter). Each parameter is
        /// a name/value pair encapsulated in a ScoringParameter object.
        /// </summary>
        public IList<ScoringParameter> ScoringParameters { get; set; }

        /// <summary>
        /// Gets or sets the name of a scoring profile to evaluate match
        /// scores for matching documents in order to sort the results.
        /// </summary>
        public string ScoringProfile { get; set; }

        /// <summary>
        /// Gets or sets the list of field names to include in the full-text
        /// search.
        /// </summary>
        public IList<string> SearchFields { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies whether any or all of the
        /// search terms must be matched in order to count the document as a
        /// match. Possible values for this property include: 'any', 'all'.
        /// </summary>
        public SearchMode SearchMode { get; set; }

        /// <summary>
        /// Gets or sets the list of fields to retrieve. If unspecified, all
        /// fields marked as retrievable in the schema are included.
        /// </summary>
        public IList<string> Select { get; set; }

        /// <summary>
        /// Gets or sets the number of search results to skip. This value
        /// cannot be greater than 100,000. If you need to scan documents in
        /// sequence, but cannot use Skip due to this limitation, consider
        /// using OrderBy on a totally-ordered key and Filter with a range
        /// query instead.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Gets or sets the number of search results to retrieve. This can be
        /// used in conjunction with Skip to implement client-side paging of
        /// search results.
        /// </summary>
        public int? Top { get; set; }

        private IList<string> ScoringParameterStrings
        {
            get
            {
                if (this.ScoringParameters == null)
                {
                    return Empty;
                }

                return ScoringParameters.Select(p => p.ToString()).ToList();
            }
        }

        /// <summary>
        /// Converts the SearchParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the search parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", this.GetAllOptions());
        }

        internal SearchParametersPayload ToPayload(string searchText)
        {
            return new SearchParametersPayload()
            {
                Count = this.IncludeTotalResultCount,
                Facets = this.Facets ?? Empty,
                Filter = this.Filter,
                Highlight = this.HighlightFields.ToCommaSeparatedString(),
                HighlightPostTag = this.HighlightPostTag,
                HighlightPreTag = this.HighlightPreTag,
                MinimumCoverage = this.MinimumCoverage,
                OrderBy = this.OrderBy.ToCommaSeparatedString(),
                QueryType = this.QueryType,
                ScoringParameters = this.ScoringParameterStrings,
                ScoringProfile = this.ScoringProfile,
                Search = searchText,
                SearchFields = this.SearchFields.ToCommaSeparatedString(),
                SearchMode = this.SearchMode,
                Select = this.Select.ToCommaSeparatedString(),
                Skip = this.Skip,
                Top = this.Top
            };
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            yield return new QueryOption("$count", this.IncludeTotalResultCount.ToString().ToLowerInvariant());

            foreach (string facetExpr in this.Facets ?? Empty)
            {
                yield return new QueryOption("facet", Uri.EscapeDataString(facetExpr));
            }

            if (this.Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(this.Filter));
            }

            if (this.HighlightFields != null && this.HighlightFields.Any())
            {
                yield return new QueryOption("highlight", this.HighlightFields);
            }

            if (this.HighlightPreTag != null)
            {
                yield return new QueryOption("highlightPreTag", Uri.EscapeDataString(this.HighlightPreTag));
            }

            if (this.HighlightPostTag != null)
            {
                yield return new QueryOption("highlightPostTag", Uri.EscapeDataString(this.HighlightPostTag));
            }

            if (this.MinimumCoverage != null)
            {
                yield return new QueryOption("minimumCoverage", this.MinimumCoverage.ToString());
            }

            if (this.OrderBy != null && this.OrderBy.Any())
            {
                yield return new QueryOption("$orderby", this.OrderBy);
            }

            yield return new QueryOption("queryType", (this.QueryType == Models.QueryType.Simple) ? "simple" : "full");

            foreach (string scoringParameterExpr in this.ScoringParameterStrings)
            {
                yield return new QueryOption("scoringParameter", scoringParameterExpr);
            }

            if (this.ScoringProfile != null)
            {
                yield return new QueryOption("scoringProfile", this.ScoringProfile);
            }

            if (this.SearchFields != null && this.SearchFields.Any())
            {
                yield return new QueryOption("searchFields", this.SearchFields);
            }

            yield return new QueryOption("searchMode", (this.SearchMode == Models.SearchMode.Any) ? "any" : "all");

            if (this.Select != null && this.Select.Any())
            {
                yield return new QueryOption("$select", this.Select);
            }

            if (this.Skip != null)
            {
                yield return new QueryOption("$skip", this.Skip.ToString());
            }

            if (this.Top != null)
            {
                yield return new QueryOption("$top", this.Top.ToString());
            }
        }
    }
}
