// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // The generator derives the model factory name from the package name
    // (Azure.Data.AI -> AIModelFactory), which is too generic. Rename it to align
    // with the InferenceClient surface.
    [CodeGenType("AIModelFactory")]
    [CodeGenSuppress("EmbeddingItem", typeof(string), typeof(int), typeof(string))]
    [CodeGenSuppress("EmbeddingUsage", typeof(string), typeof(long?), typeof(long?))]
    [CodeGenSuppress("EmbeddingResult", typeof(string), typeof(string), typeof(EmbeddingOutputDataKind), typeof(IEnumerable<EmbeddingItem>), typeof(EmbeddingUsage), typeof(IEnumerable<EmbeddingWarning>), typeof(EmbeddingOutput))]
    public static partial class InferenceModelFactory
    {
        /// <summary> The result of an embedding operation. </summary>
        /// <param name="model"> The name of the model that produced the vectors. </param>
        /// <param name="outputDataKind"> The numeric type of the returned values. </param>
        /// <param name="data"> One entry per item in `inputs`, in request order. Empty when `output` is present. </param>
        /// <param name="usage"> Usage for the operation. </param>
        /// <param name="warnings"> Things to know about a successful response, such as truncated items. Omitted when there are none. </param>
        /// <param name="output"> With `delivery: link`: where to read the results. </param>
        /// <returns> A new <see cref="Azure.Data.AI.EmbeddingResult"/> instance for mocking. </returns>
        public static EmbeddingResult EmbeddingResult(string model = default, EmbeddingOutputDataKind outputDataKind = default, IEnumerable<EmbeddingItem> data = default, EmbeddingUsage usage = default, IEnumerable<EmbeddingWarning> warnings = default, EmbeddingOutput output = default)
        {
            data ??= new ChangeTrackingList<EmbeddingItem>();
            warnings ??= new ChangeTrackingList<EmbeddingWarning>();

            return new EmbeddingResult(
                model,
                null,
                outputDataKind,
                data.ToList(),
                usage,
                warnings.ToList(),
                output,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.Data.AI.EmbeddingItem"/>. </summary>
        /// <param name="kind"> The discriminator value. </param>
        /// <param name="index"> The index of the embedding. </param>
        /// <param name="id"> The embedding identifier. </param>
        /// <returns> A new <see cref="Azure.Data.AI.EmbeddingItem"/> instance for mocking. </returns>
        public static EmbeddingItem EmbeddingItem(string kind = default, int index = default, string id = default)
        {
            return new UnknownEmbeddingItem(kind == null ? default(EmbeddingDataKind) : new EmbeddingDataKind(kind), index, id, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.Data.AI.EmbeddingUsage"/>. </summary>
        /// <param name="kind"> The discriminator value. </param>
        /// <param name="promptTokens"> The number of prompt tokens. </param>
        /// <param name="totalTokens"> The total number of tokens. </param>
        /// <returns> A new <see cref="Azure.Data.AI.EmbeddingUsage"/> instance for mocking. </returns>
        public static EmbeddingUsage EmbeddingUsage(string kind = default, long? promptTokens = default, long? totalTokens = default)
        {
            return new UnknownEmbeddingUsage(kind == null ? default(EmbeddingUsageKind) : new EmbeddingUsageKind(kind), promptTokens, totalTokens, additionalBinaryDataProperties: null);
        }
    }
}
