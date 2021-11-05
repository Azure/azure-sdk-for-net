// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Attributes a simple field using a primitive type or a collection of a primitive type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SearchableFieldAttribute : SimpleFieldAttribute, ISearchFieldAttribute
    {
        /// <summary>
        /// Gets or sets the name of the language analyzer. This property cannot be set when either <see cref="SearchAnalyzerName"/> or <see cref="IndexAnalyzerName"/> are set.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        /// <value>String values from <see cref="LexicalAnalyzerName.Values">LexicalAnalyzerName</see>, or the name of a custom analyzer previously uploaded.</value>
        public string AnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for searching. This property must be set together with <see cref="IndexAnalyzerName"/>, and cannot be set when <see cref="AnalyzerName"/> is set.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        /// <value>String values from <see cref="LexicalAnalyzerName.Values">LexicalAnalyzerName</see>, or the name of a custom analyzer previously uploaded.</value>
        public string SearchAnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the language analyzer for indexing. This property must be set together with <see cref="SearchAnalyzerName"/>, and cannot be set when <see cref="AnalyzerName"/> is set.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// Once the analyzer is chosen, it cannot be changed for the field in the index.
        /// </summary>
        /// <value>String values from <see cref="LexicalAnalyzerName.Values">LexicalAnalyzerName</see>, or the name of a custom analyzer previously uploaded.</value>
        public string IndexAnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets a list of names of synonym maps to associate with this field.
        /// Currently, only one synonym map per field is supported.
        /// </summary>
        /// <remarks>
        /// Assigning a synonym map to a field ensures that query terms targeting that field are expanded at query-time using the rules in the synonym map.
        /// This attribute can be changed on existing fields.
        /// </remarks>
        public string[] SynonymMapNames { get; set; }

        /// <inheritdoc/>
        void ISearchFieldAttribute.SetField(SearchField field)
        {
            SetField(field);

            field.IsSearchable = true;

            if (SynonymMapNames != null)
            {
                field.SynonymMapNames.Clear();
                for (int i = 0; i < SynonymMapNames.Length; ++i)
                {
                    field.SynonymMapNames.Add(SynonymMapNames[i]);
                }
            }

            if (AnalyzerName != null)
            {
                field.AnalyzerName = AnalyzerName;
            }

            if (SearchAnalyzerName != null)
            {
                field.SearchAnalyzerName = SearchAnalyzerName;
            }

            if (IndexAnalyzerName != null)
            {
                field.IndexAnalyzerName = IndexAnalyzerName;
            }
        }
    }
}
