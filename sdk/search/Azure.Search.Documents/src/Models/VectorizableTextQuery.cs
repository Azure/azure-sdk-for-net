// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Models
{
    public partial class VectorizableTextQuery : VectorQuery
    {
        /// <summary> The text to be vectorized to perform a vector search query. </summary>
        public string Text { get; }
    }
}
