// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenSuppress("GetAgentConversations", typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationsAsync", typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversations", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationResponseItems", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationResponseItemsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationResponseItems", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationResponseItemsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationItems", typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationItems", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationItemsAsync", typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationItemsAsync", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationResponses", typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationResponses", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAgentConversationResponsesAsync", typeof(string), typeof(string), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAgentConversationResponsesAsync", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class AgentEndpointConversations
{
    /// <summary>
    /// Returns the conversations persisted for the specified voice agent endpoint.
    /// Conversations are present when the session's effective `store` setting is `true`, whether inherited from the
    /// agent definition or enabled by the WebSocket session override.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<VoiceConversation> GetAgentConversations(string agentName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAICollectionResultOfT<VoiceConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<VoiceConversation>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns the conversations persisted for the specified voice agent endpoint.
    /// Conversations are present when the session's effective `store` setting is `true`, whether inherited from the
    /// agent definition or enabled by the WebSocket session override.
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<VoiceConversation> GetAgentConversationsAsync(string agentName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAIAsyncCollectionResultOfT<VoiceConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<VoiceConversation>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of the output items produced by a specific response (the response's output
    /// projection). For the complete ordered conversation history — including user input and client-created
    /// tool outputs — use the conversation items route instead. Returns `404` when the conversation or
    /// response was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the response. </param>
    /// <param name="responseId"> The id of the response whose output items are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="responseId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="responseId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<RealtimeItem> GetAgentConversationResponseItems(string agentName, string conversationId, string responseId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        return new InternalOpenAICollectionResultOfT<RealtimeItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationResponseItemsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    responseId: localCollectionOptions.Filters[2],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId, responseId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of the output items produced by a specific response (the response's output
    /// projection). For the complete ordered conversation history — including user input and client-created
    /// tool outputs — use the conversation items route instead. Returns `404` when the conversation or
    /// response was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation that contains the response. </param>
    /// <param name="responseId"> The id of the response whose output items are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="responseId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="conversationId"/> or <paramref name="responseId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<RealtimeItem> GetAgentConversationResponseItemsAsync(string agentName, string conversationId, string responseId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));

        return new InternalOpenAIAsyncCollectionResultOfT<RealtimeItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationResponseItemsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    responseId: localCollectionOptions.Filters[2],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId, responseId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of items — the complete ordered conversation history, including user input,
    /// assistant output, and client-created tool outputs (transcripts + tool events). Returns `404` when the
    /// conversation was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation whose items are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<RealtimeItem> GetAgentConversationItems(string agentName, string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAICollectionResultOfT<RealtimeItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationItemsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of items — the complete ordered conversation history, including user input,
    /// assistant output, and client-created tool outputs (transcripts + tool events). Returns `404` when the
    /// conversation was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation whose items are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<RealtimeItem> GetAgentConversationItemsAsync(string agentName, string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAIAsyncCollectionResultOfT<RealtimeItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationItemsRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<RealtimeItem>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of the responses (model inference turns) recorded for the specified
    /// conversation. The per-response `output` projection may be omitted here; use the response-items route
    /// for the canonical paged output. Returns `404` when the conversation was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation whose responses are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<VoiceResponse> GetAgentConversationResponses(string agentName, string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAICollectionResultOfT<VoiceResponse>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationResponsesRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<VoiceResponse>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Returns a paged collection of the responses (model inference turns) recorded for the specified
    /// conversation. The per-response `output` projection may be omitted here; use the response-items route
    /// for the canonical paged output. Returns `404` when the conversation was not persisted (`store = false`).
    /// </summary>
    /// <param name="agentName"> The name of the agent. </param>
    /// <param name="conversationId"> The id of the conversation whose responses are listed. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<VoiceResponse> GetAgentConversationResponsesAsync(string agentName, string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAIAsyncCollectionResultOfT<VoiceResponse>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationResponsesRequest(
                    agentName: localCollectionOptions.Filters[0],
                    conversationId: localCollectionOptions.Filters[1],
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<VoiceResponse>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, conversationId]),
            cancellationToken.ToRequestOptions());
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
    [Experimental("AAIP002")]
    public virtual ClientResult<RealtimeItem> GetAgentConversationItem(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

        ClientResult result = GetAgentConversationItem(agentName, conversationId, itemId, cancellationToken.ToRequestOptions());
        RealtimeItem item = ModelReaderWriter.Read<RealtimeItem>(result.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        return ClientResult.FromValue(item, result.GetRawResponse());
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
    [Experimental("AAIP002")]
    public virtual async Task<ClientResult<RealtimeItem>> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNullOrEmpty(itemId, nameof(itemId));

        ClientResult result = await GetAgentConversationItemAsync(agentName, conversationId, itemId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        RealtimeItem item = ModelReaderWriter.Read<RealtimeItem>(result.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        return ClientResult.FromValue(item, result.GetRawResponse());
    }
}
