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
internal partial class AzureFineTuningJob : FineTuningJob
{
    private readonly PipelineMessageClassifier _deleteJobClassifier;
    internal new readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;
    internal new readonly FineTuningClient _client;

    internal AzureFineTuningJob(
        ClientPipeline pipeline,
        Uri endpoint,
        PipelineResponse response,
        string apiVersion)
        : base(pipeline, endpoint, response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
        _client = new AzureFineTuningClient(_pipeline, _endpoint, null);

        _deleteJobClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }

    internal AzureFineTuningJob(
        ClientPipeline pipeline,
        Uri endpoint,
        PipelineResponse response,
        string apiVersion,
        InternalFineTuningJob internalJob)
            : base(pipeline, endpoint, internalJob, response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
        _client = new AzureFineTuningClient(_pipeline, _endpoint, null);

        _deleteJobClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
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

    // TODO use this
    internal PipelineMessage CancelPipelineMessage(string fineTuningJobId, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("POST")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "cancel")
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public override AsyncCollectionResult GetCheckpointsAsync(string? after, int? limit, RequestOptions? options)
    {
        return new AsyncFineTuningCheckpointCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal override async Task<ClientResult> GetCheckpointsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetCheckpointsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal override ClientResult GetCheckpointsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetCheckpointsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal PipelineMessage GetCheckpointsPipelineMessage(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
        .WithMethod("GET")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "checkpoints")
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("limit", limit)
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override async Task<ClientResult> GetEventsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetEventsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetEventsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetEventsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal PipelineMessage GetEventsPipelineMessage(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
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
