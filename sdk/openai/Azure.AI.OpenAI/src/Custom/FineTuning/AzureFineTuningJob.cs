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
        CopyLocalParameters(response, InternalFineTuningJob.FromClientResult(ClientResult.FromResponse(response)));
        return ClientResult.FromResponse(response);
    }

    public override async Task<ClientResult> CancelAndUpdateAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        CopyLocalParameters(response, InternalFineTuningJob.FromClientResult(ClientResult.FromResponse(response)));
        return ClientResult.FromResponse(response);
    }
}
