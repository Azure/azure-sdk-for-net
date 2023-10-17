// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;

namespace System.Net.ClientModel;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions (TODO: RequestOptions), which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    #region Pipeline creation: Customer-specified policies
    public PipelinePolicy<PipelineMessage>[]? PerTryPolicies { get; set; }

    public PipelinePolicy<PipelineMessage>[]? PerCallPolicies { get; set; }
    #endregion

    #region Pipeline creation: Required policy overrides
    public PipelinePolicy<PipelineMessage>? RetryPolicy { get; set; }

    public PipelinePolicy<PipelineMessage>? LoggingPolicy { get; set; }

    public PipelineTransport<PipelineMessage>? Transport { get; set; }
    #endregion

    #region Pipeline creation: Policy-specific settings
    public TimeSpan? NetworkTimeout { get; set; }
    #endregion

    #region Defaults for pipeline creation - "always-there" policies.
    public static PipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static PipelinePolicy<PipelineMessage>? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport<PipelineMessage>? DefaultTransport { get; set; }

    public static TimeSpan DefaultNetworkTimeout { get; set; } = TimeSpan.FromSeconds(100);
    #endregion
}
