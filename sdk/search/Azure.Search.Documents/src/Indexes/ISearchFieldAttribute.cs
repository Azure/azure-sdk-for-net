// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Represents an attribute that creates a <see cref="SearchField"/>.
    /// </summary>
    internal interface ISearchFieldAttribute
    {
        /// <summary>
        /// Creates a <see cref="SearchField"/> from the implementing attribute.
        /// </summary>
        /// <param name="name">The name of the attributed field or property.</param>
        /// <returns>A <see cref="SearchField"/> created from the implementing attribute.</returns>
        SearchField CreateField(string name);
    }
}
