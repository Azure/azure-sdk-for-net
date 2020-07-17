// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchIndex
    {
        [CodeGenMember("etag")]
        private string _etag;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndex"/> class.
        /// </summary>
        /// <param name="name">The name of the index.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SearchIndex(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;

            Analyzers = new ChangeTrackingList<LexicalAnalyzer>();
            CharFilters = new ChangeTrackingList<CharFilter>();
            Fields = new ChangeTrackingList<SearchField>();
            ScoringProfiles = new ChangeTrackingList<ScoringProfile>();
            Suggesters = new ChangeTrackingList<SearchSuggester>();
            TokenFilters = new ChangeTrackingList<TokenFilter>();
            Tokenizers = new ChangeTrackingList<LexicalTokenizer>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndex"/> class.
        /// </summary>
        /// <param name="name">The name of the index.</param>
        /// <param name="fields">Fields to add to the index.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="fields"/> is null.</exception>
        public SearchIndex(string name, IEnumerable<SearchField> fields)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(fields, nameof(fields));

            Name = name;

            Analyzers = new ChangeTrackingList<LexicalAnalyzer>();
            CharFilters = new ChangeTrackingList<CharFilter>();
            Fields = new ChangeTrackingList<SearchField>((Optional<IList<SearchField>>)fields.ToArray());
            ScoringProfiles = new ChangeTrackingList<ScoringProfile>();
            Suggesters = new ChangeTrackingList<SearchSuggester>();
            TokenFilters = new ChangeTrackingList<TokenFilter>();
            Tokenizers = new ChangeTrackingList<LexicalTokenizer>();
        }

        /// <summary>
        /// Gets the name of the index.
        /// </summary>
        [CodeGenMember("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the analyzers for the index.
        /// </summary>
        public IList<LexicalAnalyzer> Analyzers { get; }

        /// <summary>
        /// Gets the character filters for the index.
        /// </summary>
        public IList<CharFilter> CharFilters { get; }

        /// <summary>
        /// Gets the fields in the index.
        /// Use <see cref="SimpleField"/>, <see cref="SearchableField"/>, and <see cref="ComplexField"/> for help defining valid indexes.
        /// Index fields have many constraints that are not validated with <see cref="SearchField"/> until the index is created on the server.
        /// </summary>
        public IList<SearchField> Fields { get; }

        /// <summary>
        /// Gets the scoring profiles for the index.
        /// </summary>
        public IList<ScoringProfile> ScoringProfiles { get; }

        /// <summary>
        /// Gets the suggesters for the index.
        /// </summary>
        public IList<SearchSuggester> Suggesters { get; }

        /// <summary>
        /// Gets the token filters for the index.
        /// </summary>
        public IList<TokenFilter> TokenFilters { get; }

        /// <summary>
        /// Gets the tokenizers for the index.
        /// </summary>
        public IList<LexicalTokenizer> Tokenizers { get; }

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchIndex"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }
    }
}
