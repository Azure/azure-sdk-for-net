// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Provides conversation operations for an Azure AI project through the OpenAI conversation API. </summary>
public partial class ProjectConversationsClient : ConversationClient
{
    /*
     * These convenience methods (returning strongly-typed response items) are temporary, pending strongly-typed convenience method support in the official OpenAI ConversationClient.
     */

    private readonly Uri _endpoint;

    /// <summary> Initializes a new instance of <see cref="ProjectConversationsClient"/>. </summary>
    /// <param name="pipeline"> The client pipeline used to send requests. </param>
    /// <param name="options"> The options used to configure the client. </param>
    public ProjectConversationsClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
        _endpoint = options.Endpoint;
    }

    /// <summary> Creates a project conversation. </summary>
    /// <param name="options"> The options used to create the conversation. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created project conversation. </returns>
    public virtual ClientResult<ProjectConversation> CreateProjectConversation(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = base.CreateConversation(BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default)), cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Asynchronously creates a project conversation. </summary>
    /// <param name="options"> The options used to create the conversation. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created project conversation. </returns>
    public virtual async Task<ClientResult<ProjectConversation>> CreateProjectConversationAsync(ProjectConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = await base.CreateConversationAsync(BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Gets the project conversations. </summary>
    /// <param name="agent">
    /// If provided, retrieves only conversations associated with the referenced agent.
    /// </param>
    /// <param name="limit">
    /// The maximum number of objects to return. The value can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// The sort order by the `created_at` timestamp of the objects. Use `asc` for ascending order and `desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A pagination cursor. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects ending with obj_foo, your
    /// subsequent call can include after=obj_foo to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A pagination cursor. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects ending with obj_foo, your
    /// subsequent call can include before=obj_foo to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project conversations. </returns>
    /// <exception cref="ClientResultException"> The service returned a non-success status code. </exception>
    public virtual CollectionResult<ProjectConversation> GetProjectConversations(AgentReference agent = null, int? limit = default, string order = null, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        string agentNameToUse = string.IsNullOrEmpty(agent?.Version) ? agent?.Name : null;
        string agentIdToUse = string.IsNullOrEmpty(agent?.Version) ? null : $"{agent?.Name}:{agent?.Version}";

        return new InternalOpenAICollectionResultOfT<ProjectConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectConversationsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    localRequestOptions),
            dataItemDeserializer: ProjectConversation.DeserializeProjectConversation,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentNameToUse, agentIdToUse]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Asynchronously gets the project conversations. </summary>
    /// <param name="agent">
    /// If provided, retrieves only conversations associated with the referenced agent.
    /// </param>
    /// <param name="limit">
    /// The maximum number of objects to return. The value can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// The sort order by the `created_at` timestamp of the objects. Use `asc` for ascending order and `desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A pagination cursor. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects ending with obj_foo, your
    /// subsequent call can include after=obj_foo to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A pagination cursor. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects ending with obj_foo, your
    /// subsequent call can include before=obj_foo to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project conversations. </returns>
    /// <exception cref="ClientResultException"> The service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<ProjectConversation> GetProjectConversationsAsync(AgentReference agent = null, int? limit = default, string order = null, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        string agentNameToUse = string.IsNullOrEmpty(agent?.Version) ? agent?.Name : null;
        string agentIdToUse = string.IsNullOrEmpty(agent?.Version) ? null : $"{agent?.Name}:{agent?.Version}";

        return new InternalOpenAIAsyncCollectionResultOfT<ProjectConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectConversationsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Filters.Count > 1 ? localCollectionOptions.Filters[1] : null,
                    localRequestOptions),
            dataItemDeserializer: ProjectConversation.DeserializeProjectConversation,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [agentNameToUse, agentIdToUse]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Gets a project conversation by ID. </summary>
    /// <param name="conversationId"> The ID of the conversation to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The requested project conversation. </returns>
    public virtual ClientResult<ProjectConversation> GetProjectConversation(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        ClientResult protocolResult = base.GetConversation(conversationId, cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Asynchronously gets a project conversation by ID. </summary>
    /// <param name="conversationId"> The ID of the conversation to retrieve. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The requested project conversation. </returns>
    public virtual async Task<ClientResult<ProjectConversation>> GetProjectConversationAsync(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        ClientResult protocolResult = await base.GetConversationAsync(conversationId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Gets the items in a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation whose items should be retrieved. </param>
    /// <param name="itemKind"> The item kind used to filter the returned items. </param>
    /// <param name="limit"> The maximum number of items to return. </param>
    /// <param name="order"> The order used to sort returned items. </param>
    /// <param name="after"> The item ID after which results should be returned. </param>
    /// <param name="before"> The item ID before which results should be returned. </param>
    /// <param name="include"> The additional item properties to include in the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project conversation items. </returns>
    public virtual CollectionResult<ResponseItem> GetProjectConversationItems(
        string conversationId,
        ResponseItemKind? itemKind = null,
        int? limit = null,
        string order = null,
        string after = null,
        string before = null,
        IEnumerable<IncludedConversationItemProperty> include = null,
        CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<ResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectConversationItemsRequest(
                    conversationId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Includes.Select(rawInclude => new IncludedConversationItemProperty(rawInclude)),
                    localRequestOptions),
            dataItemDeserializer: DeserializeResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order, after, before: before, filters: [itemKind?.ToString()], includes: include?.Select(includeProperty => includeProperty.ToString()) ?? []),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Asynchronously gets the items in a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation whose items should be retrieved. </param>
    /// <param name="itemKind"> The item kind used to filter the returned items. </param>
    /// <param name="limit"> The maximum number of items to return. </param>
    /// <param name="order"> The order used to sort returned items. </param>
    /// <param name="after"> The item ID after which results should be returned. </param>
    /// <param name="before"> The item ID before which results should be returned. </param>
    /// <param name="include"> The additional item properties to include in the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The project conversation items. </returns>
    public virtual AsyncCollectionResult<ResponseItem> GetProjectConversationItemsAsync(
        string conversationId,
        ResponseItemKind? itemKind = null,
        int? limit = null,
        string order = null,
        string after = null,
        string before = null,
        IEnumerable<IncludedConversationItemProperty> include = null,
        CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<ResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetProjectConversationItemsRequest(
                    conversationId,
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localCollectionOptions.Includes.Select(rawInclude => new IncludedConversationItemProperty(rawInclude)),
                    localRequestOptions),
            dataItemDeserializer: DeserializeResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order, after, before: before, filters: [itemKind?.ToString()], includes: include?.Select(includeProperty => includeProperty.ToString()) ?? []),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Gets a single item from a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation that contains the item. </param>
    /// <param name="itemId"> The ID of the item to retrieve. </param>
    /// <param name="include"> The additional item properties to include in the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The requested project conversation item. </returns>
    public virtual ClientResult<ResponseItem> GetProjectConversationItem(string conversationId, string itemId, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = GetConversationItem(conversationId, itemId, include, cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<ResponseItem>();
    }

    /// <summary> Asynchronously gets a single item from a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation that contains the item. </param>
    /// <param name="itemId"> The ID of the item to retrieve. </param>
    /// <param name="include"> The additional item properties to include in the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The requested project conversation item. </returns>
    public virtual async Task<ClientResult<ResponseItem>> GetProjectConversationItemAsync(string conversationId, string itemId, IEnumerable<IncludedConversationItemProperty> include = null, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await GetConversationItemAsync(conversationId, itemId, include, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<ResponseItem>();
    }

    /// <summary> Creates items in a conversation with the given ID. </summary>
    /// <param name="conversationId"> The ID of the conversation in which to create the items. </param>
    /// <param name="items"> The items to add to the conversation. You may add up to 20 items at a time. </param>
    /// <param name="include">
    /// Additional fields to include in the response.
    /// See the `include` parameter for listing conversation items for more information.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created conversation items. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> or <paramref name="items"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string when a non-empty value was expected. </exception>
    /// <exception cref="ClientResultException"> The service returned a non-success status code. </exception>
    public virtual ClientResult<ReadOnlyCollection<ResponseItem>> CreateProjectConversationItems(string conversationId, IEnumerable<ResponseItem> items, IEnumerable<IncludedConversationItemProperty> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        BinaryContent content = ResponseItemHelpers.GetItemsRequestContent(items);

        ClientResult protocolResult = base.CreateConversationItems(conversationId, content, include, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(new ReadOnlyCollection<ResponseItem>(
            InternalOpenAIPaginatedListResultOfT<ResponseItem>.DeserializeInternalOpenAIPaginatedListResultOfT(
                protocolResult,
                DeserializeResponseItem,
                ModelSerializationExtensions.WireOptions)),
            protocolResult.GetRawResponse());
    }

    /// <summary> Asynchronously creates items in a conversation with the given ID. </summary>
    /// <param name="conversationId"> The ID of the conversation in which to create the items. </param>
    /// <param name="items"> The items to add to the conversation. You may add up to 20 items at a time. </param>
    /// <param name="include">
    /// Additional fields to include in the response.
    /// See the `include` parameter for listing conversation items for more information.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created conversation items. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> or <paramref name="items"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string when a non-empty value was expected. </exception>
    /// <exception cref="ClientResultException"> The service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ReadOnlyCollection<ResponseItem>>> CreateProjectConversationItemsAsync(string conversationId, IEnumerable<ResponseItem> items, IEnumerable<IncludedConversationItemProperty> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        BinaryContent content = ResponseItemHelpers.GetItemsRequestContent(items);

        ClientResult protocolResult = await base.CreateConversationItemsAsync(conversationId, content, include, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(new ReadOnlyCollection<ResponseItem>(
            InternalOpenAIPaginatedListResultOfT<ResponseItem>.DeserializeInternalOpenAIPaginatedListResultOfT(
                protocolResult,
                DeserializeResponseItem,
                ModelSerializationExtensions.WireOptions)),
            protocolResult.GetRawResponse());
    }

    /// <summary> Updates a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation to update. </param>
    /// <param name="options"> The options containing the conversation updates. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The updated project conversation. </returns>
    public virtual ClientResult<ProjectConversation> UpdateProjectConversation(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = base.UpdateConversation(conversationId, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default)), cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Asynchronously updates a project conversation. </summary>
    /// <param name="conversationId"> The ID of the conversation to update. </param>
    /// <param name="options"> The options containing the conversation updates. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The updated project conversation. </returns>
    public virtual async Task<ClientResult<ProjectConversation>> UpdateProjectConversationAsync(string conversationId, ProjectConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        ClientResult protocolResult = await base.UpdateConversationAsync(conversationId, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<ProjectConversation>();
    }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationsClient"/> for mocking. </summary>
    protected ProjectConversationsClient()
    { }

    // CUSTOM: The OpenAI SDK's ResponseItem.DeserializeResponseItem is internal and inaccessible from this
    // assembly, so deserialize through the public ModelReaderWriter pipeline (which honors the type's
    // discriminator) to materialize the correct ResponseItem subtype.
    private static ResponseItem DeserializeResponseItem(JsonElement element, ModelReaderWriterOptions options)
        => ModelReaderWriter.Read<ResponseItem>(
            BinaryData.FromString(element.GetRawText()),
            options,
            OpenAIContext.Default);
}
