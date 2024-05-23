// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ResultOperation : ClientResult
{
    protected ResultOperation(string id, PipelineResponse response) : base(response)
    {
        Id = id;
    }

    public string Id { get; protected set; }

    public bool HasCompleted { get; protected set; }

    public abstract ValueTask<PipelineResponse> UpdateStatusAsync(CancellationToken cancellationToken = default);

    public abstract PipelineResponse UpdateStatus(CancellationToken cancellationToken = default);

    // TODO: what is the use case for these?  How do they differ from GetRawResponse() ?
    public abstract ValueTask<PipelineResponse> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default);

    public abstract PipelineResponse WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default);

    public abstract ValueTask<PipelineResponse> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default);

    public abstract PipelineResponse WaitForCompletionResponse(CancellationToken cancellationToken = default);

    // TODO: should these be virtual with an internal poller implementation?
    // TODO: should we have something like DelayStrategy?
}
#pragma warning restore CS1591 // public XML comments
