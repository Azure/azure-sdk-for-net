// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchCompression
    {
        /// <summary> Initializes a new instance of <see cref="VectorSearchCompression"/>. </summary>
        /// <param name="compressionName"> The name to associate with this particular configuration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="compressionName"/> is null. </exception>
        protected VectorSearchCompression(string compressionName)
        {
            Argument.AssertNotNull(compressionName, nameof(compressionName));

            CompressionName = compressionName;
        }

        /// <summary> The name to associate with this particular configuration. </summary>
        public string CompressionName { get; }

        /// <summary> Deprecated. If set to true, once the ordered set of results calculated using compressed vectors are obtained, they will be reranked again by recalculating the full-precision similarity scores. This will improve recall at the expense of latency. </summary>
        [Obsolete("This property is deprecated. Use RescoringOptions instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? RerankWithOriginalVectors { get; set; }

        /// <summary> Deprecated. Default oversampling factor. Oversampling will internally request more documents (specified by this multiplier) in the initial search. This increases the set of results that will be reranked using recomputed similarity scores from full-precision vectors. Minimum value is 1, meaning no oversampling (1x). This parameter can only be set when rerankWithOriginalVectors is true. Higher values improve recall at the expense of latency. </summary>
        [Obsolete("This property is deprecated. Use RescoringOptions instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double? DefaultOversampling { get; set; }
    }
}
