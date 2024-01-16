// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Options for performing Vector Search.
    /// </summary>
    public partial class VectorSearchOptions
    {
        /// <summary> Initializes a new instance of VectorSearchOptions. </summary>
        public VectorSearchOptions()
        {
            Queries = new ChangeTrackingList<VectorQuery>();
        }

        /// <summary> The query parameters for multi-vector search queries. </summary>
        public IList<VectorQuery> Queries { get; internal set; }

        /// <summary> Determines whether or not filters are applied before or after the vector search is performed. Default is <see cref="VectorFilterMode.PreFilter" /> for new indexes. </summary>
        public VectorFilterMode? FilterMode { get; set; }
    }
}
