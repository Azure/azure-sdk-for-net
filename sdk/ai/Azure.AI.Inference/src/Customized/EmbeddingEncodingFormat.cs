// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.Inference
{
    /// <summary>
    /// The format of the embeddings result.
    /// Returns a 422 error if the model doesn't support the value or parameter.
    /// </summary>
    public readonly partial struct EmbeddingEncodingFormat : IEquatable<EmbeddingEncodingFormat>
    {
        /// <summary> Floating point. </summary>
        [CodeGenMember("Float")]
        public static EmbeddingEncodingFormat Single { get; } = new EmbeddingEncodingFormat(SingleValue);
        /// <summary> Signed 8-bit integer. </summary>
        [CodeGenMember("Int8")]
        public static EmbeddingEncodingFormat SByte { get; } = new EmbeddingEncodingFormat(SByteValue);
        /// <summary> Unsigned 8-bit integer. </summary>
        [CodeGenMember("Uint8")]
        public static EmbeddingEncodingFormat Byte { get; } = new EmbeddingEncodingFormat(ByteValue);
    }
}
