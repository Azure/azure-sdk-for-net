// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Agents;

[CodeGenSuppress("SearchMemories", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(MemorySearchOptions), typeof(CancellationToken))]
[CodeGenSuppress("SearchMemoriesAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(MemorySearchOptions), typeof(CancellationToken))]
[CodeGenSuppress("UpdateMemories", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("UpdateMemoriesAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("GetMemoryStores", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetMemoryStoresAsync", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenType("MemoryStores")]
public partial class MemoryStoreClient
{
    /// <summary> Search for relevant memories from a memory store based on conversation context. </summary>
    /// <param name="memoryStoreId"> The ID of the memory store to search. </param>
    /// <param name="scope"> The namespace that logically groups and isolates memories, such as a user ID. </param>
    /// <param name="options"> Memory search options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="memoryStoreId"/> or <paramref name="scope"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="memoryStoreId"/> or <paramref name="scope"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<MemoryStoreSearchResponse> SearchMemories(string memoryStoreId, string scope, MemorySearchOptions options = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));

        InternalSearchMemoriesRequest spreadModel = new(
            scope,
            default,
            options?.Items ?? new ChangeTrackingList<OpenAI.Responses.ResponseItem>(),
            default,
            options,
            default);
        ClientResult result = SearchMemories(memoryStoreId, spreadModel, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null);
        return ClientResult.FromValue((MemoryStoreSearchResponse)result, result.GetRawResponse());
    }

    /// <summary> Search for relevant memories from a memory store based on conversation context. </summary>
    /// <param name="memoryStoreId"> The ID of the memory store to search. </param>
    /// <param name="scope"> The namespace that logically groups and isolates memories, such as a user ID. </param>
    /// <param name="options"> Memory search options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="memoryStoreId"/> or <paramref name="scope"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="memoryStoreId"/> or <paramref name="scope"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<MemoryStoreSearchResponse>> SearchMemoriesAsync(string memoryStoreId, string scope, MemorySearchOptions options = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));

        InternalSearchMemoriesRequest spreadModel = new(
            scope,
            default,
            options?.Items ?? new ChangeTrackingList<OpenAI.Responses.ResponseItem>(),
            default,
            options,
            default);
        ClientResult result = await SearchMemoriesAsync(memoryStoreId, spreadModel, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
        return ClientResult.FromValue((MemoryStoreSearchResponse)result, result.GetRawResponse());
    }

    /// <summary> List all memory stores. </summary>
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
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<MemoryStoreObject> GetMemoryStores(int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<MemoryStoreObject>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetMemoryStoresRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: MemoryStoreObject.DeserializeMemoryStoreObject,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List all memory stores. </summary>
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
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<MemoryStoreObject> GetMemoryStoresAsync(int? limit = default, AgentsListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<MemoryStoreObject>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetMemoryStoresRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: MemoryStoreObject.DeserializeMemoryStoreObject,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    public virtual async Task<ClientResult<MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreId, string scope, IEnumerable<OpenAI.Responses.ResponseItem> items, MemoryUpdateOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));
        Argument.AssertNotNull(options, nameof(options));

        MemoryUpdateOptions requestContent = CreatePerCallOptions(options, scope, conversationId: null, items);
        ClientResult protocolResult = await UpdateMemoriesAsync(memoryStoreId, requestContent, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }

    public virtual async Task<ClientResult<MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreId, string scope, string conversationId, MemoryUpdateOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));
        Argument.AssertNotNull(options, nameof(options));

        MemoryUpdateOptions requestContent = CreatePerCallOptions(options, scope, conversationId, items: null);
        ClientResult protocolResult = await UpdateMemoriesAsync(memoryStoreId, requestContent, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }

    public virtual ClientResult<MemoryUpdateResult> UpdateMemories(string memoryStoreId, string scope, IEnumerable<OpenAI.Responses.ResponseItem> items, MemoryUpdateOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));
        Argument.AssertNotNull(options, nameof(options));

        MemoryUpdateOptions requestContent = CreatePerCallOptions(options, scope, conversationId: null, items);
        ClientResult protocolResult = UpdateMemories(memoryStoreId, requestContent, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }

    public virtual ClientResult<MemoryUpdateResult> UpdateMemories(string memoryStoreId, string scope, string conversationId, MemoryUpdateOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreId, nameof(memoryStoreId));
        Argument.AssertNotNullOrEmpty(scope, nameof(scope));
        Argument.AssertNotNull(options, nameof(options));

        MemoryUpdateOptions requestContent = CreatePerCallOptions(options, scope, conversationId, items: null);
        ClientResult protocolResult = UpdateMemories(memoryStoreId, requestContent, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }

    internal virtual MemoryUpdateOptions CreatePerCallOptions(MemoryUpdateOptions userOptions, string scope, string conversationId, IEnumerable<OpenAI.Responses.ResponseItem> items)
    {
        MemoryUpdateOptions copiedOptions = userOptions is null ? new() : userOptions.GetClone();
        copiedOptions.Scope = scope;
        copiedOptions.ConversationId = conversationId;
        copiedOptions.Items = new ChangeTrackingList<OpenAI.Responses.ResponseItem>();
        foreach (OpenAI.Responses.ResponseItem item in items ?? [])
        {
            copiedOptions.Items.Add(item);
        }

        return copiedOptions;
    }
}
