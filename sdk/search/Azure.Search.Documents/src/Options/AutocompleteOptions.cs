// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchIndexClient.AutocompleteAsync"/> that
    /// allow specifying autocomplete behaviors, like fuzzy matching.
    /// </summary>
    [CodeGenSchema("AutocompleteRequest")]
    public partial class AutocompleteOptions : SearchRequestOptions
    {
        /// <summary>
        /// The search text on which to base autocomplete results.
        /// </summary>
        [CodeGenSchemaMember("search")]
        internal string SearchText { get; set; }

        /// <summary>
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </summary>
        [CodeGenSchemaMember("suggesterName")]
        internal string SuggesterName { get; set; }

        /// <summary>
        /// Specifies the mode for Autocomplete. The default is
        /// <see cref="AutocompleteMode.OneTerm"/>. Use
        /// <see cref="AutocompleteMode.TwoTerms"/> to get shingles and
        /// <see cref="AutocompleteMode.OneTermWithContext"/> to use the
        /// current context while producing auto-completed terms.
        /// </summary>
        [CodeGenSchemaMember("autocompleteMode")]
        public AutocompleteMode? Mode { get; set; }

        /// <summary>
        /// An OData expression that filters the documents used to produce
        /// completed terms for the Autocomplete result.  You can use
        /// <see cref="SearchFilter.Create(FormattableString)"/> to help
        /// construct the filter expression.
        /// </summary>
        [CodeGenSchemaMember("filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The number of auto-completed terms to retrieve. This must be a
        /// value between 1 and 100. The default is 5.
        /// </summary>
        [CodeGenSchemaMember("top")]
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
        [CodeGenSchemaMember("searchFields")]
        internal string SearchFieldsRaw
        {
            get => SearchFields.CommaJoin();
            set => throw new InvalidOperationException($"Cannot deserialize {nameof(AutocompleteOptions)}.");
        }
        #pragma warning restore CA1822
    }
}
