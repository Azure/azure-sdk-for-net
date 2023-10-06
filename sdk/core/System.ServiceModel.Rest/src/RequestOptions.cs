// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;
using System.Threading;

namespace System.ServiceModel.Rest;

// TODO: Make options freezable
public class RequestOptions
{
    public CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    public ResultErrorOptions ResultErrorOptions { get; set; } = ResultErrorOptions.Default;

    public IPipelinePolicy<PipelineMessage>[]? PerTryPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage>[]? PerCallPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage>? RetryPolicy { get; set; }

    public IPipelinePolicy<PipelineMessage>? LoggingPolicy { get; set; }

    public PipelineTransport<PipelineMessage>? Transport { get; set; }

    public bool BufferResponse { get; set; }

    public TimeSpan NetworkTimeout { get; set; }

    public ResponseErrorClassifier ResponseClassifier { get; set; } = DefaultResponseClassifier;

    public static IPipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage>? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport<PipelineMessage>? DefaultTransport { get; set; }

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;

    public static ResponseErrorClassifier DefaultResponseClassifier { get; set; } = new ResponseErrorClassifier();
}
