// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    public partial class RawVectorQuery : VectorQuery
    {
        /// <summary> The vector representation of a search query. </summary>
        public IReadOnlyList<float> Vector { get; set; }
    }
}
