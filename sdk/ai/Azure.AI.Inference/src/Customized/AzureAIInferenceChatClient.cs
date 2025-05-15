// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference;

namespace Microsoft.Extensions.AI;

/// <summary>Represents an <see cref="IChatClient"/> for an Azure AI Inference <see cref="ChatCompletionsClient"/>.</summary>
internal sealed partial class AzureAIInferenceChatClient : IChatClient
{
    /// <summary>Gets the JSON schema transform cache conforming to OpenAI restrictions per https://platform.openai.com/docs/guides/structured-outputs?api-mode=responses#supported-schemas.</summary>
    private static AIJsonSchemaTransformCache SchemaTransformCache { get; } = new(new()
    {
        RequireAllProperties = true,
        DisallowAdditionalProperties = true,
        ConvertBooleanSchemas = true,
        MoveDefaultKeywordToDescription = true,
    });

    /// <summary>Metadata about the client.</summary>
    private readonly ChatClientMetadata _metadata;

    /// <summary>The underlying <see cref="ChatCompletionsClient" />.</summary>
    private readonly ChatCompletionsClient _chatCompletionsClient;

    /// <summary>Gets a ChatRole.Developer value.</summary>
    private static ChatRole ChatRoleDeveloper { get; } = new("developer");

    /// <summary>Initializes a new instance of the <see cref="AzureAIInferenceChatClient"/> class for the specified <see cref="ChatCompletionsClient"/>.</summary>
    /// <param name="chatCompletionsClient">The underlying client.</param>
    /// <param name="defaultModelId">The ID of the model to use. If <see langword="null"/>, it can be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="chatCompletionsClient"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="defaultModelId"/> is empty or composed entirely of whitespace.</exception>
    public AzureAIInferenceChatClient(ChatCompletionsClient chatCompletionsClient, string? defaultModelId = null)
    {
        Argument.AssertNotNull(chatCompletionsClient, nameof(chatCompletionsClient));

        if (defaultModelId is not null)
        {
            Argument.AssertNotNullOrWhiteSpace(defaultModelId, nameof(defaultModelId));
        }

        _chatCompletionsClient = chatCompletionsClient;
        _metadata = new ChatClientMetadata("az.ai.inference", chatCompletionsClient.Endpoint, defaultModelId);
    }

    /// <inheritdoc />
    object? IChatClient.GetService(Type serviceType, object? serviceKey)
    {
        Argument.AssertNotNull(serviceKey, nameof(serviceKey));

        return
            serviceKey is not null ? null :
            serviceType == typeof(ChatCompletionsClient) ? _chatCompletionsClient :
            serviceType == typeof(ChatClientMetadata) ? _metadata :
            serviceType.IsInstanceOfType(this) ? this :
            null;
    }

    /// <inheritdoc />
    public async Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(messages, nameof(messages));

        // Make the call.
        ChatCompletions response = (await _chatCompletionsClient.CompleteAsync(
            ToAzureAIOptions(messages, options),
            cancellationToken: cancellationToken).ConfigureAwait(false)).Value;

        // Create the return message.
        ChatMessage message = new(ToChatRole(response.Role), response.Content)
        {
            MessageId = response.Id, // There is no per-message ID, but there's only one message per response, so use the response ID
            RawRepresentation = response,
        };

        if (response.ToolCalls is { Count: > 0 } toolCalls)
        {
            foreach (var toolCall in toolCalls)
            {
                if (toolCall is ChatCompletionsToolCall ftc && !string.IsNullOrWhiteSpace(ftc.Name))
                {
                    FunctionCallContent callContent = ParseCallContentFromJsonString(ftc.Arguments, toolCall.Id, ftc.Name);
                    callContent.RawRepresentation = toolCall;

                    message.Contents.Add(callContent);
                }
            }
        }

        UsageDetails? usage = null;
        if (response.Usage is CompletionsUsage completionsUsage)
        {
            usage = new()
            {
                InputTokenCount = completionsUsage.PromptTokens,
                OutputTokenCount = completionsUsage.CompletionTokens,
                TotalTokenCount = completionsUsage.TotalTokens,
            };
        }

