﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class StatusBasedOperation<TStatus, TValue> : ResultOperation<TValue>
{
    protected StatusBasedOperation(string id, TStatus status, PipelineResponse response) : base(id, response)
    {
        Status = status;
    }

    public TStatus Status { get; protected set; }

    public abstract ValueTask<ClientResult<(TStatus Status, TValue? Value)>> WaitForStatusUpdateAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);

    public abstract ClientResult<(TStatus Status, TValue? Value)> WaitForStatusUpdate(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default);

    // TODO: Optional APIs to Pause and Resume polling
    public abstract void Pause();

    public abstract void Resume();
}
#pragma warning restore CS1591 // public XML comments
