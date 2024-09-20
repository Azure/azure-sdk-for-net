// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly PipelineMessageClassifier DeleteJobClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });

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

    public override IEnumerable<ClientResult> GetJobs(string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobsPageEnumerator enumerator = new(Pipeline, _endpoint, after, limit, _apiVersion, options);
        return PageCollectionHelpers.Create(enumerator);
    }

    public override IAsyncEnumerable<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobsPageEnumerator enumerator = new(Pipeline, _endpoint, after, limit, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public override IEnumerable<ClientResult> GetJobEvents(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobEventsPageEnumerator enumerator = new(Pipeline, _endpoint, fineTuningJobId, after, limit, _apiVersion, options);
        return PageCollectionHelpers.Create(enumerator);
    }

    public override IAsyncEnumerable<ClientResult> GetJobEventsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobEventsPageEnumerator enumerator = new(Pipeline, _endpoint, fineTuningJobId, after, limit, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public override IEnumerable<ClientResult> GetJobCheckpoints(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobCheckpointsPageEnumerator enumerator = new(Pipeline, _endpoint, fineTuningJobId, after, limit, _apiVersion, options);
        return PageCollectionHelpers.Create(enumerator);
    }

    public override IAsyncEnumerable<ClientResult> GetJobCheckpointsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        AzureFineTuningJobCheckpointsPageEnumerator enumerator = new(Pipeline, _endpoint, fineTuningJobId, after, limit, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
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

    [Experimental("AOAI001")]
    public virtual ClientResult DeleteJob(string jobId, RequestOptions options = null)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(jobId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [Experimental("AOAI001")]
    public virtual async Task<ClientResult> DeleteJobAsync(string jobId, RequestOptions options = null)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(jobId, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateCreateJobRequestMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("fine_tuning", "jobs")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetJobRequestMessage(string jobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", jobId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCancelJobRequestMessage(string jobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("fine_tuning", "jobs", jobId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateDeleteJobRequestMessage(string jobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("fine_tuning", "jobs", jobId)
            .WithAccept("application/json")
            .WithClassifier(DeleteJobClassifier)
            .WithOptions(options)
            .Build();
}
