// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

/// <summary>
/// The scenario client used for chat completion operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureChatClient : ChatClient
{
    private readonly string _deploymentName;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureChatClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, model: deploymentName, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureChatClient()
    { }

    /// <inheritdoc/>
    public override Task<ClientResult<ChatCompletion>> CompleteChatAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        PostfixSwapMaxTokens(ref options);
        return base.CompleteChatAsync(messages, options, cancellationToken);
    }

    /// <inheritdoc/>
    public override ClientResult<ChatCompletion> CompleteChat(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        PostfixSwapMaxTokens(ref options);
        return base.CompleteChat(messages, options, cancellationToken);
    }

    /// <inheritdoc/>
    public override AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(params ChatMessage[] messages)
        => CompleteChatStreamingAsync(messages, default(ChatCompletionOptions));

    /// <inheritdoc/>
    public override CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(params ChatMessage[] messages)
        => CompleteChatStreaming(messages, default(ChatCompletionOptions));

    /// <inheritdoc/>
    public override AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        PostfixClearStreamOptions(ref options);
        PostfixSwapMaxTokens(ref options);
        return base.CompleteChatStreamingAsync(messages, options, cancellationToken);
    }

    /// <inheritdoc/>
    public override CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        PostfixClearStreamOptions(ref options);
        PostfixSwapMaxTokens(ref options);
        return base.CompleteChatStreaming(messages, options, cancellationToken);
    }

    private static void PostfixClearStreamOptions(ref ChatCompletionOptions options)
    {
        options ??= new();
        options.StreamOptions = null;
    }

    private static void PostfixSwapMaxTokens(ref ChatCompletionOptions options)
    {
        options ??= new();
        if (options.MaxOutputTokenCount is not null)
        {
            options.SerializedAdditionalRawData ??= new Dictionary<string, BinaryData>();
            options.SerializedAdditionalRawData["max_completion_tokens"] = BinaryData.FromObjectAsJson("__EMPTY__");
            options.SerializedAdditionalRawData["max_tokens"] = BinaryData.FromObjectAsJson(options.MaxOutputTokenCount);
        }
    }
}
