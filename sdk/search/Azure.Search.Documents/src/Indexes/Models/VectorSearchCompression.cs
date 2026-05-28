// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchCompression
    {
        /// <summary> The name to associate with this particular configuration. </summary>
        public string CompressionName { get; }
    }
}
