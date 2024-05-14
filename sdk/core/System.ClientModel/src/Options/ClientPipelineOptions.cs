// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives;

/// <summary>
/// Controls the creation of a pipeline used by a service client.
/// Service clients must create a client-specific subtype of this class
/// to pass to their constructors to allow for service-specific options
/// with a client-wide scope.
/// </summary>
public class ClientPipelineOptions
{
    private static readonly ClientPipelineOptions _defaultOptions = new();
    internal static ClientPipelineOptions Default => _defaultOptions;

    #region Pipeline creation: Overrides of default pipeline policies

    public PipelinePolicy? RetryPolicy { get; set; }

    public PipelineTransport? Transport { get; set; }

    #endregion

    #region Pipeline creation: Policy settings

    public TimeSpan? NetworkTimeout { get; set; }

    #endregion

    #region Pipeline creation: User-specified policies

    internal PipelinePolicy[]? PerCallPolicies { get; set; }

    internal PipelinePolicy[]? PerTryPolicies { get; set; }

    internal PipelinePolicy[]? BeforeTransportPolicies { get; set; }

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        Argument.AssertNotNull(policy, nameof(policy));

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
            policies = policiesProperty;
        }

        policies[policies.Length - 1] = policy;
        return policies;
    }

    #endregion
}
