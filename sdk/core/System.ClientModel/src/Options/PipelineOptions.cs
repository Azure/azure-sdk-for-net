﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

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

    public PipelineTransport? Transport { get; set; }

    #endregion

    #region Pipeline creation: Policy-specific settings

    // TODO: when do we want these to be nullable and when do we want to set defaults?  Why?
    public TimeSpan? NetworkTimeout { get; set; }

    #endregion
}
