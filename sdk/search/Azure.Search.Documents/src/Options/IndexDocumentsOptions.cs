// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options for <see cref="SearchClient.IndexDocumentsAsync{T}(Models.IndexDocumentsBatch{T}, IndexDocumentsOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class IndexDocumentsOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether to throw an exception on
        /// any individual failure in the batch of document write operations.
        /// Set this to true if you're not inspecting the results of the Index
        /// Documents action.
        /// </summary>
        public bool ThrowOnAnyError { get; set; }
    }
}
