// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Microsoft.Extensions.AI;

#nullable enable

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Implementation of .NET's IChatClient exchange type for chat completion services

    public partial class ChatCompletionsClient : IChatClient
    {
        // TODO: This is currently provided as an explicit implementation of IChatClient on ChatCompletionsClient,
        // which enables an instance to simply be used anywhere an IChatClient is desired. Alternatively, it could
        // be exposed as an AsChatClient() method that would return a new wrapper instance implementing IChatClient.

        /// <summary>A default schema to use when a parameter lacks a pre-defined schema.</summary>
        private static readonly JsonElement s_defaultParameterSchema = JsonDocument.Parse("{}").RootElement;

        /// <summary>The lazily-instantiated metadata.</summary>
        private ChatClientMetadata? _metadata;

        /// <inheritdoc />
        ChatClientMetadata IChatClient.Metadata => _metadata ??= new("az.ai.inference", _endpoint);

        /// <inheritdoc />
        object? IChatClient.GetService(Type serviceType, object? serviceKey)
        {
            Argument.AssertNotNull(serviceType, nameof(serviceType));
            return
                serviceKey is not null ? null :
                serviceType.IsInstanceOfType(this) ? this :
                null;
        }

        /// <inheritdoc />
        async Task<ChatCompletion> IChatClient.CompleteAsync(
            IList<ChatMessage> chatMessages, ChatOptions? options, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(chatMessages, nameof(chatMessages));

            // Make the call.
            ChatCompletions response = (await CompleteAsync(
                ToAzureAIOptions(chatMessages, options),
                cancellationToken: cancellationToken).ConfigureAwait(false)).Value;

            // Create the return message and populate its content from those in the response content.
            ChatMessage message = new()
            {
                RawRepresentation = response,
                Role = ToChatRole(response.Role),
            };

            if (response.Content is string content)
            {
                message.Text = content;
            }

            if (response.ToolCalls is { Count: > 0 } toolCalls)
            {
                foreach (ChatCompletionsToolCall toolCall in toolCalls)
                {
                    if (toolCall is ChatCompletionsToolCall ftc && !string.IsNullOrWhiteSpace(ftc.Name))
                    {
                        FunctionCallContent callContent = ParseCallContentFromJsonString(ftc.Arguments, toolCall.Id, ftc.Name);
                        callContent.RawRepresentation = toolCall;

                        message.Contents.Add(callContent);
                    }
                }
            }

            // Wrap the content in a ChatCompletion to return.
            return new ChatCompletion([message])
            {
                CompletionId = response.Id,
                CreatedAt = response.Created,
                FinishReason = ToFinishReason(response.FinishReason),
                ModelId = response.Model,
                RawRepresentation = response,
                Usage = response.Usage is CompletionsUsage cu ?
                    new()
                    {
                        InputTokenCount = cu.PromptTokens,
                        OutputTokenCount = cu.CompletionTokens,
                        TotalTokenCount = cu.TotalTokens,
                    } :
                    null,
            };
        }

        /// <inheritdoc />
        async IAsyncEnumerable<StreamingChatCompletionUpdate> IChatClient.CompleteStreamingAsync(
            IList<ChatMessage> chatMessages, ChatOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(chatMessages, nameof(chatMessages));

            Dictionary<string, FunctionCallInfo>? functionCallInfos = null;
            Microsoft.Extensions.AI.ChatRole? streamedRole = default;
            ChatFinishReason? finishReason = default;
            string? completionId = null;
            DateTimeOffset? createdAt = null;
            string? modelId = null;
            string lastCallId = string.Empty;

            // Process each update as it arrives
            StreamingResponse<StreamingChatCompletionsUpdate> updates = await CompleteStreamingAsync(ToAzureAIOptions(chatMessages, options), cancellationToken).ConfigureAwait(false);
            await foreach (StreamingChatCompletionsUpdate chatCompletionUpdate in updates.ConfigureAwait(false))
            {
                // The role and finish reason may arrive during any update, but once they've arrived, the same value should be the same for all subsequent updates.
                streamedRole ??= chatCompletionUpdate.Role is ChatRole role ? ToChatRole(role) : null;
                finishReason ??= chatCompletionUpdate.FinishReason is CompletionsFinishReason reason ? ToFinishReason(reason) : null;
                completionId ??= chatCompletionUpdate.Id;
                createdAt ??= chatCompletionUpdate.Created;
                modelId ??= chatCompletionUpdate.Model;

                // Create the response content object.
                StreamingChatCompletionUpdate completionUpdate = new()
                {
                    CompletionId = chatCompletionUpdate.Id,
                    CreatedAt = chatCompletionUpdate.Created,
                    FinishReason = finishReason,
                    ModelId = modelId,
                    RawRepresentation = chatCompletionUpdate,
                    Role = streamedRole,
                };

                // Transfer over content update items.
                if (chatCompletionUpdate.ContentUpdate is string update)
                {
                    completionUpdate.Contents.Add(new TextContent(update));
                }

                // Transfer over tool call updates.
                if (chatCompletionUpdate.ToolCallUpdate is { } toolCallUpdate)
                {
                    // TODO https://github.com/Azure/azure-sdk-for-net/issues/46830:
                    // The Index property was removed from ToolCallUpdate. It's now impossible via the
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
                    completionUpdate.Contents.Add(new UsageContent(new()
                    {
                        InputTokenCount = usage.PromptTokens,
                        OutputTokenCount = usage.CompletionTokens,
                        TotalTokenCount = usage.TotalTokens,
                    }));
                }

                // Now yield the item.
                yield return completionUpdate;
            }

            // Now that we've received all updates, combine any for function calls into a single item to yield.
            if (functionCallInfos is not null)
            {
                var completionUpdate = new StreamingChatCompletionUpdate
                {
                    CompletionId = completionId,
                    CreatedAt = createdAt,
                    FinishReason = finishReason,
                    ModelId = modelId,
                    Role = streamedRole,
                };

                foreach (KeyValuePair<string, FunctionCallInfo> entry in functionCallInfos)
                {
                    FunctionCallInfo fci = entry.Value;
                    if (!string.IsNullOrWhiteSpace(fci.Name))
                    {
                        completionUpdate.Contents.Add(
                            ParseCallContentFromJsonString(fci.Arguments?.ToString() ?? string.Empty, entry.Key, fci.Name!));
                    }
                }

                yield return completionUpdate;
            }
        }

        /// <inheritdoc />
        void IDisposable.Dispose() => GC.SuppressFinalize(this);

        /// <summary>Converts an A.AI.I role to an M.E.AI role.</summary>
        private static Microsoft.Extensions.AI.ChatRole ToChatRole(ChatRole role) =>
            role.Equals(ChatRole.System) ? Microsoft.Extensions.AI.ChatRole.System :
            role.Equals(ChatRole.User) ? Microsoft.Extensions.AI.ChatRole.User :
            role.Equals(ChatRole.Assistant) ? Microsoft.Extensions.AI.ChatRole.Assistant :
            role.Equals(ChatRole.Tool) ? Microsoft.Extensions.AI.ChatRole.Tool :
            new Microsoft.Extensions.AI.ChatRole(role.ToString());

        /// <summary>Converts an A.AI.I finish reason to an M.E.AI finish reason.</summary>
        private static ChatFinishReason? ToFinishReason(CompletionsFinishReason? finishReason) =>
            finishReason?.ToString() is not string s ? null :
            finishReason == CompletionsFinishReason.Stopped ? ChatFinishReason.Stop :
            finishReason == CompletionsFinishReason.TokenLimitReached ? ChatFinishReason.Length :
            finishReason == CompletionsFinishReason.ContentFiltered ? ChatFinishReason.ContentFilter :
            finishReason == CompletionsFinishReason.ToolCalls ? ChatFinishReason.ToolCalls :
            new(s);

        /// <summary>Converts an M.E.AI options instance to an A.AI.I options instance.</summary>
        private ChatCompletionsOptions ToAzureAIOptions(IList<ChatMessage> chatContents, ChatOptions? options)
        {
            ChatCompletionsOptions result = new(ToAzureAIInferenceChatMessages(chatContents));

            if (options is not null)
            {
                result.FrequencyPenalty = options.FrequencyPenalty;
                result.MaxTokens = options.MaxOutputTokens;
                result.Model = options.ModelId;
                result.NucleusSamplingFactor = options.TopP;
                result.PresencePenalty = options.PresencePenalty;
                result.Temperature = options.Temperature;
                result.Seed = options.Seed;

                if (options.StopSequences is { Count: > 0 } stopSequences)
                {
                    foreach (string stopSequence in stopSequences)
                    {
                        result.StopSequences.Add(stopSequence);
                    }
                }

                // These properties are strongly typed on ChatOptions but not on ChatCompletionsOptions.
                if (options.TopK is int topK)
                {
                    result.AdditionalProperties["top_k"] = new BinaryData(JsonSerializer.SerializeToUtf8Bytes(topK, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(int))));
                }

                if (options.AdditionalProperties is { } props)
                {
                    foreach (KeyValuePair<string, object?> prop in props)
                    {
                        switch (prop.Key)
                        {
                            // Propagate everything else to the ChatCompletionOptions' AdditionalProperties.
                            default:
                                if (prop.Value is not null)
                                {
                                    byte[] data = JsonSerializer.SerializeToUtf8Bytes(prop.Value, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object)));
                                    result.AdditionalProperties[prop.Key] = new BinaryData(data);
                                }

                                break;
                        }
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

                    switch (options.ToolMode)
                    {
                        case AutoChatToolMode:
                            result.ToolChoice = ChatCompletionsToolChoice.Auto;
                            break;

                        case RequiredChatToolMode required:
                            result.ToolChoice = required.RequiredFunctionName is null ?
                                ChatCompletionsToolChoice.Required :
                                new ChatCompletionsToolChoice(new FunctionDefinition(required.RequiredFunctionName));
                            break;
                    }
                }

                if (options.ResponseFormat is ChatResponseFormatText)
                {
                    result.ResponseFormat = new ChatCompletionsResponseFormatText();
                }
                else if (options.ResponseFormat is ChatResponseFormatJson)
                {
                    result.ResponseFormat = new ChatCompletionsResponseFormatJSON();
                }
            }

            return result;
        }

        /// <summary>Converts an Extensions function to an AzureAI chat tool.</summary>
        private static ChatCompletionsToolDefinition ToAzureAIChatTool(AIFunction aiFunction)
        {
            BinaryData resultParameters = ChatToolJson.ZeroFunctionParametersSchema;

            IReadOnlyList<AIFunctionParameterMetadata> parameters = aiFunction.Metadata.Parameters;
            if (parameters is { Count: > 0 })
            {
                ChatToolJson tool = new();

                foreach (AIFunctionParameterMetadata parameter in parameters)
                {
                    tool.Properties.Add(
                        parameter.Name,
                        parameter.Schema is JsonElement schema ? schema : s_defaultParameterSchema);

                    if (parameter.IsRequired)
                    {
                        tool.Required.Add(parameter.Name);
                    }
                }
                resultParameters = BinaryData.FromBytes(
                    JsonSerializer.SerializeToUtf8Bytes(tool, JsonContext.Default.ChatToolJson));
            }

            return new(new FunctionDefinition(aiFunction.Metadata.Name)
            {
                Description = aiFunction.Metadata.Description,
                Parameters = resultParameters,
            });
        }

        /// <summary>Converts an M.E.AI chat message enumerable to an A.AI.I chat message enumerable.</summary>
        private IEnumerable<ChatRequestMessage> ToAzureAIInferenceChatMessages(IList<ChatMessage> inputs)
        {
            // Maps all of the M.E.AI types to the corresponding A.AI.I types.
            // Unrecognized or non-processable content is ignored.

            foreach (ChatMessage input in inputs)
            {
                if (input.Role == Microsoft.Extensions.AI.ChatRole.System)
                {
                    yield return new ChatRequestSystemMessage(input.Text ?? string.Empty);
                }
                else if (input.Role == Microsoft.Extensions.AI.ChatRole.Tool)
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
                else if (input.Role == Microsoft.Extensions.AI.ChatRole.User)
                {
                    yield return input.Contents.All(c => c is TextContent) ?
                        new ChatRequestUserMessage(string.Concat(input.Contents)) :
                        new ChatRequestUserMessage(GetContentParts(input.Contents));
                }
                else if (input.Role == Microsoft.Extensions.AI.ChatRole.Assistant)
                {
                    ChatRequestAssistantMessage message = new(string.Concat(input.Contents.Where(c => c is TextContent)));

                    foreach (AIContent content in input.Contents)
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
            foreach (AIContent content in contents)
            {
                switch (content)
                {
                    case TextContent textContent:
                        parts.Add(new ChatMessageTextContentItem(textContent.Text));
                        break;

                    case DataContent dataContent when dataContent.MediaType?.StartsWith("image/", StringComparison.OrdinalIgnoreCase) is true:
                        if (dataContent.ContainsData)
                        {
                            parts.Add(new ChatMessageImageContentItem(BinaryData.FromBytes(dataContent.Data!.Value), dataContent.MediaType));
                        }
                        else if (dataContent.Uri is string uri)
                        {
                            parts.Add(new ChatMessageImageContentItem(new Uri(uri)));
                        }

                        break;
                }
            }

            return parts;
        }

        private static FunctionCallContent ParseCallContentFromJsonString(string json, string callId, string name) =>
            FunctionCallContent.CreateFromParsedArguments(json, callId, name,
                argumentParser: static json => JsonSerializer.Deserialize(json,
                    (JsonTypeInfo<IDictionary<string, object>>)AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(IDictionary<string, object>)))!);

        /// <summary>POCO representing function calling info. Used to concatenate information for a single function call from across multiple streaming updates.</summary>
        private sealed class FunctionCallInfo
        {
            public string? Name;
            public StringBuilder? Arguments;
        }

        /// <summary>Used to create the JSON payload for an AzureAI chat tool description.</summary>
        private sealed class ChatToolJson
        {
            /// <summary>Gets a singleton JSON data for empty parameters. Optimization for the reasonably common case of a parameterless function.</summary>
            public static BinaryData ZeroFunctionParametersSchema { get; } = new("""{"type":"object","required":[],"properties":{}}"""u8.ToArray());

            [JsonPropertyName("type")]
            public string Type { get; set; } = "object";

            [JsonPropertyName("required")]
            public List<string> Required { get; set; } = [];

            [JsonPropertyName("properties")]
            public Dictionary<string, JsonElement> Properties { get; set; } = [];
        }

        /// <summary>Source-generated JSON type information.</summary>
        [JsonSourceGenerationOptions(JsonSerializerDefaults.Web,
            UseStringEnumConverter = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true)]
        [JsonSerializable(typeof(ChatToolJson))]
        private sealed partial class JsonContext : JsonSerializerContext;
    }
}
