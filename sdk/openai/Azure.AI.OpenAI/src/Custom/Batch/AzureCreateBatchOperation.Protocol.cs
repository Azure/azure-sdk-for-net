﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable

namespace Azure.AI.OpenAI.Batch;

/// <summary>
/// A long-running operation for executing a batch from an uploaded file of requests.
/// </summary>
internal partial class AzureCreateBatchOperation : CreateBatchOperation
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _batchId;

    private readonly string _deploymentName;
    private readonly string _apiVersion;

    internal AzureCreateBatchOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        string batchId,
        string status,
        PipelineResponse response,
        string deploymentName,
        string apiVersion)
        : base(pipeline, endpoint, batchId, status, response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _batchId = batchId;
        _deploymentName = deploymentName;
        _apiVersion = apiVersion;
    }

    internal override PipelineMessage CreateRetrieveBatchRequest(string batchId, RequestOptions? options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("GET")
            .WithPath("batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCancelBatchRequest(string batchId, RequestOptions? options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private static PipelineMessageClassifier? _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}

#endif
