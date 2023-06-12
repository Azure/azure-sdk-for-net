// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary> The query parameters for vector and hybrid search queries. </summary>
    public partial class SearchQueryVector
    {
        /// <summary> The vector representation of a search query. </summary>
        public IReadOnlyList<float> Value { get; set; }
    }
}