        // Wrap the content in a ChatResponse to return.
        return new ChatResponse(message)
        {
            CreatedAt = response.Created,
            ModelId = response.Model,
            FinishReason = ToFinishReason(response.FinishReason),
            RawRepresentation = response,
            ResponseId = response.Id,
            Usage = usage,
        };
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(messages, nameof(messages));

        Dictionary<string, FunctionCallInfo>? functionCallInfos = null;
        ChatRole? streamedRole = default;
        ChatFinishReason? finishReason = default;
        string? responseId = null;
        DateTimeOffset? createdAt = null;
        string? modelId = null;
        string lastCallId = string.Empty;

        // Process each update as it arrives
        var updates = await _chatCompletionsClient.CompleteStreamingAsync(ToAzureAIOptions(messages, options), cancellationToken).ConfigureAwait(false);
        await foreach (StreamingChatCompletionsUpdate chatCompletionUpdate in updates.ConfigureAwait(false))
        {
            // The role and finish reason may arrive during any update, but once they've arrived, the same value should be the same for all subsequent updates.
            streamedRole ??= chatCompletionUpdate.Role is global::Azure.AI.Inference.ChatRole role ? ToChatRole(role) : null;
            finishReason ??= chatCompletionUpdate.FinishReason is CompletionsFinishReason reason ? ToFinishReason(reason) : null;
            responseId ??= chatCompletionUpdate.Id; // While it's unclear from the name, this Id is documented to be the response ID, not the chunk ID
            createdAt ??= chatCompletionUpdate.Created;
            modelId ??= chatCompletionUpdate.Model;

            // Create the response content object.
            ChatResponseUpdate responseUpdate = new()
            {
                CreatedAt = chatCompletionUpdate.Created,
                FinishReason = finishReason,
                ModelId = modelId,
                RawRepresentation = chatCompletionUpdate,
                ResponseId = responseId,
                MessageId = responseId, // There is no per-message ID, but there's only one message per response, so use the response ID
                Role = streamedRole,
            };

            // Transfer over content update items.
            if (chatCompletionUpdate.ContentUpdate is string update)
            {
                responseUpdate.Contents.Add(new TextContent(update));
            }

            // Transfer over tool call updates.
            if (chatCompletionUpdate.ToolCallUpdate is { } toolCallUpdate)
            {
                // TODO https://github.com/Azure/azure-sdk-for-net/issues/46830: Azure.AI.Inference
                // has removed the Index property from ToolCallUpdate. It's now impossible via the
                // exposed APIs to correctly handle multiple parallel tool calls, as the CallId is
                // often null for anything other than the first update for a given call, and Index
                // isn't available to correlate which updates are for which call. This is a temporary
                // workaround to at least make a single tool call work and also make work multiple
                // tool calls when their updates aren't interleaved.
                if (toolCallUpdate.Id is not null)
                {
                    lastCallId = toolCallUpdate.Id;
                }

                functionCallInfos ??= [];
                if (!functionCallInfos.TryGetValue(lastCallId, out FunctionCallInfo? existing))
                {
                    functionCallInfos[lastCallId] = existing = new();
                }

                existing.Name ??= toolCallUpdate.Function.Name;
                if (toolCallUpdate.Function.Arguments is { } arguments)
                {
                    _ = (existing.Arguments ??= new()).Append(arguments);
                }
            }

            if (chatCompletionUpdate.Usage is { } usage)
            {
                responseUpdate.Contents.Add(new UsageContent(new()
                {
                    InputTokenCount = usage.PromptTokens,
                    OutputTokenCount = usage.CompletionTokens,
                    TotalTokenCount = usage.TotalTokens,
                }));
            }

            // Now yield the item.
            yield return responseUpdate;
        }

