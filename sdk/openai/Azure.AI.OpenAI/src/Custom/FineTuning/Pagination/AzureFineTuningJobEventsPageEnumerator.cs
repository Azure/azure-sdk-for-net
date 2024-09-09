// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.FineTuning;

internal class AzureFineTuningJobEventsPageEnumerator : FineTuningJobEventsPageEnumerator
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    private readonly int? _limit;
    private readonly string _jobId;
    private readonly RequestOptions _options;
    private string? _after;

    public AzureFineTuningJobEventsPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string jobId, string? after, int? limit,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, jobId, after!, limit, options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;

        _jobId = jobId;
        _after = after;
        _limit = limit;
        _options = options;
    }

    public override async Task<ClientResult> GetNextAsync(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response?.Content);

        if (doc?.RootElement.TryGetProperty("data", out JsonElement dataElement) == true
            && dataElement.EnumerateArray().LastOrDefault().TryGetProperty("id", out JsonElement idElement) == true)
        {
            _after = idElement.GetString();
        }

        return await GetJobEventsAsync(_jobId, _after!, _limit, _options).ConfigureAwait(false);
    }

    public override ClientResult GetNext(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response?.Content);

        if (doc?.RootElement.TryGetProperty("data", out JsonElement dataElement) == true
            && dataElement.EnumerateArray().LastOrDefault().TryGetProperty("id", out JsonElement idElement) == true)
        {
            _after = idElement.GetString();
        }

        return GetJobEvents(_jobId, _after!, _limit, _options);
    }

    internal override async Task<ClientResult> GetJobEventsAsync(string jobId, string after, int? limit, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        using PipelineMessage message = CreateGetFineTuningEventsRequest(jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetJobEvents(string jobId, string after, int? limit, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        using PipelineMessage message = CreateGetFineTuningEventsRequest(jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal new PipelineMessage CreateGetFineTuningEventsRequest(string fineTuningJobId, string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", fineTuningJobId, "events")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
