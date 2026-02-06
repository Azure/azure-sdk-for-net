// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
    }
}
