// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// A searchable vector field of type "Collection(<see cref="SearchFieldDataType.Single"/>)".
    /// </summary>
    public class VectorSearchField : SearchFieldTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="vectorSearchDimensions">The dimensionality of the vector field.</param>
        /// <param name="vectorSearchProfileName">The name of the vector search profile that specifies the algorithm to use when searching the vector field.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public VectorSearchField(string name, int vectorSearchDimensions, string vectorSearchProfileName) : base(name, SearchFieldDataType.Collection(SearchFieldDataType.Single))
        {
            VectorSearchDimensions = vectorSearchDimensions;
            VectorSearchProfileName = vectorSearchProfileName;
        }

        /// <summary> The dimensionality of the vector field. </summary>
        public int VectorSearchDimensions { get; set; }

        /// <summary> The name of the vector search profile that specifies the algorithm to use when searching the vector field. </summary>
        public string VectorSearchProfileName { get; set; }

        /// <summary> An immutable value indicating whether the field will be persisted separately on disk to be returned in a search result. You can disable this option if you don't plan to return the field contents in a search response to save on storage overhead. This can only be set during index creation and only for vector fields. This property cannot be changed for existing fields or set as false for new fields. If this property is set as false, the property 'retrievable' must also be set to false. This property must be true or unset for key fields, for new fields, and for non-vector fields, and it must be null for complex fields. Disabling this property will reduce index storage requirements. The default is true for vector fields. </summary>
        public bool? IsStored { get; set; }

        /// <summary>
        /// Gets or sets whether the field is returned in search results. The default is false.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <inheritdoc/>
        private protected override void Save(SearchField field)
        {
            // Vector fields are required to be searchable
            field.IsSearchable = true;
            field.IsHidden = IsHidden;
            field.VectorSearchDimensions = VectorSearchDimensions;
            field.VectorSearchProfileName = VectorSearchProfileName;
            field.IsStored = IsStored;
        }
    }
}
