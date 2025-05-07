// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchClient.GetDocumentAsync{T}(string, GetDocumentOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class GetDocumentOptions
    {
        /// <summary>
        /// A list of field names to retrieve.  Only fields marked as
        /// retrievable can be included in this clause.  Any field not
        /// retrieved will be missing from the returned document.  If empty,
        /// all fields marked as retrievable in the schema are returned.
        /// </summary>
        public IList<string> SelectedFields { get; internal set; } = new List<string>();

        /// <summary>
        /// Gets the selected fields.  If the collection is null or empty, we
        /// return null.
        /// </summary>
        internal IEnumerable<string> SelectedFieldsOrNull =>
            SelectedFields?.Count > 0 ? SelectedFields : null;
    }
}
