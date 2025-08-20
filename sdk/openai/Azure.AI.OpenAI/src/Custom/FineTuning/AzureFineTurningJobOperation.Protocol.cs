// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

#if !AZURE_OPENAI_GA

#nullable enable

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
[Experimental("OPENAI001")]
internal class AzureFineTuningJobOperation : FineTuningJobOperation
{
    private readonly PipelineMessageClassifier _deleteJobClassifier;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _jobId;

    private readonly string _apiVersion;

    internal AzureFineTuningJobOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        string jobId,
        string status,
        PipelineResponse response,
        string apiVersion)
        : base(pipeline, endpoint, jobId, status, response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _jobId = jobId;
        _apiVersion = apiVersion;
        _deleteJobClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }

    public override async Task<ClientResult> GetJobAsync(RequestOptions? options)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetJob(RequestOptions? options)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelAsync(RequestOptions? options)
    {
        using PipelineMessage message = CreateCancelFineTuningJobRequest(_jobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override AsyncCollectionResult GetJobEventsAsync(string? after, int? limit, RequestOptions options)
    {
        return new AsyncFineTuningJobEventCollectionResult(this, options, limit, after);
    }

    public override CollectionResult GetJobEvents(string? after, int? limit, RequestOptions options)
    {
        return new FineTuningJobEventCollectionResult(this, options, limit, after);
    }

    public override AsyncCollectionResult GetJobCheckpointsAsync(string? after, int? limit, RequestOptions? options)
    {
        return new AsyncFineTuningJobCheckpointCollectionResult(this, options, limit, after);
    }

    public override CollectionResult GetJobCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        return new FineTuningJobCheckpointCollectionResult(this, options, limit, after);
    }

    internal override async Task<ClientResult> GetJobCheckpointsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetJobPageCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal override ClientResult GetJobCheckpointsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningJobCheckpointsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal override async Task<ClientResult> GetJobEventsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningEventsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetJobEventsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = CreateGetFineTuningEventsRequest(_jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    [Experimental("AOAI001")]
    public virtual ClientResult DeleteJob(string fineTuningJobId, RequestOptions? options)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    [Experimental("AOAI001")]
    public virtual async Task<ClientResult> DeleteJobAsync(string fineTuningJobId, RequestOptions? options)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateDeleteJobRequestMessage(string fineTuningJobId, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("DELETE")
        .WithPath("fine_tuning", "jobs", fineTuningJobId)
        .WithAccept("application/json")
        .WithClassifier(_deleteJobClassifier)
        .WithOptions(options)
        .Build();

    internal override PipelineMessage CreateRetrieveFineTuningJobRequest(string fineTuningJobId, RequestOptions? options)
       => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
           .WithMethod("GET")
           .WithPath("fine_tuning", "jobs", fineTuningJobId)
           .WithAccept("application/json")
           .WithOptions(options)
           .Build();

    internal override PipelineMessage CreateCancelFineTuningJobRequest(string fineTuningJobId, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("POST")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "cancel")
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override PipelineMessage CreateGetFineTuningJobCheckpointsRequest(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("GET")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "checkpoints")
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("limit", limit)
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override PipelineMessage CreateGetFineTuningEventsRequest(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("GET")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "events")
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("limit", limit)
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();
}

#endif
