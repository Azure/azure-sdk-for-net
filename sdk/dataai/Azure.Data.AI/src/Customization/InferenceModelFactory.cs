// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // The generator derives the model factory name from the package name
    // (Azure.Data.AI -> AIModelFactory), which is too generic. Rename it to align
    // with the InferenceClient surface.
    [CodeGenType("AIModelFactory")]
    [CodeGenSuppress("EmbeddingItem", typeof(string), typeof(int), typeof(string))]
    [CodeGenSuppress("EmbeddingUsage", typeof(string), typeof(long?), typeof(long?))]
    public static partial class InferenceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.Data.AI.EmbeddingItem"/>. </summary>
        /// <param name="type"> The discriminator value. </param>
        /// <param name="index"> The index of the embedding. </param>
        /// <param name="id"> The embedding identifier. </param>
        /// <returns> A new <see cref="Azure.Data.AI.EmbeddingItem"/> instance for mocking. </returns>
        public static EmbeddingItem EmbeddingItem(string type = default, int index = default, string id = default)
        {
            return new UnknownEmbeddingData(type == null ? default(EmbeddingDataType) : new EmbeddingDataType(type), index, id, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.Data.AI.EmbeddingUsage"/>. </summary>
        /// <param name="type"> The discriminator value. </param>
        /// <param name="promptTokens"> The number of prompt tokens. </param>
        /// <param name="totalTokens"> The total number of tokens. </param>
        /// <returns> A new <see cref="Azure.Data.AI.EmbeddingUsage"/> instance for mocking. </returns>
        public static EmbeddingUsage EmbeddingUsage(string type = default, long? promptTokens = default, long? totalTokens = default)
        {
            return new UnknownEmbeddingUsage(type == null ? default(EmbeddingUsageType) : new EmbeddingUsageType(type), promptTokens, totalTokens, additionalBinaryDataProperties: null);
        }
    }
}
