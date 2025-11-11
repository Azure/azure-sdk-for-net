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
using Azure.Core;

namespace Azure.AI.Agents;

[CodeGenSuppress("CreateConversation", typeof(IDictionary<string, string>), typeof(IEnumerable<InternalItemParam>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationAsync", typeof(IDictionary<string, string>), typeof(IEnumerable<InternalItemParam>), typeof(CancellationToken))]
[CodeGenSuppress("UpdateConversation", typeof(string), typeof(IDictionary<string, string>), typeof(CancellationToken))]
[CodeGenSuppress("UpdateConversationAsync", typeof(string), typeof(IDictionary<string, string>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationItems", typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(IEnumerable<string>), typeof(CancellationToken))]
[CodeGenSuppress("CreateConversationItemsAsync", typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(IEnumerable<string>), typeof(CancellationToken))]
[CodeGenSuppress("GetConversations", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetConversationsAsync", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetConversationItems", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetConversationItemsAsync", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenType("Conversations")]
public partial class ConversationClient
{
    public virtual ClientResult<AgentConversation> CreateConversation(AgentConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = CreateConversation(BinaryContent.Create(options), cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    public virtual async Task<ClientResult<AgentConversation>> CreateConversationAsync(AgentConversationCreationOptions options = null, CancellationToken cancellationToken = default)
    {
        options ??= new();
        ClientResult protocolResult = await CreateConversationAsync(options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    /// <summary> Update a conversation. </summary>
    /// <param name="conversationId"> The id of the conversation to update. </param>
    /// <param name="options"> The options describing the updates to perform to the specified conversation. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentConversation> UpdateConversation(string conversationId, AgentConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = UpdateConversation(conversationId, options, cancellationToken.ToRequestOptions());
        return protocolResult.ToAgentClientResult<AgentConversation>();
    }

    /// <summary> Update a conversation. </summary>
    /// <param name="conversationId"> The id of the conversation to update. </param>
    /// <param name="options"> The options describing the updates to perform to the specified conversation. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentConversation>> UpdateConversationAsync(string conversationId, AgentConversationUpdateOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = await UpdateConversationAsync(conversationId, options, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
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
    public virtual CollectionResult<AgentConversation> GetConversations(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, string agentName = default, string agentId = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<AgentConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetConversationsRequest(
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
    public virtual AsyncCollectionResult<AgentConversation> GetConversationsAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, string agentName = default, string agentId = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<AgentConversation>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetConversationsRequest(
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
    public virtual ClientResult<ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateConversationItems(string conversationId, IEnumerable<OpenAI.Responses.ResponseItem> items, IEnumerable<string> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNull(items, nameof(items));

        IEnumerable<AgentResponseItem> convertedAgentItems = items.Select(responseItem => responseItem.AsAgentResponseItem());
        CreateConversationItemsRequest spreadModel = new(convertedAgentItems);

        var pseudoPaginatedResult = new InternalOpenAICollectionResultOfT<OpenAI.Responses.ResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateCreateConversationItemsRequest(
                    localCollectionOptions.ParentResourceId,
                    spreadModel,
                    localCollectionOptions.Includes,
                    localRequestOptions),
            dataItemDeserializer: (element, writerOptions) => AgentResponseItem.DeserializeAgentResponseItem(element, writerOptions).AsOpenAIResponseItem(),
            new InternalOpenAICollectionResultOptions(includes: include)
            {
                ParentResourceId = conversationId,
            },
            cancellationToken.ToRequestOptions());

        ClientResult pageResult = pseudoPaginatedResult.GetRawPages().First();
        return ClientResult.FromValue(pseudoPaginatedResult.GetDataFromPage(pageResult), pageResult.GetRawResponse());
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
    public virtual async Task<ClientResult<ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateConversationItemsAsync(string conversationId, IEnumerable<OpenAI.Responses.ResponseItem> items, IEnumerable<string> include = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));
        Argument.AssertNotNull(items, nameof(items));

        IEnumerable<AgentResponseItem> convertedAgentItems = items.Select(responseItem => responseItem.AsAgentResponseItem());
        CreateConversationItemsRequest spreadModel = new(convertedAgentItems);

        var pseudoPaginatedResult = new InternalOpenAIAsyncCollectionResultOfT<OpenAI.Responses.ResponseItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateCreateConversationItemsRequest(
                    localCollectionOptions.ParentResourceId,
                    spreadModel,
                    localCollectionOptions.Includes,
                    localRequestOptions),
            dataItemDeserializer: (element, writerOptions) => AgentResponseItem.DeserializeAgentResponseItem(element, writerOptions).AsOpenAIResponseItem(),
            new InternalOpenAICollectionResultOptions(includes: include)
            {
                ParentResourceId = conversationId,
            },
            cancellationToken.ToRequestOptions());

        ClientResult pageResult = null;
        await foreach (ClientResult singlePageResult in pseudoPaginatedResult.GetRawPagesAsync().ConfigureAwait(false))
        {
            pageResult = singlePageResult;
            break;
        }
        return ClientResult.FromValue(pseudoPaginatedResult.GetDataFromPage(pageResult), pageResult.GetRawResponse());
    }

    /// <summary> List all items for a conversation with the given ID. </summary>
    /// <param name="conversationId"> The id of the conversation on which the items needs to be listed. </param>
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
    /// <param name="itemType"> Filter by item type. If provided, only items of the specified type will be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentResponseItem> GetConversationItems(string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentResponseItemKind? itemType = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAICollectionResultOfT<AgentResponseItem>(
            Pipeline,
            messageGenerator: (localConfiguration, localRequestOptions)
                => CreateGetConversationItemsRequest(
                    localConfiguration.ParentResourceId,
                    localConfiguration.Limit,
                    localConfiguration.Order,
                    localConfiguration.AfterId,
                    localConfiguration.BeforeId,
                    localConfiguration.Filters.Count > 0 ? localConfiguration.Filters[0] : null,
                    localRequestOptions),
            dataItemDeserializer: AgentResponseItem.DeserializeAgentResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, [itemType?.ToString()])
            {
                ParentResourceId = conversationId,
            },
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List all items for a conversation with the given ID. </summary>
    /// <param name="conversationId"> The id of the conversation on which the items needs to be listed. </param>
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
    /// <param name="itemType"> Filter by item type. If provided, only items of the specified type will be returned. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentResponseItem> GetConversationItemsAsync(string conversationId, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, AgentResponseItemKind? itemType = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        return new InternalOpenAIAsyncCollectionResultOfT<AgentResponseItem>(
            Pipeline,
            messageGenerator: (localConfiguration, localRequestOptions)
                => CreateGetConversationItemsRequest(
                    localConfiguration.ParentResourceId,
                    localConfiguration.Limit,
                    localConfiguration.Order,
                    localConfiguration.AfterId,
                    localConfiguration.BeforeId,
                    localConfiguration.Filters.Count > 0 ? localConfiguration.Filters[0] : null,
                    localRequestOptions),
            dataItemDeserializer: AgentResponseItem.DeserializeAgentResponseItem,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, [itemType?.ToString()])
            {
                ParentResourceId = conversationId,
            },
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Deletes a conversation. </summary>
    /// <param name="conversationId"> The id of the conversation to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult DeleteConversation(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        ClientResult result = DeleteConversation(conversationId, cancellationToken.ToRequestOptions());
        return result;
    }

    /// <summary> Deletes a conversation. </summary>
    /// <param name="conversationId"> The id of the conversation to delete. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="conversationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="conversationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteConversationAsync(string conversationId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(conversationId, nameof(conversationId));

        ClientResult result = await DeleteConversationAsync(conversationId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result;
    }
}
