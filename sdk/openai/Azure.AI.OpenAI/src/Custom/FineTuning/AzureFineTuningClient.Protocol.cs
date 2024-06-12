// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.FineTuning;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text;

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningClient : FineTuningClient
{
    public override ClientResult CreateJob(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateJobRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateJobAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateCreateJobRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    public override ClientResult GetJob(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetJobAsync(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    public override ClientResult GetJobs(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobsRequestMessage(after, limit, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobsRequestMessage(after, limit, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    public override ClientResult GetJobEvents(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobEventsRequestMessage(fineTuningJobId, after, limit, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetJobEventsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetJobEventsRequestMessage(fineTuningJobId, after, limit, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    public override ClientResult CancelJob(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateCancelJobRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelJobAsync(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateCancelJobRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateCreateJobRequestMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("fine_tuning")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetJobsRequestMessage(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetJobRequestMessage(string jobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", jobId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetJobEventsRequestMessage(string jobId, string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", jobId, "events")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCancelJobRequestMessage(string jobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("fine_tuning", jobId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
