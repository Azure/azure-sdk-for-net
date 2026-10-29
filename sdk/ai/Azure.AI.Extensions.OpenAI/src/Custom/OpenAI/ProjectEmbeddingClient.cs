// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Embeddings;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> An embedding client that sends its requests with the pipeline of a <see cref="ProjectOpenAIClient"/>. </summary>
internal sealed class ProjectEmbeddingClient : EmbeddingClient
{
    internal ProjectEmbeddingClient(ClientPipeline pipeline, string model, OpenAIClientOptions options)
        : base(pipeline, model, options)
    {
    }
}
