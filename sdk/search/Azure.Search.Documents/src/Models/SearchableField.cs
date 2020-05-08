// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// A <see cref="SearchFieldDataType.String"/> or "Collection(String)" field that can be searched.
    /// </summary>
    public class SearchableField : SimpleField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchableField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="collection">Whether the field is a collection of strings.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SearchableField(string name, bool collection = false) : base(name, collection ? SearchFieldDataType.Collection(SearchFieldDataType.String) : SearchFieldDataType.String)
        {
            // NOTE: Types other than string may be searchable one day. Could add an overload in the future.
        }

        /// <summary>
        /// Gets or sets the name of the language analyzer. This property cannot be set when either <see cref="SearchAnalyzer"/> or <see cref="IndexAnalyzer"/> are set.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? Analyzer { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for searching. This property must be set together with <see cref="IndexAnalyzer"/>, and cannot be set when <see cref="Analyzer"/> is set.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? SearchAnalyzer { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for indexing. This property must be set together with <see cref="SearchAnalyzer"/>, and cannot be set when <see cref="Analyzer"/> is set.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? IndexAnalyzer { get; set; }

        /// <summary>
        /// Gets a list of names of synonym maps to associate with this field.
        /// Currently, only one synonym map per field is supported.
        /// </summary>
        /// <remarks>
        /// Assigning a synonym map to a field ensures that query terms targeting that field are expanded at query-time using the rules in the synonym map.
        /// This attribute can be changed on existing fields.
        /// </remarks>
        public IList<string> SynonymMaps { get; } = new List<string>();

        /// <inheritdoc/>
        private protected override void Save(SearchField field)
        {
            base.Save(field);

            field.IsSearchable = true;
            field.Analyzer = Analyzer;
            field.SearchAnalyzer = SearchAnalyzer;
            field.IndexAnalyzer = IndexAnalyzer;

            if (SynonymMaps.Count > 0)
            {
                field.SynonymMaps = SynonymMaps;
            }
        }
    }
}
