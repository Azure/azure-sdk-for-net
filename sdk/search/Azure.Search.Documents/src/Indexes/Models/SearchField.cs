// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// <para>
    /// Represents a field in an index definition, which describes the name, data type, and search behavior of a field.
    /// </para>
    /// <para>
    /// When creating an index, instead use the <see cref="SimpleField"/>, <see cref="SearchableField"/>, and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
    /// </para>
    /// </summary>
    public partial class SearchField
    {
        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="type">The data type of the field.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SearchField(string name, SearchFieldDataType type)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
            Type = type;

            Fields = new ChangeTrackingList<SearchField>();
            SynonymMapNames = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Ge the data type of the field.
        /// </summary>
        public SearchFieldDataType Type { get; }

        // TODO: Remove "overrides" for boolean properties when https://github.com/Azure/autorest.csharp/issues/558 is fixed.

        /// <summary>
        /// Gets or sets a value indicating whether the field is full-text searchable. The default is null.
        /// This means it will undergo analysis such as word-breaking during indexing.
        /// This property can be true only for <see cref="SearchFieldDataType.String"/>, "Collection(DataType.String)" or "Collection(DataType.Single)". It must be false for non-string simple fields, and null for complex fields.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Full-text searches enable the field value "sunny day" to be split into individual terms "sunny" and "day". This will increase the size of your index.
        /// </para>
        /// <para>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </para>
        /// </remarks>
        [CodeGenMember("Searchable")]
        public bool? IsSearchable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be referenced in <c>$filter</c> queries. The default is null.
        /// This property must be null for complex fields, but can be set on simple fields within a complex field.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Filterable differs from searchable in how strings are handled. Fields of type <see cref="SearchFieldDataType.String"/> or "Collection(DataType.String)" that are filterable do not undergo word-breaking, so comparisons are for exact matches only.
        /// For example, if you set such a field <c>f</c> to "sunny day", <c>$filter=f eq 'sunny'</c> will find no matches, but <c>$filter=f eq 'sunny day'</c> will.
        /// </para>
        /// <para>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </para>
        /// </remarks>
        [CodeGenMember("Filterable")]
        public bool? IsFilterable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field will be returned in a search result. The default is null.
        /// This property must be true for key fields, and must be null for complex fields.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can hide a field from search results if you want to use it only as a filter, for sorting, or for scoring.
        /// This property can also be changed on existing fields and enabling it does not cause an increase in index storage requirements.
        /// </para>
        /// <para>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </para>
        /// </remarks>
        public bool? IsHidden
        {
            get => IsRetrievable.HasValue ? !IsRetrievable : null;
            set => IsRetrievable = value.HasValue ? !value : null;
        }

        [CodeGenMember("Retrievable")]
        private bool? IsRetrievable { get; set; }

        /// <summary>
        /// An immutable value indicating whether the field will be persisted separately on disk to be returned in a search result.
        /// You can disable this option if you don't plan to return the field contents in a search response to save on storage overhead.
        /// This can only be set during index creation and only for vector fields. This property cannot be changed for existing fields or set as false for new fields.
        /// If this property is set as false, the property 'retrievable' must also be set to false. This property must be true or unset for key fields, for new fields, and for non-vector fields,
        /// and it must be null for complex fields. Disabling this property will reduce index storage requirements. The default is true for vector fields.
        /// </summary>
        [CodeGenMember("Stored")]
        public bool? IsStored { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be referenced in a <c>$orderby</c> expression. The default is null.
        /// A simple field can be sortable only if it is a single-valued type such as <see cref="SearchFieldDataType.String"/> or <see cref="SearchFieldDataType.Int32"/>.
        /// </summary>
        /// <remarks>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </remarks>
        [CodeGenMember("Sortable")]
        public bool? IsSortable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be retrieved in facet queries. The default is null.
        /// This property must be null for complex fields, but can be set on simple fields within a complex field.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Facets are used in presentation of search results that include hit counts by categories.
        /// For example, in a search for digital cameras, facets might include branch, megapixels, price, etc.
        /// </para>
        /// <para>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </para>
        /// </remarks>
        [CodeGenMember("Facetable")]
        public bool? IsFacetable { get; set; }

        /// <summary>
        /// Gets or sets whether the field is the key field. The default is null.
        /// A <see cref="SearchIndex"/> must have exactly one key field of type <see cref="SearchFieldDataType.String"/>.
        /// </summary>
        /// <remarks>
        /// This field must be set according to constraints described in the summary, or the server may respond with an error.
        /// Instead, consider using the <see cref="SimpleField"/>, <see cref="SearchableField"/>, <see cref="VectorSearchField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
        /// </remarks>
        [CodeGenMember("Key")]
        public bool? IsKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the analyzer to use for the field.
        /// This option can be used only with searchable fields and it cannot be set together with either <see cref="SearchAnalyzerName"/> or <see cref="IndexAnalyzerName"/>.
        /// Once the analyzer is chosen, it cannot be changed for the field.
        /// Must be null for complex fields.
        /// </summary>
        [CodeGenMember("Analyzer")]
        public LexicalAnalyzerName? AnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the analyzer used at search time for the field.
        /// This option can be used only with searchable fields.
        /// It must be set together with <see cref="IndexAnalyzerName"/> and it cannot be set together with the <see cref="AnalyzerName"/> option.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// This analyzer can be updated on an existing field.
        /// Must be null for complex fields.
        /// </summary>
        [CodeGenMember("SearchAnalyzer")]
        public LexicalAnalyzerName? SearchAnalyzerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the analyzer used at indexing time for the field.
        /// This option can be used only with searchable fields.
        /// It must be set together with <see cref="SearchAnalyzerName"/> and it cannot be set together with the <see cref="AnalyzerName"/> option.
        /// This property cannot be set to the name of a language analyzer; use the <see cref="AnalyzerName"/> property instead if you need a language analyzer.
        /// Once the analyzer is chosen, it cannot be changed for the field.
        /// Must be null for complex fields. </summary>
        [CodeGenMember("IndexAnalyzer")]
        public LexicalAnalyzerName? IndexAnalyzerName { get; set; }

        // TODO: Remove "overrides" for collection properties when https://github.com/Azure/autorest.csharp/issues/521 is fixed.

        /// <summary>
        /// Gets a list of names of synonym maps associated with this field. Only fields where <see cref="IsSearchable"/> is true can have associated synonym maps.
        /// </summary>
        [CodeGenMember("SynonymMaps")]
        public IList<string> SynonymMapNames { get; }

        /// <summary>
        /// Gets a list of nested fields if this field is of type <see cref="SearchFieldDataType.Complex"/> or "Collection(DataType.Complex)".
        /// </summary>
        [CodeGenMember("Fields")]
        public IList<SearchField> Fields { get; }

        /// <inheritdoc/>
        /// <remarks>
        /// This always returns "<see cref="Name"/> : <see cref="Type"/>" and is meant for debugging purposes.
        /// </remarks>
        public override string ToString() => $"{Name} : {Type}";
    }
}
