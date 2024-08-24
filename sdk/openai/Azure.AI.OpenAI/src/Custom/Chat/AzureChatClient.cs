// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;

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
        _apiVersion = options.Version;
        _endpoint = endpoint;
    }

    protected AzureChatClient()
    { }

    /// <inheritdoc/>
    public override AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreamingAsync(messages, options, cancellationToken);
    }

    /// <inheritdoc/>
    public override CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        options.StreamOptions = null;
        return base.CompleteChatStreaming(messages, options, cancellationToken);
    }
}
