// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Assistants;

internal partial class AzureMessagesPageEnumerator : MessagesPageEnumerator
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    public AzureMessagesPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string threadId,
        int? limit, string order, string after, string before,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, threadId, limit, order, after, before, options)
    {
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }

    internal override async Task<ClientResult> GetMessagesAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessagesRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetMessages(string threadId, int? limit, string order, string after, string before, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(threadId, nameof(threadId));

        using PipelineMessage message = CreateGetMessagesRequest(threadId, limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private PipelineMessage CreateGetMessagesRequest(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithAssistantsHeader()
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithPath("threads", threadId, "messages")
            .Build();
}
