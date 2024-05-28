// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

// idea: it's like a Page, represents the result/"answer" that is progressively available.

#pragma warning disable CS1591 // public XML comments

// TODO: does it need to be abstract?
public abstract class StatusBasedResult<TStatus, TValue> : ClientResult
{
    public StatusBasedResult(TStatus status, PipelineResponse response) : base(response)
    {
        Status = status;
    }

    public TStatus Status { get; protected set; }

    public TValue? Value { get; protected set; }

    public abstract ValueTask<StatusBasedResult<TStatus, TValue>> WaitForStatusUpdateAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);

    public abstract StatusBasedResult<TStatus, TValue> WaitForStatusUpdate(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);
}

#pragma warning restore CS1591 // public XML comments
