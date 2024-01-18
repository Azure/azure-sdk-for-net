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
        }
    }
}
