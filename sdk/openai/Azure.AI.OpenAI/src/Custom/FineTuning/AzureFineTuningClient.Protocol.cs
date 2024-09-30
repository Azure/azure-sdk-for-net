// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Azure.AI.OpenAI.Utility;

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

    public override CollectionResult GetJobs(string after, int? limit, RequestOptions options)
    {
        return new AzureCollectionResult<FineTuningJob, FineTuningJobCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetJobsRequestMessage(continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobCollectionPageToken.FromOptions(limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(page.GetRawResponse().Content).Data);
    }

    public override AsyncCollectionResult GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<FineTuningJob, FineTuningJobCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetJobsRequestMessage(continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobCollectionPageToken.FromOptions(limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(page.GetRawResponse().Content).Data,
            options?.CancellationToken ?? default);
    }

    public override CollectionResult GetJobEvents(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        return new AzureCollectionResult<FineTuningJobEvent, FineTuningJobEventCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetFineTuningEventsRequest(fineTuningJobId, continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobEventCollectionPageToken.FromOptions(fineTuningJobId, limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListFineTuningJobEventsResponse>(page.GetRawResponse().Content).Data);
    }

    public override AsyncCollectionResult GetJobEventsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<FineTuningJobEvent, FineTuningJobEventCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetFineTuningEventsRequest(fineTuningJobId, continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobEventCollectionPageToken.FromOptions(fineTuningJobId, limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListFineTuningJobEventsResponse>(page.GetRawResponse().Content).Data,
            options?.CancellationToken ?? default);
    }

    public override CollectionResult GetJobCheckpoints(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        return new AzureCollectionResult<InternalFineTuningJobCheckpoint, FineTuningJobCheckpointCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetFineTuningJobCheckpointsRequest(fineTuningJobId, continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobCheckpointCollectionPageToken.FromOptions(fineTuningJobId, limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListFineTuningJobCheckpointsResponse>(page.GetRawResponse().Content).Data);
    }

    public override AsyncCollectionResult GetJobCheckpointsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<InternalFineTuningJobCheckpoint, FineTuningJobCheckpointCollectionPageToken>(
            Pipeline,
            options,
            continuation => CreateGetFineTuningJobCheckpointsRequest(fineTuningJobId, continuation?.After ?? after, continuation?.Limit ?? limit, options),
            page => TryGetLastId(page, out var nextId) ? FineTuningJobCheckpointCollectionPageToken.FromOptions(fineTuningJobId, limit, nextId) : null,
            page => ModelReaderWriter.Read<InternalListFineTuningJobCheckpointsResponse>(page.GetRawResponse().Content).Data,
            options?.CancellationToken ?? default);
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

    private PipelineMessage CreateGetJobsRequestMessage(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetFineTuningEventsRequest(string fineTuningJobId, string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", fineTuningJobId, "events")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateGetFineTuningJobCheckpointsRequest(string fineTuningJobId, string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", fineTuningJobId, "checkpoints")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
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

    private static bool TryGetLastId(ClientResult previous, out string lastId)
    {
        Argument.AssertNotNull(previous, nameof(previous));

        using JsonDocument json = JsonDocument.Parse(previous.GetRawResponse().Content);
        if (!json.RootElement.GetProperty("has_more"u8).GetBoolean())
        {
            lastId = null;
            return false;
        }

        if (json?.RootElement.TryGetProperty("data", out JsonElement dataElement) == true
            && dataElement.EnumerateArray().LastOrDefault().TryGetProperty("id", out JsonElement idElement) == true)
        {
            lastId = idElement.GetString();
            return true;
        }

        lastId = null;
        return false;
    }
}