        // Now that we've received all updates, combine any for function calls into a single item to yield.
        if (functionCallInfos is not null)
        {
            var responseUpdate = new ChatResponseUpdate
            {
                CreatedAt = createdAt,
                FinishReason = finishReason,
                ModelId = modelId,
                ResponseId = responseId,
                MessageId = responseId, // There is no per-message ID, but there's only one message per response, so use the response ID
                Role = streamedRole,
            };

            foreach (var entry in functionCallInfos)
            {
                FunctionCallInfo fci = entry.Value;
                if (!string.IsNullOrWhiteSpace(fci.Name))
                {
                    FunctionCallContent callContent = ParseCallContentFromJsonString(
                        fci.Arguments?.ToString() ?? string.Empty,
                        entry.Key,
                        fci.Name!);
                    responseUpdate.Contents.Add(callContent);
                }
            }

            yield return responseUpdate;
        }
    }

    /// <inheritdoc />
    void IDisposable.Dispose()
    {
        // Nothing to dispose. Implementation required for the IChatClient interface.
    }

    /// <summary>POCO representing function calling info. Used to concatenation information for a single function call from across multiple streaming updates.</summary>
    private sealed class FunctionCallInfo
    {
        public string? Name;
        public StringBuilder? Arguments;
    }

    /// <summary>Converts an AzureAI role to an Extensions role.</summary>
    private static ChatRole ToChatRole(global::Azure.AI.Inference.ChatRole role) =>
        role.Equals(global::Azure.AI.Inference.ChatRole.System) ? ChatRole.System :
        role.Equals(global::Azure.AI.Inference.ChatRole.User) ? ChatRole.User :
        role.Equals(global::Azure.AI.Inference.ChatRole.Assistant) ? ChatRole.Assistant :
        role.Equals(global::Azure.AI.Inference.ChatRole.Tool) ? ChatRole.Tool :
        role.Equals(global::Azure.AI.Inference.ChatRole.Developer) ? ChatRoleDeveloper :
        new ChatRole(role.ToString());

    /// <summary>Converts an AzureAI finish reason to an Extensions finish reason.</summary>
    private static ChatFinishReason? ToFinishReason(CompletionsFinishReason? finishReason) =>
        finishReason?.ToString() is not string s ? null :
        finishReason == CompletionsFinishReason.Stopped ? ChatFinishReason.Stop :
        finishReason == CompletionsFinishReason.TokenLimitReached ? ChatFinishReason.Length :
        finishReason == CompletionsFinishReason.ContentFiltered ? ChatFinishReason.ContentFilter :
        finishReason == CompletionsFinishReason.ToolCalls ? ChatFinishReason.ToolCalls :
        new(s);

    private ChatCompletionsOptions CreateAzureAIOptions(IEnumerable<ChatMessage> chatContents, ChatOptions? options) =>
        new(ToAzureAIInferenceChatMessages(chatContents))
        {
            Model = options?.ModelId ?? _metadata.DefaultModelId ??
                throw new InvalidOperationException("No model id was provided when either constructing the client or in the chat options.")
        };

    /// <summary>Converts an extensions options instance to an Azure.AI.Inference options instance.</summary>
    private ChatCompletionsOptions ToAzureAIOptions(IEnumerable<ChatMessage> chatContents, ChatOptions? options)
    {
        if (options is null)
        {
            return CreateAzureAIOptions(chatContents, options);
        }

        if (options.RawRepresentationFactory?.Invoke(this) is ChatCompletionsOptions result)
        {
            result.Messages = ToAzureAIInferenceChatMessages(chatContents).ToList();
            result.Model ??= options.ModelId ?? _metadata.DefaultModelId ??
                throw new InvalidOperationException("No model id was provided when either constructing the client or in the chat options.");
        }
        else
        {
            result = CreateAzureAIOptions(chatContents, options);
        }

        result.FrequencyPenalty ??= options.FrequencyPenalty;
        result.MaxTokens ??= options.MaxOutputTokens;
        result.NucleusSamplingFactor ??= options.TopP;
        result.PresencePenalty ??= options.PresencePenalty;
        result.Temperature ??= options.Temperature;
        result.Seed ??= options.Seed;

        if (options.StopSequences is { Count: > 0 } stopSequences)
        {
            foreach (string stopSequence in stopSequences)
            {
                result.StopSequences.Add(stopSequence);
            }
        }

        // This property is strongly typed on ChatOptions but not on ChatCompletionsOptions.
        if (options.TopK is int topK && !result.AdditionalProperties.ContainsKey("top_k"))
        {
            result.AdditionalProperties["top_k"] = new BinaryData(JsonSerializer.SerializeToUtf8Bytes(topK, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(int))));
        }

        if (options.AdditionalProperties is { } props)
        {
            foreach (var prop in props)
            {
                byte[] data = JsonSerializer.SerializeToUtf8Bytes(prop.Value, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object)));
                result.AdditionalProperties[prop.Key] = new BinaryData(data);
            }
        }

        if (options.Tools is { Count: > 0 } tools)
        {
            foreach (AITool tool in tools)
            {
                if (tool is AIFunction af)
                {
                    result.Tools.Add(ToAzureAIChatTool(af));
                }
            }

            if (result.ToolChoice is null && result.Tools.Count > 0)
            {
                switch (options.ToolMode)
                {
                    case NoneChatToolMode:
                        result.ToolChoice = ChatCompletionsToolChoice.None;
                        break;

                    case AutoChatToolMode:
                    case null:
                        result.ToolChoice = ChatCompletionsToolChoice.Auto;
                        break;

                    case RequiredChatToolMode required:
                        result.ToolChoice = required.RequiredFunctionName is null ?
                            ChatCompletionsToolChoice.Required :
                            new ChatCompletionsToolChoice(new FunctionDefinition(required.RequiredFunctionName));
                        break;
                }
            }
        }

        if (result.ResponseFormat is null)
        {
            if (options.ResponseFormat is ChatResponseFormatText)
            {
                result.ResponseFormat = ChatCompletionsResponseFormat.CreateTextFormat();
            }
            else if (options.ResponseFormat is ChatResponseFormatJson json)
            {
                if (SchemaTransformCache.GetOrCreateTransformedSchema(json) is { } schema)
                {
                    var tool = JsonSerializer.Deserialize(schema, ChatClientJsonContext.Default.AzureAIChatToolJson)!;
                    result.ResponseFormat = ChatCompletionsResponseFormat.CreateJsonFormat(
                        json.SchemaName ?? "json_schema",
                        new Dictionary<string, BinaryData>
                        {
                            ["type"] = _objectString,
                            ["properties"] = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(tool.Properties, ChatClientJsonContext.Default.DictionaryStringJsonElement)),
                            ["required"] = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(tool.Required, ChatClientJsonContext.Default.ListString)),
                            ["additionalProperties"] = _falseString,
                        },
                        json.SchemaDescription);
                }
                else
                {
                    result.ResponseFormat = ChatCompletionsResponseFormat.CreateJsonFormat();
                }
            }
        }

        return result;
    }

    /// <summary>Cached <see cref="BinaryData"/> for "object".</summary>
    private static readonly BinaryData _objectString = BinaryData.FromString("\"object\"");

    /// <summary>Cached <see cref="BinaryData"/> for "false".</summary>
    private static readonly BinaryData _falseString = BinaryData.FromString("false");

    /// <summary>Converts an Extensions function to an AzureAI chat tool.</summary>
    private static ChatCompletionsToolDefinition ToAzureAIChatTool(AIFunction aiFunction)
    {
        // Map to an intermediate model so that redundant properties are skipped.
        var tool = JsonSerializer.Deserialize(SchemaTransformCache.GetOrCreateTransformedSchema(aiFunction), ChatClientJsonContext.Default.AzureAIChatToolJson)!;
        var functionParameters = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(tool, ChatClientJsonContext.Default.AzureAIChatToolJson));
        return new(new FunctionDefinition(aiFunction.Name)
        {
            Description = aiFunction.Description,
            Parameters = functionParameters,
        });
    }

    /// <summary>Converts an Extensions chat message enumerable to an AzureAI chat message enumerable.</summary>
    private static IEnumerable<ChatRequestMessage> ToAzureAIInferenceChatMessages(IEnumerable<ChatMessage> inputs)
    {
        // Maps all of the M.E.AI types to the corresponding AzureAI types.
        // Unrecognized or non-processable content is ignored.

        foreach (ChatMessage input in inputs)
        {
            if (input.Role == ChatRole.System)
            {
                yield return new ChatRequestSystemMessage(input.Text ?? string.Empty);
            }
            else if (input.Role == ChatRoleDeveloper)
            {
                yield return new ChatRequestDeveloperMessage(input.Text ?? string.Empty);
            }
            else if (input.Role == ChatRole.Tool)
            {
                foreach (AIContent item in input.Contents)
                {
                    if (item is FunctionResultContent resultContent)
                    {
                        string? result = resultContent.Result as string;
                        if (result is null && resultContent.Result is not null)
                        {
                            try
                            {
                                result = JsonSerializer.Serialize(resultContent.Result, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object)));
                            }
                            catch (NotSupportedException)
                            {
                                // If the type can't be serialized, skip it.
                            }
                        }

                        yield return new ChatRequestToolMessage(result ?? string.Empty, resultContent.CallId);
                    }
                }
            }
            else if (input.Role == ChatRole.User)
            {
                if (input.Contents.Count > 0)
                {
                    if (input.Contents.All(c => c is TextContent))
                    {
                        if (string.Concat(input.Contents) is { Length: > 0 } text)
                        {
                            yield return new ChatRequestUserMessage(text);
                        }
                    }
                    else if (GetContentParts(input.Contents) is { Count: > 0 } parts)
                    {
                        yield return new ChatRequestUserMessage(parts);
                    }
                }
            }
            else if (input.Role == ChatRole.Assistant)
            {
                // TODO: ChatRequestAssistantMessage only enables text content currently.
                // Update it with other content types when it supports that.
                ChatRequestAssistantMessage message = new(string.Concat(input.Contents.Where(c => c is TextContent)));

                foreach (var content in input.Contents)
                {
                    if (content is FunctionCallContent { CallId: not null } callRequest)
                    {
                        message.ToolCalls.Add(new ChatCompletionsToolCall(
                             callRequest.CallId,
                             new FunctionCall(
                                 callRequest.Name,
                                 JsonSerializer.Serialize(callRequest.Arguments, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(IDictionary<string, object>))))));
                    }
                }

                yield return message;
            }
        }
    }

    /// <summary>Converts a list of <see cref="AIContent"/> to a list of <see cref="ChatMessageContentItem"/>.</summary>
    private static List<ChatMessageContentItem> GetContentParts(IList<AIContent> contents)
    {
        Debug.Assert(contents is { Count: > 0 }, "Expected non-empty contents");

        List<ChatMessageContentItem> parts = [];
        foreach (var content in contents)
        {
            switch (content)
            {
                case TextContent textContent:
                    parts.Add(new ChatMessageTextContentItem(textContent.Text));
                    break;

                case UriContent uriContent when uriContent.HasTopLevelMediaType("image"):
                    parts.Add(new ChatMessageImageContentItem(uriContent.Uri));
                    break;

                case DataContent dataContent when dataContent.HasTopLevelMediaType("image"):
                    parts.Add(new ChatMessageImageContentItem(BinaryData.FromBytes(dataContent.Data), dataContent.MediaType));
                    break;

                case UriContent uriContent when uriContent.HasTopLevelMediaType("audio"):
                    parts.Add(new ChatMessageAudioContentItem(uriContent.Uri));
                    break;

                case DataContent dataContent when dataContent.HasTopLevelMediaType("audio"):
                    AudioContentFormat format;
                    if (dataContent.MediaType.Equals("audio/mpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        format = AudioContentFormat.Mp3;
                    }
                    else if (dataContent.MediaType.Equals("audio/wav", StringComparison.OrdinalIgnoreCase))
                    {
                        format = AudioContentFormat.Wav;
                    }
                    else
                    {
                        break;
                    }

                    parts.Add(new ChatMessageAudioContentItem(BinaryData.FromBytes(dataContent.Data), format));
                    break;
            }
        }

        return parts;
    }

    private static FunctionCallContent ParseCallContentFromJsonString(string json, string callId, string name) =>
        FunctionCallContent.CreateFromParsedArguments(json, callId, name,
            argumentParser: static json => JsonSerializer.Deserialize(json,
                (JsonTypeInfo<IDictionary<string, object>>)AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(IDictionary<string, object>)))!);

    /// <summary>Source-generated JSON type information.</summary>
    [JsonSourceGenerationOptions(JsonSerializerDefaults.Web,
        UseStringEnumConverter = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true)]
    [JsonSerializable(typeof(AzureAIChatToolJson))]
    internal sealed partial class ChatClientJsonContext : JsonSerializerContext;

    /// <summary>Used to create the JSON payload for an AzureAI chat tool description.</summary>
    internal sealed class AzureAIChatToolJson
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "object";

        [JsonPropertyName("required")]
        public List<string> Required { get; set; } = [];

        [JsonPropertyName("properties")]
        public Dictionary<string, JsonElement> Properties { get; set; } = [];
    }
}
