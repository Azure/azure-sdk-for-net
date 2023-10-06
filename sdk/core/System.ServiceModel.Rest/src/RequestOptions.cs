// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading;

namespace System.ServiceModel.Rest;

// TODO: Make options freezable
public class RequestOptions
{
    private bool _bufferResponse = true;

    public CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    public ResultErrorOptions ResultErrorOptions { get; set; } = ResultErrorOptions.Default;

    public PipelinePolicy[]? PerTryPolicies { get; set; }

    public PipelinePolicy[]? PerCallPolicies { get; set; }

    public PipelinePolicy? RetryPolicy { get; set; }

    public PipelinePolicy? LoggingPolicy { get; set; }

    public MessagePipelineTransport? Transport { get; set; } = DefaultTransport;

    public bool BufferResponse
    {
        get => _bufferResponse;
        set => _bufferResponse = value;
    }

    public static PipelinePolicy? DefaultRetryPolicy { get; set; }

    public static PipelinePolicy? DefaultLoggingPolicy { get; set; }

    public static MessagePipelineTransport? DefaultTransport { get; set; }

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
}
