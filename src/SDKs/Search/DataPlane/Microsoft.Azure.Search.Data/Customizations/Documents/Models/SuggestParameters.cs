// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Parameters for filtering, sorting, fuzzy matching, and other
    /// suggestions query behaviors.
    /// </summary>
    public class SuggestParameters
    {
        private static readonly IList<string> Empty = new string[0];

        /// <summary>
        /// Initializes a new instance of the SuggestParameters class.
        /// </summary>
        public SuggestParameters() { }

        /// <summary>
        /// Gets or sets the OData $filter expression to apply to the
        /// suggestions query.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is appended to hit highlights. Must
        /// be set with HighlightPreTag. If omitted, hit highlighting of
        /// suggestions is disabled.
        /// </summary>
        public string HighlightPostTag { get; set; }

        /// <summary>
        /// Gets or sets a string tag that is prepended to hit highlights.
        /// Must be set with HighlightPostTag. If omitted, hit highlighting
        /// of suggestions is disabled.
        /// </summary>
        public string HighlightPreTag { get; set; }

        /// <summary>
        /// Gets or sets a number between 0 and 100 indicating the percentage
        /// of the index that must be covered by a suggestion query in order
        /// for the query to be reported as a success. This parameter can be
        /// useful for ensuring search availability even for services with
        /// only one replica. The default is 80.
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
        /// Gets or sets the list of field names to consider when querying for
        /// suggestions.
        /// </summary>
        public IList<string> SearchFields { get; set; }

        /// <summary>
        /// Gets or sets the list of fields to retrieve. If unspecified, all
        /// fields marked as retrievable in the schema are included.
        /// </summary>
        public IList<string> Select { get; set; }

        /// <summary>
        /// Gets or sets the number of suggestions to retrieve. This must be a
        /// value between 1 and 100. The default is to 5.
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use fuzzy matching for
        /// the suggestion query. Default is false. when set to true, the
        /// query will find suggestions even if there's a substituted or
        /// missing character in the search text. While this provides a
        /// better experience in some scenarios it comes at a performance
        /// cost as fuzzy suggestion searches are slower and consume more
        /// resources.
        /// </summary>
        public bool UseFuzzyMatching { get; set; }

        /// <summary>
        /// Converts the SuggestParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the suggestion parameters.</returns>
        public override string ToString() => String.Join("&", GetAllOptions());

        internal SuggestParametersPayload ToPayload(string searchText, string suggesterName) =>
            new SuggestParametersPayload()
            {
                Filter = Filter,
                Fuzzy = UseFuzzyMatching,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                Select = (Select != null && Select.Any()) ? Select.ToCommaSeparatedString() : "*",
                SuggesterName = suggesterName,
                Top = Top
            };

        private IEnumerable<QueryOption> GetAllOptions()
        {
            if (Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(Filter));
            }

            if (HighlightPreTag != null)
            {
                yield return new QueryOption("highlightPreTag", Uri.EscapeDataString(HighlightPreTag));
            }

            if (HighlightPostTag != null)
            {
                yield return new QueryOption("highlightPostTag", Uri.EscapeDataString(HighlightPostTag));
            }

            if (MinimumCoverage != null)
            {
                yield return new QueryOption("minimumCoverage", MinimumCoverage.ToString());
            }

            if (OrderBy != null && OrderBy.Any())
            {
                yield return new QueryOption("$orderby", OrderBy);
            }

            if (SearchFields != null && SearchFields.Any())
            {
                yield return new QueryOption("searchFields", SearchFields);
            }

            if (Select != null && Select.Any())
            {
                yield return new QueryOption("$select", Select);
            }
            else
            {
                yield return new QueryOption("$select", "*");
            }

            if (Top != null)
            {
                yield return new QueryOption("$top", Top.ToString());
            }

            yield return new QueryOption("fuzzy", UseFuzzyMatching.ToString().ToLowerInvariant());
        }
    }
}
