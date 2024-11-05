// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using OpenAI.Embeddings;

namespace Azure.AI.OpenAI.Embeddings;

internal partial class AzureEmbeddingClient : EmbeddingClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GenerateEmbeddings(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateEmbeddingPipelineMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GenerateEmbeddingsAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateEmbeddingPipelineMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateEmbeddingPipelineMessage(BinaryContent content, RequestOptions options = null)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("embeddings")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
