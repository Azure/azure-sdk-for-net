// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchCompression
    {
        /// <summary> Gets the name associated with this particular configuration. </summary>
        public string CompressionName { get; }
    }
}
