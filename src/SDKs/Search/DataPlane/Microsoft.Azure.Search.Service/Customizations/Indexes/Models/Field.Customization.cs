// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    public partial class Field
    {
        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="dataType">The data type of the field.</param>
        public Field(string name, DataType dataType) : this()
        {
            Name = name;
            Type = dataType;
        }

        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <remarks>The new field will automatically be searchable and of type Edm.String.</remarks>
        public Field(string name, AnalyzerName analyzerName)
            : this(name, DataType.String, analyzerName)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="dataType">The data type of the field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <remarks>The new field will automatically be searchable.</remarks>
        public Field(string name, DataType dataType, AnalyzerName analyzerName)
            : this(name, dataType)
        {
            Analyzer = analyzerName;
            IsSearchable = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field uniquely
        /// identifies documents in the index. Exactly one field in each index
        /// must be chosen as the key field and it must be of type Edm.String.
        /// Key fields can be used to look up documents directly and update or
        /// delete specific documents. Default is false.
        /// </summary>
        [JsonIgnore]
        public bool? IsKey
        {
            get => Key;
            set => Key = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be returned
        /// in a search result. This is useful when you want to use a field
        /// (for example, margin) as a filter, sorting, or scoring mechanism
        /// but do not want the field to be visible to the end user. This
        /// property must be true for key fields. This property can be changed
        /// on existing fields. Enabling this property does not cause any
        /// increase in index storage requirements. All fields are retrievable
        /// by default.
        /// </summary>
        [JsonIgnore]
        public bool? IsRetrievable
        {
            get => Retrievable;
            set => Retrievable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field is full-text
        /// search-able. This means it will undergo analysis such as
        /// word-breaking during indexing. If you set a searchable field to a
        /// value like "sunny day", internally it will be split into the
        /// individual tokens "sunny" and "day". This enables full-text
        /// searches for these terms. This option may only be enabled for fields of
        /// type Edm.String or Collection(Edm.String). Default is false.
        /// Note: searchable fields consume extra space in your index since Azure
        /// Search will store an additional tokenized version of the field value
        /// for full-text searches. If you want to save space in your index and you
        /// don't need a field to be included in searches, set searchable to false.
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
        /// Fields of any data type can be filterable. Default is false.
        /// </summary>
        [JsonIgnore]
        public bool? IsFilterable
        {
            get => Filterable;
            set => Filterable = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the field to be
        /// referenced in $orderby expressions. By default Azure Search sorts
        /// results by score, but in many experiences users will want to sort
        /// by fields in the documents. Fields of type Collection(Edm.String)
        /// cannot be sortable. Default is false.
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
        /// price, and so on). This option cannot be used with fields of type
        /// Edm.GeographyPoint. Default is false.
        /// </summary>
        [JsonIgnore]
        public bool? IsFacetable
        {
            get => Facetable;
            set => Facetable = value;
        }

        partial void CustomInit()
        {
            // Set all defaults per their SDK-documented values, which differ from the REST API defaults.
            // This is for backwards compatibility with all prior versions of the Azure Search .NET SDK.
            IsKey = false;
            IsRetrievable = true;
            IsSearchable = false;
            IsFilterable = false;
            IsSortable = false;
            IsFacetable = false;
        }
    }
}
