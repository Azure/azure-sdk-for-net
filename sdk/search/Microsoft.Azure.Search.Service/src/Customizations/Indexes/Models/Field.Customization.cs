// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using Microsoft.Azure.Search.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    public partial class Field
    {
        /// <summary>
        /// Initializes a new simple Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the simple field.</param>
        /// <param name="dataType">The data type of the simple field. Cannot be a complex type.</param>
        /// <exception cref="System.ArgumentException">Thrown if <c>dataType</c> is a complex type.</exception>
        public Field(string name, DataType dataType) : this()
        {
            Throw.IfArgument(dataType.IsComplex(), nameof(dataType), "Cannot create a simple field of a complex type.");

            Name = name;
            Type = dataType;

            // Set all defaults per their SDK-documented values, which differ from the REST API defaults.
            // This is for backwards compatibility with all prior versions of the Azure Cognitive Search .NET SDK.
            IsKey = false;
            IsRetrievable = true;
            IsSearchable = false;
            IsFilterable = false;
            IsSortable = false;
            IsFacetable = false;
        }

        /// <summary>
        /// Initializes a new searchable string Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the string field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the simple field.</param>
        /// <remarks>The new field will automatically be searchable and of type Edm.String.</remarks>
        public Field(string name, AnalyzerName analyzerName)
            : this(name, DataType.String, analyzerName)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new searchable simple Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the simple field.</param>
        /// <param name="dataType">The data type of the field. Cannot be a complex type.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <exception cref="System.ArgumentException">Thrown if <c>dataType</c> is a complex type.</exception>
        /// <remarks>The new field will automatically be searchable.</remarks>
        public Field(string name, DataType dataType, AnalyzerName analyzerName)
            : this(name, dataType)
        {
            Analyzer = analyzerName;
            IsSearchable = true;
        }

        /// <summary>
        /// Initializes a new complex Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the complex field.</param>
        /// <param name="dataType">The data type of the field. Must be a complex type.</param>
        /// <param name="fields">The sub-fields that comprise the complex type. They can be simple or complex fields themselves.</param>
        /// <exception cref="System.ArgumentException">Thrown if <c>dataType</c> is not a complex type.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>fields</c> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>fields</c> is empty.</exception>
        public Field(string name, DataType dataType, IList<Field> fields) : this()
        {
            Throw.IfArgument(!dataType.IsComplex(), nameof(dataType), "Cannot create a complex field of a non-complex type.");
            Throw.IfArgumentNull(fields, nameof(fields));
            Throw.IfArgumentOutOfRange(fields.Count < 1, nameof(fields), "Cannot create a complex field without sub-fields.");

            Name = name;
            Type = dataType;
            Fields = fields;
        }

        /// <summary>
        /// Creates a new simple Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the simple field.</param>
        /// <param name="dataType">The data type of the simple field. Cannot be a complex type.</param>
        /// <param name="isKey">A value indicating whether the field uniquely
        /// identifies documents in the index. Default is false.</param>
        /// <param name="isRetrievable">A value indicating whether the field can
        /// be returned in a search result. Default is true.</param>
        /// <param name="isSearchable">A value indicating whether the field is
        /// full-text search-able. Default is false.</param>
        /// <param name="isFilterable">A value indicating whether to enable the
        /// field to be referenced in $filter queries. Default is false.</param>
        /// <param name="isSortable">A value indicating whether to enable the
        /// field to be referenced in $orderby expressions. Default is false.</param>
        /// <param name="isFacetable">A value indicating whether to enable the
        /// field to be referenced in facet queries. Default is false.</param>
        /// <param name="analyzerName">The name of the language analyzer to use for
        /// the field. Default is null.</param>
        /// <param name="searchAnalyzerName">The name of the analyzer used at
        /// search time for the field. Default is null.</param>
        /// <param name="indexAnalyzerName">The name of the analyzer used at
        /// indexing time for the field. Default is null.</param>
        /// <param name="synonymMaps">A list of synonym map names that
        /// associates synonym maps with the field. Default is null.</param>
        /// <exception cref="System.ArgumentException">Thrown if <c>dataType</c> is a complex type.</exception>
        public static Field New(
            string name,
            DataType dataType,
            bool isKey = false,
            bool isRetrievable = true,
            bool isSearchable = false,
            bool isFilterable = false,
            bool isSortable = false,
            bool isFacetable = false,
            AnalyzerName? analyzerName = null,
            AnalyzerName? searchAnalyzerName = null,
            AnalyzerName? indexAnalyzerName = null,
            IList<string> synonymMaps = null) =>
            new Field(name, dataType)
            {
                IsKey = isKey,
                IsRetrievable = isRetrievable,
                IsSearchable = isSearchable,
                IsFilterable = isFilterable,
                IsSortable = isSortable,
                IsFacetable = isFacetable,
                Analyzer = analyzerName,
                SearchAnalyzer = searchAnalyzerName,
                IndexAnalyzer = indexAnalyzerName,
                SynonymMaps = synonymMaps
            };

        /// <summary>
        /// Creates a new searchable string Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the string field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the simple field.</param>
        /// <param name="isKey">A value indicating whether the field uniquely
        /// identifies documents in the index. Default is false.</param>
        /// <param name="isRetrievable">A value indicating whether the field can
        /// be returned in a search result. Default is true.</param>
        /// <param name="isFilterable">A value indicating whether to enable the
        /// field to be referenced in $filter queries. Default is false.</param>
        /// <param name="isSortable">A value indicating whether to enable the
        /// field to be referenced in $orderby expressions. Default is false.</param>
        /// <param name="isFacetable">A value indicating whether to enable the
        /// field to be referenced in facet queries. Default is false.</param>
        /// <param name="synonymMaps">A list of synonym map names that
        /// associates synonym maps with the field. Default is null.</param>
        /// <remarks>The new field will automatically be searchable and of type Edm.String.</remarks>
        public static Field NewSearchableString(
            string name,
            AnalyzerName analyzerName,
            bool isKey = false,
            bool isRetrievable = true,
            bool isFilterable = false,
            bool isSortable = false,
            bool isFacetable = false,
            IList<string> synonymMaps = null) =>
            new Field(name, analyzerName)
            {
                IsKey = isKey,
                IsRetrievable = isRetrievable,
                IsFilterable = isFilterable,
                IsSortable = isSortable,
                IsFacetable = isFacetable,
                SynonymMaps = synonymMaps
            };

        /// <summary>
        /// Creates a new searchable string collection Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the simple field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <param name="isKey">A value indicating whether the field uniquely
        /// identifies documents in the index. Default is false.</param>
        /// <param name="isRetrievable">A value indicating whether the field can
        /// be returned in a search result. Default is true.</param>
        /// <param name="isFilterable">A value indicating whether to enable the
        /// field to be referenced in $filter queries. Default is false.</param>
        /// <param name="isFacetable">A value indicating whether to enable the
        /// field to be referenced in facet queries. Default is false.</param>
        /// <param name="synonymMaps">A list of synonym map names that
        /// associates synonym maps with the field. Default is null.</param>
        /// <remarks>The new field will automatically be searchable and of type Collection(Edm.String).</remarks>
        public static Field NewSearchableCollection(
            string name,
            AnalyzerName analyzerName,
            bool isKey = false,
            bool isRetrievable = true,
            bool isFilterable = false,
            bool isFacetable = false,
            IList<string> synonymMaps = null) =>
            new Field(name, DataType.Collection(DataType.String), analyzerName)
            {
                IsKey = isKey,
                IsRetrievable = isRetrievable,
                IsFilterable = isFilterable,
                IsFacetable = isFacetable,
                SynonymMaps = synonymMaps
            };

        /// <summary>
        /// Creates a new complex Field with required arguments.
        /// </summary>
        /// <param name="name">The name of the complex field.</param>
        /// <param name="isCollection"><c>true</c> if the field should be of type Collection(Edm.ComplexType); <c>false</c> if it should be
        /// of type Edm.ComplexType.</param>
        /// <param name="fields">The sub-fields that comprise the complex type. They can be simple or complex fields themselves.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <c>fields</c> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <c>fields</c> is empty.</exception>
        public static Field NewComplex(string name, bool isCollection, IList<Field> fields) =>
            new Field(name, isCollection ? DataType.Collection(DataType.Complex) : DataType.Complex, fields);

        // MAINTENANCE NOTE: The properties below exist for two reasons:
        // 1. So that the public documentation for them accurately describes their default values, which are different for the .NET SDK.
        // 2. So that we can use more .NET-friendly names. We could have used x-ms-client-name in the Swagger spec to rename the generated
        //    properties, but the result might not be idiomatic in all other target languages.

        /// <summary>
        /// Gets or sets a value indicating whether the field uniquely
        /// identifies documents in the index. Exactly one top-level field in
        /// each index must be chosen as the key field and it must be of type
        /// Edm.String. Key fields can be used to look up documents directly
        /// and update or delete specific documents. Default is false for
        /// simple fields and null for complex fields.
        /// </summary>
        [JsonIgnore]
        public bool? IsKey
        {
            get => Key;
            set => Key = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be returned
        /// in a search result. You can disable this option if you want to use
        /// a field (for example, margin) as a filter, sorting, or scoring
        /// mechanism but do not want the field to be visible to the end user.
        /// This property must be true for key fields, and it must be null for
        /// complex fields. This property can be changed on existing fields.
        /// Enabling this property does not cause any increase in index storage
        /// requirements. Default is true for simple fields and null for
        /// complex fields.
        /// </summary>
        [JsonIgnore]
        public bool? IsRetrievable
        {
            get => Retrievable;
            set => Retrievable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field is full-text
        /// searchable. This means it will undergo analysis such as
        /// word-breaking during indexing. If you set a searchable field to a
        /// value like "sunny day", internally it will be split into the
        /// individual tokens "sunny" and "day". This enables full-text
        /// searches for these terms. This property may be set to true only for
        /// fields of type Edm.String or Collection(Edm.String), and it must be
        /// null for complex fields. Default is false for simple fields and null for
        /// complex fields. Note: searchable fields consume extra space in your
        /// index since Azure Cognitive Search will store an additional tokenized version
        /// of the field value for full-text searches. If you want to save space
        /// in your index and you don't need a field to be included in searches,
        /// set searchable to false.
        /// </summary>
        [JsonIgnore]
        public bool? IsSearchable
        {
            get => Searchable;
            set => Searchable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the field to be
        /// referenced in $filter queries. filterable differs from searchable
        /// in how strings are handled. Fields of type Edm.String or
        /// Collection(Edm.String) that are filterable do not undergo
        /// word-breaking, so comparisons are for exact matches only. For
        /// example, if you set such a field f to "sunny day", $filter=f eq
        /// 'sunny' will find no matches, but $filter=f eq 'sunny day' will.
        /// This property must be null for complex fields. Default is false for
        /// simple fields and null for complex fields.
        /// </summary>
        [JsonIgnore]
        public bool? IsFilterable
        {
            get => Filterable;
            set => Filterable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the field to be
        /// referenced in $orderby expressions. By default Azure Cognitive Search sorts
        /// results by score, but in many experiences users will want to sort
        /// by fields in the documents. A simple field can be sortable only if
        /// it is single-valued (it has a single value in the scope of the
        /// parent document). Simple collection fields cannot be sortable,
        /// since they are multi-valued. Simple sub-fields of complex
        /// collections are also multi-valued, and therefore cannot be
        /// sortable. This is true whether it's an immediate parent field, or
        /// an ancestor field, that's the complex collection. Complex fields
        /// cannot be sortable and the sortable property must be null for such
        /// fields. The default for sortable is false for simple fields, and
        /// null for complex fields.
        /// </summary>
        [JsonIgnore]
        public bool? IsSortable
        {
            get => Sortable;
            set => Sortable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the field to be
        /// referenced in facet queries. Typically used in a presentation of
        /// search results that includes hit count by category (for example,
        /// search for digital cameras and see hits by brand, by megapixels, by
        /// price, and so on). This property must be null for complex fields.
        /// Fields of type Edm.GeographyPoint or Collection(Edm.GeographyPoint)
        /// cannot be facetable. All other simple fields can be facetable.
        /// Default is false for simple fields, and null for complex fields.
        /// </summary>
        [JsonIgnore]
        public bool? IsFacetable
        {
            get => Facetable;
            set => Facetable = value;
        }
    }
}
