// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using Azure.AI.AgentServer.Contracts.Generated.Agents;
using Azure.AI.AgentServer.Contracts.Generated.Conversations;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Provides extension methods for working with agent responses.
/// </summary>
public static class ResponsesExtensions
{
    /// <summary>
    /// Converts a create response request to a response object.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">Optional agent invocation context.</param>
    /// <param name="output">Optional collection of output items.</param>
    /// <param name="status">The response status.</param>
    /// <param name="createdAt">Optional creation timestamp.</param>
    /// <param name="usage">Optional usage information.</param>
    /// <returns>A response object.</returns>
    public static Contracts.Generated.Responses.Response ToResponse(
        this CreateResponseRequest request,
        AgentInvocationContext? context = null,
        IEnumerable<ItemResource>? output = null,
        ResponseStatus status = ResponseStatus.Completed,
        DateTimeOffset? createdAt = null,
        ResponseUsage? usage = null)
    {
        return new Contracts.Generated.Responses.Response(
            metadata: request.Metadata as IReadOnlyDictionary<string, string>,
            temperature: request.Temperature,
            topP: request.TopP,
            user: request.User,
            serviceTier: request.ServiceTier,
            topLogprobs: request.TopLogprobs,
            previousResponseId: request.PreviousResponseId,
            model: request.Model,
            reasoning: request.Reasoning,
            background: request.Background,
            maxOutputTokens: request.MaxOutputTokens,
            maxToolCalls: request.MaxToolCalls,
            text: request.Text,
            tools: request.Tools,
            toolChoice: request.ToolChoice,
            prompt: request.Prompt,
            truncation: request.Truncation,
            id: context?.ResponseId,
            @object: ResponseObject.Response,
            status: status,
            createdAt: createdAt ?? DateTimeOffset.UtcNow,
            error: null,
            incompleteDetails: null,
            output: output?.ToList() ?? ReadOnlyCollection<ItemResource>.Empty.ToList(),
            instructions: string.IsNullOrEmpty(request.Instructions) ? null : new BinaryData(request.Instructions),
            outputText: null,
            usage: usage,
            parallelToolCalls: request.ParallelToolCalls ?? false,
            conversation: context == null ? null : new ResponseConversation1(context.ConversationId),
            agent: request.Agent.ToAgentId(),
            structuredInputs: request.StructuredInputs,
            serializedAdditionalRawData: null);
    }

    /// <summary>
    /// Converts an agent reference to an agent ID.
    /// </summary>
    /// <param name="agent">The agent reference.</param>
    /// <returns>An agent ID, or null if the agent reference is null.</returns>
    public static AgentId? ToAgentId(this AgentReference? agent)
    {
        return agent == null
            ? null
            : new AgentId(
                type: new AgentIdType(agent.Type.ToString()),
                name: agent.Name,
                version: agent.Version,
                serializedAdditionalRawData: null);
    }

    /// <summary>
    /// Gets the conversation ID from a create response request.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <returns>The conversation ID, or null if not present.</returns>
    public static string? GetConversationId(this CreateResponseRequest request)
    {
        return request.Conversation?.ToObject<ResponseConversation1>()?.Id ?? request.Conversation?.ToObject<string>();
    }
}
