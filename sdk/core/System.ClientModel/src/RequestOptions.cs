// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;
using System.Threading;

namespace System.Net.ClientModel;

// TODO: Make options freezable
public class RequestOptions
{
    private bool _bufferResponse = true;

    public CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    public ErrorBehavior ErrorBehavior { get; set; } = ErrorBehavior.Default;

    public IPipelinePolicy<PipelineMessage>[]? PerTryPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage>[]? PerCallPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage>? RetryPolicy { get; set; }

    public IPipelinePolicy<PipelineMessage>? LoggingPolicy { get; set; }

    public PipelineTransport<PipelineMessage>? Transport { get; set; }

    public bool BufferResponse
    {
        get => _bufferResponse;
        set => _bufferResponse = value;
    }

    public static IPipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage>? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport<PipelineMessage>? DefaultTransport { get; set; }

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
}
