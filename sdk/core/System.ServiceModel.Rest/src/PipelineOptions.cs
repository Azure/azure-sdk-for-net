// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Core.Pipeline;

namespace System.ServiceModel.Rest;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with InvocationOptions, which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    #region Pipeline creation: Customer-specified policies
    public IPipelinePolicy<PipelineMessage>[]? PerTryPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage>[]? PerCallPolicies { get; set; }
    #endregion

    #region Pipeline creation: Required policy overrides
    public IPipelinePolicy<PipelineMessage>? RetryPolicy { get; set; }

    public IPipelinePolicy<PipelineMessage>? LoggingPolicy { get; set; }

    public PipelineTransport<PipelineMessage, InvocationOptions>? Transport { get; set; }
    #endregion

    #region Pipeline creation: Policy-specific settings
    public TimeSpan? NetworkTimeout { get; set; }
    #endregion

    #region Defaults for pipeline creation
    public static IPipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage>? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport<PipelineMessage, InvocationOptions>? DefaultTransport { get; set; }

    public static TimeSpan DefaultNetworkTimeout { get; set; } = TimeSpan.FromSeconds(100);
    #endregion
}
