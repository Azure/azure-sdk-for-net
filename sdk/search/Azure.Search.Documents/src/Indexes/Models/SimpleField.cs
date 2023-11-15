// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// A simple field using a primitive type or a collection of a primitive type.
    /// </summary>
    public class SimpleField : SearchFieldTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="type">The data type of the field.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SimpleField(string name, SearchFieldDataType type) : base(name, type)
        {
        }

        /// <summary>
        /// Gets or sets whether the field is the key field. The default is false.
        /// A <see cref="SearchIndex"/> must have exactly one key field of type <see cref="SearchFieldDataType.String"/>.
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// Gets or sets whether the field is returned in search results. The default is false.
        /// A key field where <see cref="IsKey"/> is true must have this property set to false.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be referenced in <c>$filter</c> queries. The default is false.
        /// </summary>
        /// <remarks>
        /// Filterable differs from searchable in how strings are handled. Fields of type <see cref="SearchFieldDataType.String"/> or "Collection(DataType.String)" that are filterable do not undergo word-breaking, so comparisons are for exact matches only.
        /// For example, if you set such a field <c>f</c> to "sunny day", <c>$filter=f eq 'sunny'</c> will find no matches, but <c>$filter=f eq 'sunny day'</c> will.
        /// </remarks>
        public bool IsFilterable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be retrieved in facet queries. The default is false.
        /// </summary>
        /// <remarks>
        /// Facets are used in presentation of search results that include hit counts by categories.
        /// For example, in a search for digital cameras, facets might include branch, megapixels, price, etc.
        /// </remarks>
        public bool IsFacetable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the field can be referenced in <c>$orderby</c> expressions. The default is false.
        /// </summary>
        /// <remarks>
        /// By default Azure Cognitive Search sorts results by score, but in many experiences users may want to sort by fields in the documents.
        /// </remarks>
        public bool IsSortable { get; set; }

        /// <inheritdoc/>
        private protected override void Save(SearchField field)
        {
            field.IsKey = IsKey;
            field.IsHidden = IsHidden;
            field.IsFilterable = IsFilterable;
            field.IsFacetable = IsFacetable;
            field.IsSortable = IsSortable;

            // Use a SearchableField instead, which will override this property.
            // The service will return Searchable == false for all non-searchable simple types.
            field.IsSearchable = false;
        }
    }
}
