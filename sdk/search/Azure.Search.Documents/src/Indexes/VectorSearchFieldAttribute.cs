// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Attributes a vector field using a collection of single type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class VectorSearchFieldAttribute : Attribute, ISearchFieldAttribute
    {
        /// <summary>
        /// The dimensionality of the vector field.
        /// </summary>
        public int VectorSearchDimensions { get; set; } = 0;

        /// <summary>
        /// The name of the vector search algorithm configuration that specifies the algorithm and optional parameters for searching the vector field.
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

            if (VectorSearchDimensions != 0)
            {
                field.VectorSearchDimensions = VectorSearchDimensions;
            }

            if (VectorSearchProfileName != null)
            {
                field.VectorSearchProfileName = VectorSearchProfileName;
            }
        }
    }
}
