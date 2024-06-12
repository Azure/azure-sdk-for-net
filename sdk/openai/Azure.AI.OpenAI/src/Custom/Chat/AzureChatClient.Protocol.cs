// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.AI.OpenAI.Chat;

internal partial class AzureChatClient : ChatClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult CompleteChat(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCompleteChatRequestMessage(content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);
        return ClientResult.FromResponse(message.BufferResponse ? response : message.ExtractResponse());
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCompleteChatRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(message.BufferResponse ? response : message.ExtractResponse());
    }

    private PipelineMessage CreateCompleteChatRequestMessage(
        BinaryContent content,
        RequestOptions options = null,
        bool? bufferResponse = true)
            => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
                .WithPath("chat", "completions")
                .WithMethod("POST")
                .WithContent(content, "application/json")
                .WithAccept("application/json")
                .WithResponseContentBuffering(bufferResponse)
                .WithOptions(options)
                .Build();
}
