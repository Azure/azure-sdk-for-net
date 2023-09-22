// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineMessage : IDisposable
{
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    public abstract PipelineResponse? PipelineResponse { get; set; }

    public abstract PipelineRequest PipelineRequest { get; }

    public abstract void Dispose();
}
