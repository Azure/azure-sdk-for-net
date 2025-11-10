// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIConversationClient : ConversationClient
{
    /*
     * These convenience methods (returning strongly-typed response items) are temporary, pending strongly-typed convenience method support in the official OpenAI ConversationClient.
     */

    private readonly Uri _endpoint;

    public ProjectOpenAIConversationClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
        _endpoint = options.Endpoint;
    }

    public virtual ClientResult<AgentConversation> CreateAgentConversation(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = base.CreateConversation(BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default)), cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    public virtual async Task<ClientResult<AgentConversation>> CreateAgentConversationAsync(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = await base.CreateConversationAsync(BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    /// <summary> Returns the list of all conversations. </summary>
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
    /// <param name="agentName"> Filter by agent name. If provided, only items associated with the specified agent will be returned. </param>
    /// <param name="agentId"> Filter by agent ID in the format `name:version`. If provided, only items associated with the specified agent ID will be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentConversation> GetAgentConversations(int? limit = default, string order = null, string after = default, string before = default, string agentName = default, string agentId = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<AgentConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    localRequestOptions),
            dataItemDeserializer: AgentConversation.DeserializeAgentConversation,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, agentId]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the list of all conversations. </summary>
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
    /// <param name="agentName"> Filter by agent name. If provided, only items associated with the specified agent will be returned. </param>
    /// <param name="agentId"> Filter by agent ID in the format `name:version`. If provided, only items associated with the specified agent ID will be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentConversation> GetAgentConversationsAsync(int? limit = default, string order = null, string after = default, string before = default, string agentName = default, string agentId = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<AgentConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    localRequestOptions),
            dataItemDeserializer: AgentConversation.DeserializeAgentConversation,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentName, agentId]),
            cancellationToken.ToRequestOptions());
    }

    public virtual ClientResult<AgentConversation> GetAgentConversation(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        ClientResult protocolResult = base.GetConversation(conversationId, cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    public virtual async Task<ClientResult<AgentConversation>> GetAgentConversationAsync(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        ClientResult protocolResult = await base.GetConversationAsync(conversationId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    public virtual CollectionResult<AgentResponseItem> GetAgentConversationItems(
        string conversationId,
        int? limit = null,
        string order = null,
        string after = null,
        IEnumerable<IncludedConversationItemProperty> include = null,
        CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<AgentResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationItemsRequest(
                    conversationId,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.Filters.Select(rawFilter => new IncludedConversationItemProperty(rawFilter)),
                    localRequestOptions),
            dataItemDeserializer: AgentResponseItem.DeserializeAgentResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before: null, filters: include?.Select(includeProperty => includeProperty.ToString()) ?? []),
            cancellationToken.ToRequestOptions());
    }

    public virtual AsyncCollectionResult<AgentResponseItem> GetAgentConversationItemsAsync(
        string conversationId,
        int? limit = null,
        string order = null,
        string after = null,
        IEnumerable<IncludedConversationItemProperty> include = null,
        CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<AgentResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetAgentConversationItemsRequest(
                    conversationId,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.Filters.Select(rawFilter => new IncludedConversationItemProperty(rawFilter)),
                    localRequestOptions),
            dataItemDeserializer: AgentResponseItem.DeserializeAgentResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before: null, filters: include?.Select(includeProperty => includeProperty.ToString()) ?? []),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Create items in a conversation with the given ID. </summary>
    /// <param name="conversationId"> The id of the conversation on which the item needs to be created. </param>
    /// <param name="items"> The items to add to the conversation. You may add up to 20 items at a time. </param>
    /// <param name="include">
    /// Additional fields to include in the response.
    /// See the `include` parameter for listing Conversation items for more information.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> or <paramref name="items"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ReadOnlyCollection<ResponseItem>> CreateAgentConversationItems(string conversationId, IEnumerable<ResponseItem> items, IEnumerable<IncludedConversationItemProperty> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        BinaryContent content = ResponseItemHelpers.GetItemsRequestContent(items);

        ClientResult protocolResult = base.CreateConversationItems(conversationId, content, include, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(new ReadOnlyCollection<ResponseItem>(
            InternalOpenAIPaginatedListResultOfT<ResponseItem>.DeserializeInternalOpenAIPaginatedListResultOfT(
                protocolResult,
                (element, options) => AgentResponseItem.DeserializeAgentResponseItem(element, options).AsOpenAIResponseItem(),
                ModelSerializationExtensions.WireOptions)),
            protocolResult.GetRawResponse());
    }

    /// <summary> Create items in a conversation with the given ID. </summary>
    /// <param name="conversationId"> The id of the conversation on which the item needs to be created. </param>
    /// <param name="items"> The items to add to the conversation. You may add up to 20 items at a time. </param>
    /// <param name="include">
    /// Additional fields to include in the response.
    /// See the `include` parameter for listing Conversation items for more information.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> or <paramref name="items"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ReadOnlyCollection<ResponseItem>>> CreateAgentConversationItemsAsync(string conversationId, IEnumerable<ResponseItem> items, IEnumerable<IncludedConversationItemProperty> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        BinaryContent content = ResponseItemHelpers.GetItemsRequestContent(items);

        ClientResult protocolResult = await base.CreateConversationItemsAsync(conversationId, content, include, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(new ReadOnlyCollection<ResponseItem>(
            InternalOpenAIPaginatedListResultOfT<ResponseItem>.DeserializeInternalOpenAIPaginatedListResultOfT(
                protocolResult,
                (element, options) => AgentResponseItem.DeserializeAgentResponseItem(element, options).AsOpenAIResponseItem(),
                ModelSerializationExtensions.WireOptions)),
            protocolResult.GetRawResponse());
    }

    public virtual ClientResult<AgentConversation> UpdateAgentConversation(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = base.UpdateConversation(conversationId, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default)), cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    public virtual async Task<ClientResult<AgentConversation>> UpdateAgentConversationAsync(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await base.UpdateConversationAsync(conversationId, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsOpenAIContext.Default)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    protected ProjectOpenAIConversationClient()
    { }
}
