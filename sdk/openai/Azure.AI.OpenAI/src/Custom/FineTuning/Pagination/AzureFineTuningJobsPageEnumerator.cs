// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.FineTuning;

internal class AzureFineTuningJobsPageEnumerator : FineTuningJobsPageEnumerator
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    private readonly int? _limit;
    private readonly RequestOptions _options;
    private string? _after;

    public AzureFineTuningJobsPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string? after,
        int? limit,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, after!, limit, options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;

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

        return await GetJobsAsync(_after!, _limit, _options).ConfigureAwait(false);
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

        return GetJobs(_after!, _limit, _options);
    }

    internal override async Task<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFineTuningJobsRequest(after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetJobs(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFineTuningJobsRequest(after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal new PipelineMessage CreateGetFineTuningJobsRequest(string? after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
