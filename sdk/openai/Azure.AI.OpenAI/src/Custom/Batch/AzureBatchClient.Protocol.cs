// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Batch;

namespace Azure.AI.OpenAI.Batch;

internal partial class AzureBatchClient : BatchClient
{
    internal override PipelineMessage CreateCreateBatchRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, null)
            .WithMethod("POST")
            .WithPath("batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetBatchesRequest(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, null)
            .WithMethod("GET")
            .WithPath("batches")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, null)
            .WithMethod("GET")
            .WithPath("batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCancelBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, null)
            .WithMethod("POST")
            .WithPath("batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}