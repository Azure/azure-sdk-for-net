// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreClient : VectorStoreClient
{
    public override async Task<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStores(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateVectorStoreAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateVectorStoreRequest(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateVectorStore(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateVectorStoreRequest(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStore(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> ModifyVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyVectorStoreRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult ModifyVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyVectorStoreRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> DeleteVectorStoreAsync(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateDeleteVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult DeleteVectorStore(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateDeleteVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetFileAssociationsAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetFileAssociations(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> AddFileToVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult AddFileToVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetFileAssociationAsync(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetFileAssociation(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult RemoveFileFromStore(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateBatchFileJobAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateBatchFileJob(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetBatchFileJob(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CancelBatchFileJob(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetFileAssociationsAsync(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetFileAssociations(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private new PipelineMessage CreateGetVectorStoresRequest(int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCreateVectorStoreRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateModifyVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId)
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateDeleteVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetVectorStoreFilesRequest(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithOptionalQueryParameter("filter", filter)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCreateVectorStoreFileRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateDeleteVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCreateVectorStoreFileBatchRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCancelVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetFilesInVectorStoreBatchesRequest(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "files")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithOptionalQueryParameter("filter", filter)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
