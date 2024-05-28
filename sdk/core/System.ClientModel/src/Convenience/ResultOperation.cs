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

    // TODO: Should we take a cancellationToken, since third-party convenience methods don't?
    // TODO: Should we take a RequestOptions?
    //   i.e. Is the non-T version of this for protocol-level, or only for operations that
    //   don't have an output value?
    public abstract ValueTask<ClientResult> UpdateStatusAsync();

    public abstract ClientResult UpdateStatus();

    // TODO: what is the use case for these?  How do they differ from GetRawResponse() ?
    public abstract ValueTask<ClientResult> WaitForCompletionResultAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);

    public abstract ClientResult WaitForCompletionResult(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);

    // TODO: should these be virtual with an internal poller implementation?
    // TODO: should we have something like DelayStrategy?
}
#pragma warning restore CS1591 // public XML comments
