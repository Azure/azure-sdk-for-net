// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Responses.Invocation;

using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Converters;

/// <summary>
/// Provides extension methods for converting AI framework response types to contract types.
/// </summary>
public static class ResponseConverterExtensions
{
    private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;

    /// <summary>
    /// Converts an agent run response to a response contract object.
    /// </summary>
    /// <param name="agentRunResponse">The agent run response to convert.</param>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <returns>A response contract object.</returns>
    public static Contracts.Generated.Responses.Response ToResponse(this AgentRunResponse agentRunResponse,
        CreateResponseRequest request,
        AgentInvocationContext context)
    {
        var output = agentRunResponse.Messages
            .SelectMany(msg => msg.ToItemResource(context.IdGenerator));

        return request.ToResponse(
            context: context,
            output: output,
            createdAt: agentRunResponse.CreatedAt,
            usage: agentRunResponse.Usage.ToResponseUsage()
        );
    }

    /// <summary>
    /// Converts a chat message to a collection of item resources.
    /// </summary>
    /// <param name="message">The chat message to convert.</param>
    /// <param name="idGenerator">The ID generator for creating resource IDs.</param>
    /// <returns>An enumerable collection of item resources.</returns>
    public static IEnumerable<ItemResource> ToItemResource(this ChatMessage message, IIdGenerator idGenerator)
    {
        List<ItemContent> contents = [];
        foreach (var content in message.Contents)
        {
            switch (content)
            {
                case FunctionCallContent functionCallContent:
                    // message.Role == ChatRole.Assistant
                    yield return functionCallContent.ToFunctionToolCallItemResource(idGenerator.GenerateFunctionCallId());
                    break;
                case FunctionResultContent functionResultContent:
                    // message.Role == ChatRole.Tool
                    yield return functionResultContent.ToFunctionToolCallOutputItemResource(
                        idGenerator.GenerateFunctionOutputId());
                    break;
                default:
                    // message.Role == ChatRole.Assistant
                    var itemContent = ToItemContent(content);
                    if (itemContent != null)
                    {
                        contents.Add(itemContent);
                    }

                    break;
            }
        }

        if (contents.Count > 0)
        {
            yield return new ResponsesAssistantMessageItemResource(
                id: idGenerator.GenerateMessageId(),
                status: ResponsesMessageItemResourceStatus.Completed,
                content: contents
            );
        }
    }

    /// <summary>
    /// Converts a function call content to a function tool call item resource.
    /// </summary>
    /// <param name="functionCallContent">The function call content to convert.</param>
    /// <param name="id">The ID for the resource.</param>
    /// <returns>A function tool call item resource.</returns>
    public static FunctionToolCallItemResource ToFunctionToolCallItemResource(
        this FunctionCallContent functionCallContent,
        string id)
    {
        return new FunctionToolCallItemResource(
            id: id,
            status: FunctionToolCallItemResourceStatus.Completed,
            callId: functionCallContent.CallId,
            name: functionCallContent.Name,
            arguments: JsonSerializer.Serialize(functionCallContent.Arguments, Json)
        );
    }

    /// <summary>
    /// Converts a function result content to a function tool call output item resource.
    /// </summary>
    /// <param name="functionResultContent">The function result content to convert.</param>
    /// <param name="id">The ID for the resource.</param>
    /// <returns>A function tool call output item resource.</returns>
    public static FunctionToolCallOutputItemResource ToFunctionToolCallOutputItemResource(
        this FunctionResultContent functionResultContent,
        string id)
    {
        var output = functionResultContent.Exception is not null
            ? $"{functionResultContent.Exception.GetType().Name}(\"{functionResultContent.Exception.Message}\")"
            : $"{functionResultContent.Result?.ToString() ?? "(null)"}";
        return new FunctionToolCallOutputItemResource(
            id: id,
            status: FunctionToolCallOutputItemResourceStatus.Completed,
            callId: functionResultContent.CallId,
            output: output
        );
    }

    /// <summary>
    /// Converts usage details to a response usage object.
    /// </summary>
    /// <param name="usage">The usage details to convert.</param>
    /// <returns>A response usage object, or null if the usage details are null.</returns>
    public static ResponseUsage? ToResponseUsage(this UsageDetails? usage)
    {
        if (usage == null)
        {
            return null;
        }

        var inputTokensDetails =
            usage.AdditionalCounts?.TryGetValue("InputTokenDetails.CachedTokenCount", out var cachedInputToken) ?? false
                ? new ResponseUsageInputTokensDetails((int)cachedInputToken)
                : null;
        var outputTokensDetails =
            usage.AdditionalCounts?.TryGetValue("OutputTokenDetails.ReasoningTokenCount", out var reasoningToken) ??
            false
                ? new ResponseUsageOutputTokensDetails((int)reasoningToken)
                : null;

        return new ResponseUsage(
            inputTokens: (int)(usage.InputTokenCount ?? 0),
            inputTokensDetails: inputTokensDetails,
            outputTokens: (int)(usage.OutputTokenCount ?? 0),
            outputTokensDetails: outputTokensDetails,
            totalTokens: (int)(usage.TotalTokenCount ?? 0)
        );
    }

    /// <summary>
    /// Converts AI content to an item content object.
    /// </summary>
    /// <param name="content">The AI content to convert.</param>
    /// <returns>An item content object, or null if the content cannot be converted.</returns>
    public static ItemContent? ToItemContent(this AIContent content)
    {
        switch (content)
        {
            case TextContent textContent:
                return new ItemContentOutputText(textContent?.Text ?? string.Empty, []);
            case ErrorContent errorContent:
                var message = $"Error = \"{errorContent.Message}\"" +
                              (!string.IsNullOrWhiteSpace(errorContent.ErrorCode)
                                  ? $" ({errorContent.ErrorCode})"
                                  : string.Empty) +
                              (!string.IsNullOrWhiteSpace(errorContent.Details)
                                  ? $" - \"{errorContent.Details}\""
                                  : string.Empty);
                var error = new Contracts.Generated.OpenAI.ResponseError(code: ResponseErrorCode.ServerError,
                    message: message);
                throw new AgentInvocationException(error);
            default:
                return null;
        }
    }
}
