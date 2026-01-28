// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Search.Documents.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchClient.AutocompleteAsync"/> that
    /// allow specifying autocomplete behaviors, like fuzzy matching.
    /// </summary>
    [CodeGenType("AutocompletePostRequest")]
    [CodeGenSuppress(nameof(AutocompleteOptions), typeof(string), typeof(string))]
    public partial class AutocompleteOptions
    {
        /// <summary>
        /// Initializes new instance of <see cref="AutocompleteOptions"/>
        /// </summary>
        public AutocompleteOptions()
        {
        }

        /// <summary>
        /// The search text on which to base autocomplete results.
        /// </summary>
        internal string SearchText { get; set; }

        /// <summary>
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </summary>
        internal string SuggesterName { get; set; }

        /// <summary>
        /// Specifies the mode for Autocomplete. The default is
        /// <see cref="AutocompleteMode.OneTerm"/>. Use
        /// <see cref="AutocompleteMode.TwoTerms"/> to get shingles and
        /// <see cref="AutocompleteMode.OneTermWithContext"/> to use the
        /// current context while producing auto-completed terms.
        /// </summary>
        [CodeGenMember("AutocompleteMode")]
        public AutocompleteMode? Mode { get; set; }

        /// <summary>
        /// An OData expression that filters the documents used to produce
        /// completed terms for the Autocomplete result.  You can use
        /// <see cref="SearchFilter.Create(FormattableString)"/> to help
        /// construct the filter expression.
        /// </summary>
        [CodeGenMember("Filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The number of auto-completed terms to retrieve. This must be a
        /// value between 1 and 100. The default is 5.
        /// </summary>
        [CodeGenMember("Top")]
        public int? Size { get; set; }

        /// <summary>
        /// The list of field names to consider when querying for
        /// auto-completed terms. Target fields must be included in the
        /// specified suggester.
        /// </summary>
        public IList<string> SearchFields { get; internal set; } = new List<string>();

        #pragma warning disable CA1822 // Only (unused but required) setters are static
        /// <summary>
        /// Join SearchFields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("SearchFields")]
        internal string SearchFieldsRaw
        {
            get => SearchFields.CommaJoin();
            set => throw new InvalidOperationException($"Cannot deserialize {nameof(AutocompleteOptions)}.");
        }
#pragma warning restore CA1822

        /// <summary> A value indicating whether to use fuzzy matching for the autocomplete query. Default is false. When set to true, the query will autocomplete terms even if there's a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy autocomplete queries are slower and consume more resources. </summary>
        public bool? UseFuzzyMatching { get; set; }

        /// <summary> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting is disabled. </summary>
        public string HighlightPostTag { get; set; }

        /// <summary> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting is disabled. </summary>
        public string HighlightPreTag { get; set; }

        /// <summary> A number between 0 and 100 indicating the percentage of the index that must be covered by an autocomplete query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </summary>
        public double? MinimumCoverage { get; set; }

        /// <summary>
        /// Creates a shallow copy of the AutocompleteOptions.
        /// </summary>
        /// <returns>The cloned AutocompleteOptions.</returns>
        internal AutocompleteOptions Clone() =>
            new AutocompleteOptions
            {
                SearchText = SearchText,
                SuggesterName = SuggesterName,
                Mode = Mode,
                Filter = Filter,
                Size = Size,
                SearchFields = SearchFields,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                UseFuzzyMatching = UseFuzzyMatching,
            };
    }
}
