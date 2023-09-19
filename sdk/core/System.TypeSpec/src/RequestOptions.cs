// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.Threading;

namespace System.ServiceModel.Rest;

public class RequestOptions // base of ClientOptions and RequestContext
{
    public CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    public PipelinePolicy RetryPolicy { get; set; } = DefaultRetryPolicy;

    public PipelinePolicy LoggingPolicy { get; set; } = DefaultLoggingPolicy;

    public static PipelinePolicy DefaultRetryPolicy { get; set; } = new RetryPolicy(maxRetries: 3);

    public static PipelinePolicy DefaultLoggingPolicy { get; set; } = new LoggingPolicy();

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
}
