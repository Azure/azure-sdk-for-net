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

    public static IPipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage>? DefaultLoggingPolicy { get; set; }// = new ConsoleLoggingPolicy();

    public static PipelineTransport<PipelineMessage>? DefaultTransport { get; set; }

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
}
