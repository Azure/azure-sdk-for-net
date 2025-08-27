// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// The scenario client used for fine-tuning operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("OPENAI001")]
internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    [Experimental("OPENAI001")]
    internal AzureFineTuningClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
//        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.GetRawServiceApiValueForClient(this);
    }

    [Experimental("OPENAI001")]
    protected AzureFineTuningClient()
    { }

    /// <summary>
    /// Get FineTuningJob for a previously started fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="JobId"> The ID of the fine-tuning job. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    public override FineTuningJob GetJob(string JobId, CancellationToken cancellationToken = default)
    {
        return AzureFineTuningJob.Rehydrate(this, JobId, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Get FineTuningJob for a previously started fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="JobId"> The ID of the fine-tuning job. </param>
    /// <param name="cancellationToken"> The cancellation token. </param>
    public override async Task<FineTuningJob> GetJobAsync(string JobId, CancellationToken cancellationToken = default)
    {
        return await AzureFineTuningJob.RehydrateAsync(this, JobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    public override AsyncCollectionResult<FineTuningJob> GetJobsAsync(FineTuningJobCollectionOptions options = default, CancellationToken cancellationToken = default)
    {
        options ??= new FineTuningJobCollectionOptions();
        return (AsyncCollectionResult<FineTuningJob>)GetJobsAsync(options.AfterJobId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    [Experimental("OPENAI001")]
    internal override FineTuningJob CreateJobFromResponse(PipelineResponse response)
    {
        return new AzureFineTuningJob(Pipeline, _endpoint, response, _apiVersion);
    }
}

#endif