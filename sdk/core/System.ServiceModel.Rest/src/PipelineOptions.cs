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
    public IPipelinePolicy<PipelineMessage, InvocationOptions>[]? PerTryPolicies { get; set; }

    public IPipelinePolicy<PipelineMessage, InvocationOptions>[]? PerCallPolicies { get; set; }
    #endregion

    #region Pipeline creation: Required policy overrides
    public IPipelinePolicy<PipelineMessage, InvocationOptions>? RetryPolicy { get; set; }

    public IPipelinePolicy<PipelineMessage, InvocationOptions>? LoggingPolicy { get; set; }

    public PipelineTransport<PipelineMessage, InvocationOptions>? Transport { get; set; }
    #endregion

    #region Defaults for pipeline creation
    public static IPipelinePolicy<PipelineMessage, InvocationOptions>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage, InvocationOptions>? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport<PipelineMessage, InvocationOptions>? DefaultTransport { get; set; }
    #endregion
}
