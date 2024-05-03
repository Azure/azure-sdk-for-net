// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> The encoding format for interpreting vector field contents. </summary>
    public readonly partial struct VectorEncodingFormat
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary>
        /// The values of all declared <see cref="VectorEncodingFormat"/> properties as string constants.
        /// These can be used in <see cref="VectorSearchFieldAttribute"/> and anywhere else constants are required.
        /// </summary>
        public static class Values
        {
            /// <summary> Encoding format representing bits packed into a wider data type. </summary>
            public const string PackedBit = VectorEncodingFormat.PackedBitValue;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
