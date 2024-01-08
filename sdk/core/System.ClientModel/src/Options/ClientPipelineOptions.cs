﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions which controls the behavior of the pipeline.
/// </summary>
// TODO: we've made this non-abstract in ClientModel, so to make sure service
// clients always inherit from it rather than using it directly, we will need to
// add an analyzer to validate it via static analysis.
public class ClientPipelineOptions
{
    private static readonly ClientPipelineOptions _defaultOptions = new();
    internal static ClientPipelineOptions Default => _defaultOptions;

    #region Pipeline creation: User-specified policies

    internal PipelinePolicy[]? PerCallPolicies { get; set; }

    internal PipelinePolicy[]? PerTryPolicies { get; set; }

    internal PipelinePolicy[]? BeforeTransportPolicies { get; set; }

    #endregion

    #region Pipeline creation: Required policy overrides

    public PipelinePolicy? RetryPolicy { get; set; }

    public PipelineTransport? Transport { get; set; }

    #endregion

    #region Pipeline creation: Policy-specific settings

    public TimeSpan? NetworkTimeout { get; set; }

    #endregion

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        if (policy is null) throw new ArgumentNullException(nameof(policy));

        switch (position)
        {
            case PipelinePosition.PerCall:
                PerCallPolicies = AddPolicy(policy, PerCallPolicies);
                break;
            case PipelinePosition.PerTry:
                PerTryPolicies = AddPolicy(policy, PerTryPolicies);
                break;
            case PipelinePosition.BeforeTransport:
                BeforeTransportPolicies = AddPolicy(policy, BeforeTransportPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }

    internal static PipelinePolicy[] AddPolicy(PipelinePolicy policy, PipelinePolicy[]? policies)
    {
        if (policies is null)
        {
            policies = new PipelinePolicy[1];
        }
        else
        {
            PipelinePolicy[] policiesProperty = new PipelinePolicy[policies.Length + 1];
            policies.CopyTo(policiesProperty.AsSpan());
        }

        policies[policies.Length - 1] = policy;
        return policies;
    }
}
