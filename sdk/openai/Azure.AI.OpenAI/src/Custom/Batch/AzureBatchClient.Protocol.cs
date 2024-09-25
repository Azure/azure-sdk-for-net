// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.AI.OpenAI.Utility;

namespace Azure.AI.OpenAI.Batch;

internal partial class AzureBatchClient : BatchClient
{
    public override async Task<ClientResult> CreateBatchAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateBatchRequest(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateBatch(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateBatchRequest(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override AsyncCollectionResult GetBatchesAsync(string after, int? limit, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<object, BatchCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetBatchesRequest(continuation?.After ?? after, limit, options),
            page => BatchCollectionPageToken.FromResponse(page, limit),
            page => throw new NotImplementedException("Parsing has not yet been implemented"),
            options?.CancellationToken ?? default);
    }

    public override CollectionResult GetBatches(string after, int? limit, RequestOptions options)
    {
        return new AzureCollectionResult<object, BatchCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetBatchesRequest(continuation?.After ?? after, limit, options),
            page => BatchCollectionPageToken.FromResponse(page, limit),
            page => throw new NotImplementedException("Parsing has not yet been implemented"));
    }

    public override async Task<ClientResult> GetBatchAsync(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateRetrieveBatchRequest(batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetBatch(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateRetrieveBatchRequest(batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelBatchAsync(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelBatchRequest(batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CancelBatch(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelBatchRequest(batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private new PipelineMessage CreateCreateBatchRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetBatchesRequest(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("GET")
            .WithPath("batches")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateRetrieveBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("GET")
            .WithPath("batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCancelBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
