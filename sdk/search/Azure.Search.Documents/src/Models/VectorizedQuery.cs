// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Models
{
    /// <summary> The query parameters to use for vector search when a raw vector value is provided. </summary>
    public partial class VectorizedQuery : VectorQuery
    {
        /// <summary> The vector representation of a search query. </summary>
        public ReadOnlyMemory<float> Vector { get; }
    }
}
