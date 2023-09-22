// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineMessage
{
    protected PipelineMessage(PipelineRequest request)
    {
        Request = request;
    }

    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    public PipelineResponse? Response { get; set; }

    public PipelineRequest Request { get; set; }
}
