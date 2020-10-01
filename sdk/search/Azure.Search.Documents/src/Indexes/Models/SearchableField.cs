// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// A <see cref="SearchFieldDataType.String"/> or "Collection(String)" field that can be searched.
    /// </summary>
    public class SearchableField : SimpleField
    {
        private readonly List<string> _synonymMapNames;

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
            _synonymMapNames = new List<string>();
        }

        /// <summary>
        /// Gets or sets the name of the language analyzer. This property cannot be set when either <see cref="SearchAnalyzerName"/> or <see cref="IndexAnalyzerName"/> are set.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? AnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for searching. This property must be set together with <see cref="IndexAnalyzerName"/>, and cannot be set when <see cref="AnalyzerName"/> is set.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? SearchAnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for indexing. This property must be set together with <see cref="SearchAnalyzerName"/>, and cannot be set when <see cref="AnalyzerName"/> is set.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        public LexicalAnalyzerName? IndexAnalyzerName { get; set; }

        /// <summary>
        /// Gets a list of names of synonym maps to associate with this field.
        /// Currently, only one synonym map per field is supported.
        /// </summary>
        /// <remarks>
        /// Assigning a synonym map to a field ensures that query terms targeting that field are expanded at query-time using the rules in the synonym map.
        /// This attribute can be changed on existing fields.
        /// </remarks>
        public IList<string> SynonymMapNames
        {
            get => _synonymMapNames;
            internal set
            {
                _synonymMapNames.Clear();

                if (value != null)
                {
                    _synonymMapNames.AddRange(value);
                }
            }
        }

        /// <inheritdoc/>
        private protected override void Save(SearchField field)
        {
            base.Save(field);

            field.IsSearchable = true;
            field.AnalyzerName = AnalyzerName;
            field.SearchAnalyzerName = SearchAnalyzerName;
            field.IndexAnalyzerName = IndexAnalyzerName;

            if (SynonymMapNames.Count > 0)
            {
                IList<string> fields = field.SynonymMapNames;
                foreach (string name in SynonymMapNames)
                {
                    fields.Add(name);
                }
            }
        }
    }
}
