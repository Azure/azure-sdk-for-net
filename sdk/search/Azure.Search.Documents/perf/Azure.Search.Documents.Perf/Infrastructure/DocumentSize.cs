// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Perf.Infrastructure
{
    /// <summary>
    /// Size of documents used to populate the Azure search index.
    /// </summary>
    public enum DocumentSize
    {
        /// <summary>
        /// Relatively small document (smaller than <see cref="Large"/>)
        /// </summary>
        Small,

        /// <summary>
        /// Relatively large document (larger than <see cref="Small"/>)
        /// </summary>
        Large,
    }
}
