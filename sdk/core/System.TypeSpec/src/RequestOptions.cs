// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class RequestOptions // base of ClientOptions and RequestContext
{
    /// <summary>
    /// TBD.
    /// </summary>
    public CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    /// <summary>
    /// TBD.
    /// </summary>
    public PipelinePolicy RetryPolicy { get; set; } = DefaultRetryPolicy;

    /// <summary>
    /// TBD.
    /// </summary>
    public PipelinePolicy LoggingPolicy { get; set; } = DefaultLoggingPolicy;

    /// <summary>
    /// TBD.
    /// </summary>
    public static PipelinePolicy DefaultRetryPolicy { get; set; } = new RetryPolicy(maxRetries: 3);

    /// <summary>
    /// TBD.
    /// </summary>
    public static PipelinePolicy DefaultLoggingPolicy { get; set; } = new LoggingPolicy();

    /// <summary>
    /// TBD.
    /// </summary>
    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
}
