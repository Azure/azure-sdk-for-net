// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.Inference;

namespace Microsoft.Extensions.AI;

/// <summary>Provides extension methods for working with Azure AI Inference.</summary>
public static class AzureAIInferenceExtensions
{
    /// <summary>Gets an <see cref="IChatClient"/> for use with this <see cref="ChatCompletionsClient"/>.</summary>
    /// <param name="chatCompletionsClient">The client.</param>
    /// <param name="modelId">The ID of the model to use. If <see langword="null"/>, it can be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <returns>An <see cref="IChatClient"/> that can be used to converse via the <see cref="ChatCompletionsClient"/>.</returns>
    public static IChatClient AsIChatClient(
        this ChatCompletionsClient chatCompletionsClient, string modelId = null) =>
        new AzureAIInferenceChatClient(chatCompletionsClient, modelId);

    /// <summary>Gets an <see cref="IEmbeddingGenerator{String, Single}"/> for use with this <see cref="EmbeddingsClient"/>.</summary>
    /// <param name="embeddingsClient">The client.</param>
    /// <param name="defaultModelId">The ID of the model to use. If <see langword="null"/>, it can be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <param name="defaultModelDimensions">The number of dimensions generated in each embedding.</param>
    /// <returns>An <see cref="IEmbeddingGenerator{String, Embedding}"/> that can be used to generate embeddings via the <see cref="EmbeddingsClient"/>.</returns>
    public static IEmbeddingGenerator<string, Embedding<float>> AsIEmbeddingGenerator(
        this EmbeddingsClient embeddingsClient, string defaultModelId = null, int? defaultModelDimensions = null) =>
        new AzureAIInferenceEmbeddingGenerator(embeddingsClient, defaultModelId, defaultModelDimensions);

    /// <summary>Gets an <see cref="IEmbeddingGenerator{DataContent, Single}"/> for use with this <see cref="EmbeddingsClient"/>.</summary>
    /// <param name="imageEmbeddingsClient">The client.</param>
    /// <param name="defaultModelId">The ID of the model to use. If <see langword="null"/>, it can be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <param name="defaultModelDimensions">The number of dimensions generated in each embedding.</param>
    /// <returns>An <see cref="IEmbeddingGenerator{DataContent, Embedding}"/> that can be used to generate embeddings via the <see cref="ImageEmbeddingsClient"/>.</returns>
    public static IEmbeddingGenerator<DataContent, Embedding<float>> AsIEmbeddingGenerator(
        this ImageEmbeddingsClient imageEmbeddingsClient, string defaultModelId = null, int? defaultModelDimensions = null) =>
        new AzureAIInferenceImageEmbeddingGenerator(imageEmbeddingsClient, defaultModelId, defaultModelDimensions);
}
