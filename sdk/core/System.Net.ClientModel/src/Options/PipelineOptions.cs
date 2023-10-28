// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions (TODO: RequestOptions), which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    #region Pipeline creation: Customer-specified policies
    public PipelinePolicy[]? PerTryPolicies { get; set; }

    public PipelinePolicy[]? PerCallPolicies { get; set; }
    #endregion

    #region Pipeline creation: Required policy overrides
    public PipelinePolicy? RetryPolicy { get; set; }

    public PipelinePolicy? LoggingPolicy { get; set; }

    public PipelineTransport? Transport { get; set; }
    #endregion

    #region Pipeline creation: Policy-specific settings
    public TimeSpan? NetworkTimeout { get; set; }
    #endregion

    #region Defaults for pipeline creation - "always-there" policies.
    public static PipelinePolicy? DefaultRetryPolicy { get; set; }

    public static PipelinePolicy? DefaultLoggingPolicy { get; set; }

    public static PipelineTransport? DefaultTransport { get; set; }

    public static TimeSpan DefaultNetworkTimeout { get; set; } = TimeSpan.FromSeconds(100);
    #endregion
}
