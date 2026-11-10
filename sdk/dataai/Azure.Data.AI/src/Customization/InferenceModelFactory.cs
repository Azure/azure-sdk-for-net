// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // The generator derives the model factory name from the package name
    // (Azure.Data.AI -> AIModelFactory), which is too generic. Rename it to align
    // with the InferenceClient surface.
    [CodeGenType("AIModelFactory")]
    [CodeGenSuppress("MultimodalEmbeddingItem", typeof(int), typeof(string), typeof(EmbeddingContentKind), typeof(string), typeof(int?), typeof(int?), typeof(EmbeddingImageFormat?), typeof(long?), typeof(long?), typeof(bool?), typeof(long?))]
    public static partial class InferenceModelFactory
    {
        /// <summary>
        /// The result for one item, in request order. `kind` says which vectors it holds: `dense` (`MultimodalDenseEmbedding`),
        /// `multi` (`MultimodalMultiVectorEmbedding`) or `dense_multi` (`MultimodalDenseAndMultiVectorEmbedding`).
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AI.MultimodalDenseAndMultiVectorEmbedding"/>, <see cref="AI.MultimodalDenseEmbedding"/>, and <see cref="AI.MultimodalMultiVectorEmbedding"/>.
        /// </summary>
        /// <param name="index"> The zero-based position of the item in the request. </param>
        /// <param name="id"> The item's `id` from the request, if it had one. </param>
        /// <param name="contentKind"> The item's kind. </param>
        /// <param name="kind"> The kind of vectors returned, as requested in `vectorKind`. </param>
        /// <param name="width"> For images: the width in pixels. </param>
        /// <param name="height"> For images: the height in pixels. </param>
        /// <param name="format"> For images: the detected image format. </param>
        /// <param name="tokens">
        /// The tokens the model read for this item, including any text the service adds to queries and, for images, the
        /// image prompt and image tokens. For a truncated item, the tokens embedded. Omitted when the model doesn't report it.
        /// </param>
        /// <param name="visualTokens"> For images: how many of `tokens` were image tokens. </param>
        /// <param name="truncated">
        /// `true` when the item was over the model's token limit and only its start was embedded; `warnings` then has an
        /// `EMBEDDING_INPUT_TRUNCATED` entry for it. Omitted otherwise.
        /// </param>
        /// <param name="inputTokens"> For truncated items only: the item's tokens before truncation. </param>
        /// <returns> A new <see cref="AI.MultimodalEmbeddingItem"/> instance for mocking. </returns>
        public static MultimodalEmbeddingItem MultimodalEmbeddingItem(int index = default, string id = default, EmbeddingContentKind contentKind = default, string kind = default, int? width = default, int? height = default, EmbeddingImageFormat? format = default, long? tokens = default, long? visualTokens = default, bool? truncated = default, long? inputTokens = default)
        {
            return new UnknownMultimodalEmbeddingItem(
                index,
                id,
                contentKind,
                kind == null ? default(EmbeddingVectorKind) : new EmbeddingVectorKind(kind),
                width,
                height,
                format,
                tokens,
                visualTokens,
                truncated,
                inputTokens,
                additionalBinaryDataProperties: null);
        }
    }
}
