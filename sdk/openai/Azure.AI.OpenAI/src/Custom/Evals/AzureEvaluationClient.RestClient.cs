// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Evals;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Evals;

internal partial class AzureEvaluationClient : EvaluationClient
{
    internal override PipelineMessage CreateCancelEvalRunRequest(string evalId, string runId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"evals/{evalId}/runs/{runId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateEvalRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"evals")
            .WithAccept("application/json")
            .WithContent(content, "application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateEvalRunRequest(string evalId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"evals/{evalId}/runs")
            .WithAccept("application/json")
            .WithContent(content, "application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteEvalRequest(string evalId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath($"evals/{evalId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteEvalRunRequest(string evalId, string runId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath($"evals/{evalId}/runs/{runId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalRequest(string evalId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath($"evals/{evalId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalRunOutputItemRequest(string evalId, string runId, string outputItemId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath($"evals/{evalId}/runs/{runId}/output_items/{outputItemId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalRunOutputItemsRequest(string evalId, string runId, string after, int? limit, string status, string order, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath($"evals/{evalId}/runs/{runId}/output_items")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("status", status)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalRunRequest(string evalId, string runId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"evals/{evalId}/runs/{runId}")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalRunsRequest(string evalId, string after, int? limit, string order, string status, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath($"evals/{evalId}/runs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("status", status)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetEvalsRequest(string after, int? limit, string order, string orderBy, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath($"evals")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("order_by", orderBy)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateUpdateEvalRequest(string evalId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath($"evals/{evalId}")
            .WithAccept("application/json")
            .WithContent(content, "application/json")
            .WithOptions(options)
            .Build();
}