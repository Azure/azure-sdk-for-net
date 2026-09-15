// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("GetAgentConversationItem", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationItemAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
public partial class AgentEndpointConversations
{
    /// <summary>
    /// Retrieves a single item from the specified conversation by its id, including its transcript. An
    /// `input_audio`/`output_audio` content part indicates that audio is available for the item; the canonical per-item
    /// audio metadata is the `/items/{item_id}/audio` resource, and the bytes are streamed by
    /// `/items/{item_id}/audio/content`. Returns `404` when the conversation or item was not persisted
    /// (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the item. </param>
    /// <param name="itemId"> The id of the conversation item to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="itemId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="itemId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<RealtimeItem> GetAgentConversationItem(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

        ClientResult result = GetAgentConversationItem(agentName, conversationId, itemId, cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(ModelReaderWriter.Read<RealtimeItem>(response.Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), response);
    }

    /// <summary>
    /// Retrieves a single item from the specified conversation by its id, including its transcript. An
    /// `input_audio`/`output_audio` content part indicates that audio is available for the item; the canonical per-item
    /// audio metadata is the `/items/{item_id}/audio` resource, and the bytes are streamed by
    /// `/items/{item_id}/audio/content`. Returns `404` when the conversation or item was not persisted
    /// (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the item. </param>
    /// <param name="itemId"> The id of the conversation item to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="itemId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="itemId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<RealtimeItem>> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

        ClientResult result = await GetAgentConversationItemAsync(agentName, conversationId, itemId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(ModelReaderWriter.Read<RealtimeItem>(response.Content, ModelReaderWriterOptions.Json, OpenAIContext.Default), response);
    }
}
