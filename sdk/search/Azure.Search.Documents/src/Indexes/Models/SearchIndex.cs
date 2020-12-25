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
        // Force the constructor to set the field;
        // otherwise, when getting only names, the setter will throw.
        [CodeGenMember("fields")]
        private IList<SearchField> _fields;

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
            Fields = new List<SearchField>();
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
            Fields = fields.ToList();
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
        /// Gets or sets the fields in the index.
        /// Use <see cref="FieldBuilder"/> to define fields based on a model class,
        /// or <see cref="SimpleField"/>, <see cref="SearchableField"/>, and <see cref="ComplexField"/> to manually define fields.
        /// Index fields have many constraints that are not validated with <see cref="SearchField"/> until the index is created on the server.
        /// </summary>
        /// <example>
        /// You can create fields from a model class using <see cref="FieldBuilder"/>:
        /// <code snippet="Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex_New_SearchIndex">
        /// SearchIndex index = new SearchIndex(&quot;hotels&quot;)
        /// {
        ///     Fields = new FieldBuilder().Build(typeof(Hotel)),
        ///     Suggesters =
        ///     {
        ///         // Suggest query terms from the hotelName field.
        ///         new SearchSuggester(&quot;sg&quot;, &quot;hotelName&quot;)
        ///     }
        /// };
        /// </code>
        /// For this reason, <see cref="Fields"/> is settable. In scenarios when the model is not known or cannot be modified, you can
        /// also create fields manually using helper classes:
        /// <code snippet="Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex_New_SearchIndex">
        /// SearchIndex index = new SearchIndex(&quot;hotels&quot;)
        /// {
        ///     Fields =
        ///     {
        ///         new SimpleField(&quot;hotelId&quot;, SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        ///         new SearchableField(&quot;hotelName&quot;) { IsFilterable = true, IsSortable = true },
        ///         new SearchableField(&quot;description&quot;) { AnalyzerName = LexicalAnalyzerName.EnLucene },
        ///         new SearchableField(&quot;tags&quot;, collection: true) { IsFilterable = true, IsFacetable = true },
        ///         new ComplexField(&quot;address&quot;)
        ///         {
        ///             Fields =
        ///             {
        ///                 new SearchableField(&quot;streetAddress&quot;),
        ///                 new SearchableField(&quot;city&quot;) { IsFilterable = true, IsSortable = true, IsFacetable = true },
        ///                 new SearchableField(&quot;stateProvince&quot;) { IsFilterable = true, IsSortable = true, IsFacetable = true },
        ///                 new SearchableField(&quot;country&quot;) { IsFilterable = true, IsSortable = true, IsFacetable = true },
        ///                 new SearchableField(&quot;postalCode&quot;) { IsFilterable = true, IsSortable = true, IsFacetable = true }
        ///             }
        ///         }
        ///     },
        ///     Suggesters =
        ///     {
        ///         // Suggest query terms from the hotelName field.
        ///         new SearchSuggester(&quot;sg&quot;, &quot;hotelName&quot;)
        ///     }
        /// };
        /// </code>
        /// </example>
        public IList<SearchField> Fields
        {
            get => _fields;
            set
            {
                _fields = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Fields)} cannot be null. To clear values, call {nameof(Fields.Clear)}.");
            }
        }

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
