// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.AI.OpenAI.Utility;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreClient : VectorStoreClient
{
    public override AsyncCollectionResult GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<VectorStore, VectorStoreCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetVectorStoresRequest(limit, order, continuation?.After ?? after, before, options),
            page => VectorStoreCollectionPageToken.FromResponse(page, limit, order, before),
            page => ModelReaderWriter.Read<InternalListVectorStoresResponse>(page.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default).Data,
            options?.CancellationToken ?? default);
    }

    public override CollectionResult GetVectorStores(int? limit, string order, string after, string before, RequestOptions options)
    {
        return new AzureCollectionResult<VectorStore, VectorStoreCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetVectorStoresRequest(limit, order, continuation?.After ?? after, before, options),
            page => VectorStoreCollectionPageToken.FromResponse(page, limit, order, before),
            page => ModelReaderWriter.Read<InternalListVectorStoresResponse>(page.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default).Data);
    }

    public override AsyncCollectionResult GetFileAssociationsAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        return new AzureAsyncCollectionResult<VectorStoreFileAssociation, VectorStoreFileCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, continuation?.After ?? after, before, filter, options),
            page => VectorStoreFileCollectionPageToken.FromResponse(page, vectorStoreId, limit, order, before, filter),
            page => ModelReaderWriter.Read<InternalListVectorStoreFilesResponse>(page.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default).Data,
            options?.CancellationToken ?? default);
    }

    public override CollectionResult GetFileAssociations(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        return new AzureCollectionResult<VectorStoreFileAssociation, VectorStoreFileCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, continuation?.After ?? after, before, filter, options),
            page => VectorStoreFileCollectionPageToken.FromResponse(page, vectorStoreId, limit, order, before, filter),
            page => ModelReaderWriter.Read<InternalListVectorStoreFilesResponse>(page.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default).Data);
    }

    internal override PipelineMessage CreateGetVectorStoresRequest(int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithPath("vector_stores")
            .Build();

    internal override PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateModifyVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId)
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetVectorStoreFilesRequest(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithOptionalQueryParameter("filter", filter)
            .WithPath("vector_stores", vectorStoreId, "files")
            .Build();

    internal override PipelineMessage CreateCreateVectorStoreFileRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateRemoveFileFromStoreRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetFileAssociationRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
        .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateVectorStoreRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateVectorStoreFileBatchRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCancelBatchFileJobRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetFilesInVectorStoreBatchRequest(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithOptionalQueryParameter("filter", filter)
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "files")
            .Build();

    internal override PipelineMessage CreateRetrieveVectorStoreFileContentRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId, "content")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateSearchVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "search")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateUpdateVectorStoreFileAttributesRequest(string vectorStoreId, string fileId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}

#endif
