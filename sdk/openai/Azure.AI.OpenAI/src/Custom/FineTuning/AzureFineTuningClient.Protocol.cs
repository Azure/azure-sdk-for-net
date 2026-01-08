// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Linq;
using Azure.AI.OpenAI.Utility;

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningClient : FineTuningClient
{
    public override async Task<FineTuningJob> FineTuneAsync(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = PostJobPipelineMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string jobId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        AzureFineTuningJob operation = new(Pipeline, _endpoint, response, _apiVersion);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    public override FineTuningJob FineTune(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = PostJobPipelineMessage(content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string jobId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        AzureFineTuningJob operation = new(Pipeline, _endpoint, response, _apiVersion);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    internal override AsyncCollectionResult GetJobsAsync(string afterJobId, int? pageSize, RequestOptions options)
    {
        return new AzureAsyncCollectionResult<FineTuningJob, FineTuningCollectionPageToken>(
            Pipeline,
            continuation => GetJobsPipelineMessage(continuation?.After, pageSize, options),
            page => FineTuningCollectionPageToken.FromResponse(page, pageSize),
            page => GetJobsFromResponse(page.GetRawResponse()),
            options?.CancellationToken ?? default);
    }

    private IEnumerable<FineTuningJob> GetJobsFromResponse(PipelineResponse response)
    {
        InternalListPaginatedFineTuningJobsResponse jobs = ModelReaderWriter.Read<InternalListPaginatedFineTuningJobsResponse>(response.Content, ModelReaderWriterOptions.Json, AzureAIOpenAIContext.Default)!;
        return jobs.Data.Select(job => new AzureFineTuningJob(Pipeline, _endpoint, response, _apiVersion, job));
    }
    internal override PipelineMessage PostJobPipelineMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("fine_tuning", "jobs")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage GetJobsPipelineMessage(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    //internal static new PipelineMessage GetJobPipelineMessage(ClientPipeline clientPipeline, Uri endpoint, string fineTuningJobId, RequestOptions options)
    //    => new AzureOpenAIPipelineMessageBuilder(clientPipeline, endpoint, _apiVersion)
    //        .WithMethod("GET")
    //        .WithPath("fine_tuning", "jobs", fineTuningJobId)
    //        .WithAccept("application/json")
    //        .WithOptions(options)
    //        .Build();

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

#endif
