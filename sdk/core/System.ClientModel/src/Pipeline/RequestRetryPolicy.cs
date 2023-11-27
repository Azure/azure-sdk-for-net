// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Pipeline;

internal class RequestRetryPolicy : PipelinePolicy
{
    private const int DefaultMaxRetries = 3;

    private readonly int _maxRetries;

    public RequestRetryPolicy(int maxRetries = DefaultMaxRetries)
    {
    }

    public override void Process(PipelineMessage message, PipelineProcessor pipeline)

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, pipeline, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, PipelineProcessor pipeline, bool async)
    {
    }
}
