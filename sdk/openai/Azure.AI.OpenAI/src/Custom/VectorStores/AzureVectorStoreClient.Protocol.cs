﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using Azure.AI.OpenAI.Utility;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreClient : VectorStoreClient
{
    public override AsyncCollectionResult<VectorStore> GetVectorStoresAsync(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        return new AzureAsyncCollectionResult<VectorStore, VectorStoreCollectionPageToken>(
            Pipeline,
            continuation => CreateGetVectorStoresRequest(options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => VectorStoreCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListVectorStoresResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<VectorStore> GetVectorStores(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        return new AzureCollectionResult<VectorStore, VectorStoreCollectionPageToken>(
            Pipeline,
            continuation => CreateGetVectorStoresRequest(options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions()),
            page => VectorStoreCollectionPageToken.FromResponse(page, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId),
            page => ModelReaderWriter.Read<InternalListVectorStoresResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override AsyncCollectionResult<VectorStoreFile> GetVectorStoreFilesAsync(string vectorStoreId, VectorStoreFileCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        return new AzureAsyncCollectionResult<VectorStoreFile, VectorStoreFileCollectionPageToken>(
            Pipeline,
            continuation => CreateGetVectorStoreFilesRequest(vectorStoreId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, options?.BeforeId, options?.Filter.ToString(), cancellationToken.ToRequestOptions()),
            page => VectorStoreFileCollectionPageToken.FromResponse(page, vectorStoreId, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId, options?.Filter.ToString()),
            page => ModelReaderWriter.Read<InternalListVectorStoreFilesResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
    }

    public override CollectionResult<VectorStoreFile> GetVectorStoreFiles(string vectorStoreId, VectorStoreFileCollectionOptions options = null, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        return new AzureCollectionResult<VectorStoreFile, VectorStoreFileCollectionPageToken>(
            Pipeline,
            continuation => CreateGetVectorStoreFilesRequest(vectorStoreId, options?.PageSizeLimit, options?.Order.ToString(), continuation?.After ?? options?.AfterId, options?.BeforeId, options?.Filter.ToString(), cancellationToken.ToRequestOptions()),
            page => VectorStoreFileCollectionPageToken.FromResponse(page, vectorStoreId, options?.PageSizeLimit, options?.Order.ToString(), options?.BeforeId, options?.Filter.ToString()),
            page => ModelReaderWriter.Read<InternalListVectorStoreFilesResponse>(page.GetRawResponse().Content).Data,
            cancellationToken);
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

    internal override PipelineMessage CreateAddFileToVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateRemoveFileFromVectorStoreRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
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

    internal override PipelineMessage CreateAddFileBatchToVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
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

    internal override PipelineMessage CreateCancelVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetVectorStoreFilesInBatchRequest(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
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
