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
        /// Sets properties on the given <see cref="SearchField"/> based on attributes' properties that are set.
        /// </summary>
        /// <param name="field">The <see cref="SearchField"/> to update.</param>
        void SetField(SearchField field);
    }
}
