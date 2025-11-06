// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

#pragma warning disable AOAI001
#pragma warning disable AZC0112
#pragma warning disable SCME0001

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
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    protected AzureChatClient()
    { }

    /// <inheritdoc/>
    public override Task<ClientResult<ChatCompletion>> CompleteChatAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        bool maxTokenMasked = options == null ? false : AdditionalPropertyHelpers.GetIsEmptySentinelValue(options.Patch, "$.max_tokens"u8);
        PostfixSwapMaxTokens(ref options);
        Task<ClientResult<ChatCompletion>> result = base.CompleteChatAsync(messages, options, cancellationToken);
        if (maxTokenMasked)
        {
            AdditionalPropertyHelpers.SetEmptySentinelValue(ref options.Patch, "$.max_tokens"u8);
        }
        return result;
    }

    /// <inheritdoc/>
    public override ClientResult<ChatCompletion> CompleteChat(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        bool maxTokenMasked = options == null ? false : AdditionalPropertyHelpers.GetIsEmptySentinelValue(options.Patch, "$.max_tokens"u8);
        PostfixSwapMaxTokens(ref options);
        ClientResult<ChatCompletion> result = base.CompleteChat(messages, options, cancellationToken);
        if (maxTokenMasked)
        {
            AdditionalPropertyHelpers.SetEmptySentinelValue(ref options.Patch, "$.max_tokens"u8);
        }
        return result;
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
        PostfixClearStreamOptions(messages, ref options);
        bool maxTokenMasked = options == null ? false : AdditionalPropertyHelpers.GetIsEmptySentinelValue(options.Patch, "$.max_tokens"u8);
        PostfixSwapMaxTokens(ref options);
        AsyncCollectionResult < StreamingChatCompletionUpdate > result = base.CompleteChatStreamingAsync(messages, options, cancellationToken);
        if (maxTokenMasked)
        {
            AdditionalPropertyHelpers.SetEmptySentinelValue(ref options.Patch, "$.max_tokens"u8);
        }
        return result;
    }

    /// <inheritdoc/>
    public override CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        PostfixClearStreamOptions(messages, ref options);
        bool maxTokenMasked = options == null ? false : AdditionalPropertyHelpers.GetIsEmptySentinelValue(options.Patch, "$.max_tokens"u8);
        PostfixSwapMaxTokens(ref options);
        CollectionResult < StreamingChatCompletionUpdate > result = base.CompleteChatStreaming(messages, options, cancellationToken);
        if (maxTokenMasked)
        {
            AdditionalPropertyHelpers.SetEmptySentinelValue(ref options.Patch, "$.max_tokens"u8);
        }
        return result;
    }

    /**
     * As of 2024-09-01-preview, stream_options support for include_usage (which reports token usage while streaming)
     * is conditionally supported:
     * - When using On Your Data (non-null data_sources), stream_options is not considered valid
     * - When using image input (any content part of "image" type), stream_options is not considered valid
     * - Otherwise, stream_options can be defaulted to enabled per parity surface.
     */
    private static void PostfixClearStreamOptions(IEnumerable<ChatMessage> messages, ref ChatCompletionOptions options)
    {
        if (options?.GetDataSources()?.Count > 0
            || messages?.Any(
                message => message?.Content?.Any(
                    contentPart => contentPart?.Kind == ChatMessageContentPartKind.Image) == true)
                == true)
        {
            options ??= new();
            options.Patch.Remove("$.stream_options"u8);
        }
    }

    private static bool HasValue(JsonPatch patch, ReadOnlySpan<byte> path) => patch.Contains(path) && !patch.IsRemoved(path);

    /**
     * As of 2024-09-01-preview, Azure OpenAI conditionally supports the use of the new max_completion_tokens property:
     *   - The o1-mini and o1-preview models accept max_completion_tokens and reject max_tokens
     *   - All other models reject max_completion_tokens and accept max_tokens
     * To handle this, each request will manipulate serialization overrides:
     *   - If max tokens aren't set, no action is taken
     *   - If serialization of max_tokens has already been blocked (e.g. via the public extension method), no
     *     additional logic is used and new serialization to max_completion_tokens will occur
     *   - Otherwise, serialization of max_completion_tokens is blocked and an override serialization of the
     *     corresponding max_tokens value is established
     */
    private static void PostfixSwapMaxTokens(ref ChatCompletionOptions options)
    {
        options ??= new();
        bool oldPropertyBlocked = AdditionalPropertyHelpers.GetIsEmptySentinelValue(options.Patch, "$.max_tokens"u8);

        if (options.MaxOutputTokenCount.HasValue)
        {
            if (!oldPropertyBlocked)
            {
                options.Patch.Remove("$.max_completion_tokens"u8);
                options.Patch.Set("$.max_tokens"u8, options.MaxOutputTokenCount.Value);
            }
            else
            {
                options.Patch.Remove("$.max_tokens"u8);
                options.Patch.Set("$.max_completion_tokens"u8, options.MaxOutputTokenCount.Value);
            }
        }
        else
        {
            if (HasValue(options.Patch, "$.max_tokens"u8))
            {
                options.Patch.Remove("$.max_tokens"u8);
            }
            if (HasValue(options.Patch, "$.max_completion_tokens"u8))
            {
                options.Patch.Remove("$.max_completion_tokens"u8);
            }
        }
    }
}
