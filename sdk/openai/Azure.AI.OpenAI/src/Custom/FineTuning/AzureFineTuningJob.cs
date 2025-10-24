// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningJob : FineTuningJob
{
    internal static new AzureFineTuningJob Rehydrate(FineTuningClient client, string jobId, RequestOptions? options)
    {
        var azureClient = client as AzureFineTuningClient;
        if (azureClient == null)
        {
            throw new InvalidOperationException("Client must be an AzureFineTuningClient");
        }

        using PipelineMessage message = azureClient.GetJobPipelineMessage(jobId, options);
        PipelineResponse response = azureClient.Pipeline.ProcessMessage(message, options);
        return azureClient.CreateJobFromResponse(response) as AzureFineTuningJob;
    }

    internal static new async Task<AzureFineTuningJob> RehydrateAsync(FineTuningClient client, string jobId, RequestOptions? options)
    {
        var azureClient = client as AzureFineTuningClient;
        if (azureClient == null)
        {
            throw new InvalidOperationException("Client must be an AzureFineTuningClient");
        }

        using PipelineMessage message = azureClient.GetJobPipelineMessage(jobId, options);
        PipelineResponse response = await azureClient.Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return azureClient.CreateJobFromResponse(response) as AzureFineTuningJob;
    }

    public override AsyncCollectionResult<FineTuningCheckpoint> GetCheckpointsAsync(GetCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new GetCheckpointsOptions();
        return (AsyncCollectionResult<FineTuningCheckpoint>)GetCheckpointsAsync(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    public override AsyncCollectionResult<FineTuningEvent> GetEventsAsync(GetEventsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new GetEventsOptions();
        return (AsyncCollectionResult<FineTuningEvent>)GetEventsAsync(options.AfterEventId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    public override CollectionResult<FineTuningEvent> GetEvents(GetEventsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new GetEventsOptions();
        return (CollectionResult<FineTuningEvent>)GetEvents(options.AfterEventId, options.PageSize, cancellationToken.ToRequestOptions());
    }
    public override ClientResult CancelAndUpdate(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        CopyLocalParameters(response, ModelReaderWriter.Read<InternalFineTuningJob>(response.Content, ModelReaderWriterOptions.Json, OpenAIContext.Default)!);
        return ClientResult.FromResponse(response);
    }

    public override async Task<ClientResult> CancelAndUpdateAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        CopyLocalParameters(response, ModelReaderWriter.Read<InternalFineTuningJob>(response.Content, ModelReaderWriterOptions.Json, OpenAIContext.Default)!);
        return ClientResult.FromResponse(response);
    }
}
