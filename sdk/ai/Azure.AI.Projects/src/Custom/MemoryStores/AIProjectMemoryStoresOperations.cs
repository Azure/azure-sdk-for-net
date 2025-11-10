// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects;

[CodeGenSuppress("SearchMemories", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(MemorySearchResultOptions), typeof(CancellationToken))]
[CodeGenSuppress("SearchMemoriesAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(MemorySearchResultOptions), typeof(CancellationToken))]
[CodeGenSuppress("UpdateMemories", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("UpdateMemoriesAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InternalItemParam>), typeof(string), typeof(int?), typeof(CancellationToken))]
[CodeGenSuppress("GetMemoryStores", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetMemoryStoresAsync", typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenType("MemoryStores")]
public partial class AIProjectMemoryStoresOperations
{
    /// <summary> Search for relevant memories from a memory store based on conversation context. </summary>
    /// <param name="memoryStoreName"> The ID of the memory store to search. </param>
    /// <param name="options"> Memory search options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="memoryStoreName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="memoryStoreName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<MemoryStoreSearchResponse> SearchMemories(string memoryStoreName, MemorySearchOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreName, nameof(memoryStoreName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = SearchMemories(memoryStoreName, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsContext.Default)), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((MemoryStoreSearchResponse)result, result.GetRawResponse());
    }

    /// <summary> Search for relevant memories from a memory store based on conversation context. </summary>
    /// <param name="memoryStoreName"> The ID of the memory store to search. </param>
    /// <param name="options"> Memory search options. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="memoryStoreName"/> or <paramref name="options"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="memoryStoreName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<MemoryStoreSearchResponse>> SearchMemoriesAsync(string memoryStoreName, MemorySearchOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreName, nameof(memoryStoreName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult result = await SearchMemoriesAsync(memoryStoreName, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsContext.Default)), cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
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
    public virtual CollectionResult<MemoryStore> GetMemoryStores(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<MemoryStore>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetMemoryStoresRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: MemoryStore.DeserializeMemoryStore,
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
    public virtual AsyncCollectionResult<MemoryStore> GetMemoryStoresAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<MemoryStore>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetMemoryStoresRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: MemoryStore.DeserializeMemoryStore,
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    public virtual async Task<ClientResult<MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreName, MemoryUpdateOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreName, nameof(memoryStoreName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = await UpdateMemoriesAsync(memoryStoreName, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsContext.Default)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }

    public virtual ClientResult<MemoryUpdateResult> UpdateMemories(string memoryStoreName, MemoryUpdateOptions options, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(memoryStoreName, nameof(memoryStoreName));
        Argument.AssertNotNull(options, nameof(options));

        ClientResult protocolResult = UpdateMemories(memoryStoreName, BinaryContent.Create(ModelReaderWriter.Write(options, ModelSerializationExtensions.WireOptions, AzureAIProjectsContext.Default)), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((MemoryUpdateResult)protocolResult, protocolResult.GetRawResponse());
    }
}
