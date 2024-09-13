// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreFileBatchesPageEnumerator : VectorStoreFileBatchesPageEnumerator
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    public AzureVectorStoreFileBatchesPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, vectorStoreId, batchId, limit, order, after, before, filter, options)
    {
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }

    internal override async Task<ClientResult> GetFileAssociationsAsync(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetFileAssociations(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private new PipelineMessage CreateGetFilesInVectorStoreBatchesRequest(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithAssistantsHeader()
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithOptionalQueryParameter("filter", filter)
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "files")
            .Build();
}
