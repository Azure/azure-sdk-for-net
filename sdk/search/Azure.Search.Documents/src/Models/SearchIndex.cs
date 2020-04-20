// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("Index")]
    public partial class SearchIndex
    {
        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

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

            Analyzers = new List<Analyzer>();
            CharFilters = new List<CharFilter>();
            Fields = new List<SearchField>();
            ScoringProfiles = new List<ScoringProfile>();
            Suggesters = new List<Suggester>();
            TokenFilters = new List<TokenFilter>();
            Tokenizers = new List<Tokenizer>();
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

            Analyzers = new List<Analyzer>();
            CharFilters = new List<CharFilter>();
            Fields = new List<SearchField>(fields);
            ScoringProfiles = new List<ScoringProfile>();
            Suggesters = new List<Suggester>();
            TokenFilters = new List<TokenFilter>();
            Tokenizers = new List<Tokenizer>();
        }

        /// <summary>
        /// Gets the name of the index.
        /// </summary>
        [CodeGenMember("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the analyzers for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<Analyzer> Analyzers { get; }

        /// <summary>
        /// Gets the character filters for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<CharFilter> CharFilters { get; }

        /// <summary>
        /// Gets the fields in the index.
        /// Use <see cref="SimpleField"/>, <see cref="SearchableField"/>, and <see cref="ComplexField"/> for help defining valid indexes.
        /// Index fields have many constraints that are not validated with <see cref="SearchField"/> until the index is created on the server.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<SearchField> Fields { get; }

        /// <summary>
        /// Gets the scoring profiles for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<ScoringProfile> ScoringProfiles { get; }

        /// <summary>
        /// Gets the suggesters for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<Suggester> Suggesters { get; }

        /// <summary>
        /// Gets the token filters for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<TokenFilter> TokenFilters { get; }

        /// <summary>
        /// Gets the tokenizers for the index.
        /// </summary>
        [CodeGenMember(Initialize = true, EmptyAsUndefined = true)]
        public IList<Tokenizer> Tokenizers { get; }
    }
}
