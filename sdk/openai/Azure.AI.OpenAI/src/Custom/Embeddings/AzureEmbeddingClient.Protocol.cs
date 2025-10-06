// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Embeddings;

internal partial class AzureEmbeddingClient : EmbeddingClient
{
    internal override PipelineMessage CreateGenerateEmbeddingsRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("embeddings")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
