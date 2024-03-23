// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Attributes a ReadOnlyMemory&lt;float&gt; vector field, allowing its use with the VectorSearch indexes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class VectorSearchFieldAttribute : Attribute, ISearchFieldAttribute
    {
        /// <summary>
        /// The dimensionality of the vector field.
        /// </summary>
        public int VectorSearchDimensions { get; set; }

        /// <summary>
        /// The <see cref="VectorSearchProfile.Name"/> of the vector search profile configured in the index's <see cref="VectorSearch.Profiles"/> that specifies the algorithm to use when searching the vector field.
        /// </summary>
        public string VectorSearchProfileName { get; set; }

        /// <summary> An immutable value indicating whether the field will be persisted separately on disk to be returned in a search result. You can disable this option if you don't plan to return the field contents in a search response to save on storage overhead. This can only be set during index creation and only for vector fields. This property cannot be changed for existing fields or set as false for new fields. If this property is set as false, the property 'retrievable' must also be set to false. This property must be true or unset for key fields, for new fields, and for non-vector fields, and it must be null for complex fields. Disabling this property will reduce index storage requirements. The default is true for vector fields. </summary>
        public bool IsStored { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the field is returned in search results. The default is false.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <inheritdoc/>
        void ISearchFieldAttribute.SetField(SearchField field) => SetField(field);

        private protected void SetField(SearchField field)
        {
            field.IsSearchable = true;
            field.IsHidden = IsHidden;
            field.VectorSearchDimensions = VectorSearchDimensions;
            field.VectorSearchProfileName = VectorSearchProfileName;
            field.IsStored = IsStored;
        }
    }
}
