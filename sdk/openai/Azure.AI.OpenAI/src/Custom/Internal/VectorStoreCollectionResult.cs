// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

#nullable enable

namespace Azure.AI.OpenAI.VectorStores;

internal class VectorStoreCollectionResult : CollectionResult<VectorStore>
{
    private readonly VectorStoreClient _vectorStoreClient;
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions? _options;

    // Initial values
    private readonly int? _limit;
    private readonly string? _order;
    private readonly string? _after;
    private readonly string? _before;

    public VectorStoreCollectionResult(VectorStoreClient vectorStoreClient,
        ClientPipeline pipeline, RequestOptions? options,
        int? limit, string? order, string? after, string? before)
    {
        _vectorStoreClient = vectorStoreClient;
        _pipeline = pipeline;
        _options = options;

        _limit = limit;
        _order = order;
        _after = after;
        _before = before;
    }

    public override IEnumerable<ClientResult> GetRawPages()
    {
        ClientResult page = GetFirstPage();
        yield return page;

        while (HasNextPage(page))
        {
            page = GetNextPage(page);
            yield return page;
        }
    }

    protected override IEnumerable<VectorStore> GetValuesFromPage(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));

        PipelineResponse response = page.GetRawResponse();
        InternalListVectorStoresResponse list = ModelReaderWriter.Read<InternalListVectorStoresResponse>(response.Content, ModelReaderWriterOptions.Json, OpenAIContext.Default)!;
        return list.Data;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));

        return VectorStoreCollectionPageToken.FromResponse(page, _limit, _order, _before);
    }

    public ClientResult GetFirstPage()
        => GetVectorStores(_limit, _order, _after, _before, _options);

    public ClientResult GetNextPage(ClientResult result)
    {
        Argument.AssertNotNull(result, nameof(result));

        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("last_id"u8).GetString()!;

        return GetVectorStores(_limit, _order, lastId, _before, _options);
    }

    public static bool HasNextPage(ClientResult result)
    {
        Argument.AssertNotNull(result, nameof(result));

        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        return hasMore;
    }

    internal virtual ClientResult GetVectorStores(int? limit, string? order, string? after, string? before, RequestOptions? options)
    {
        using PipelineMessage message = _vectorStoreClient.CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }
}
