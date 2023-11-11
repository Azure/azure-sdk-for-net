// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Threading;

namespace System.Net.ClientModel;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  If PipelineOptions are created,
/// modified, and passed to the RequestOptions constructor, this instance will
/// hold a cached pipeline instance that can be reused across service methods.
/// To prevent recreating a pipeline instance, store RequestOptions instances
/// for reuse.
/// </summary>
public class RequestOptions
{
    private readonly PipelineOptions _pipelineOptions;

    public RequestOptions() : this(new PipelineOptions())
    {
    }

    public RequestOptions(PipelineOptions pipelineOptions)
    {
        _pipelineOptions = pipelineOptions;
        ErrorBehavior = ErrorBehavior.Default;
        CancellationToken = CancellationToken.None;
    }

    // Wire up options on message
    public virtual void Apply(PipelineMessage message, MessageClassifier? messageClassifier = default)
    {
        // TODO: is it possible that we could accidentally override a user-passed CT by doing this here?
        message.CancellationToken = CancellationToken;

        // Don't overwrite the classifier on the message if it's already set.
        // This is needed for Azure.Core so a ClientModel MessageClassifier
        // doesn't overwrite an Azure.Core ResponseClassifier.
        if (!message.HasMessageClassifier)
        {
			// TODO: Is there a nicer way to encode precedence rules here?
            // TODO: Do we want to use Azure.Core's classifier-chaining logic?
            message.MessageClassifier = MessageClassifier ?? messageClassifier ?? MessageClassifier.Default;
        }

        // TODO: note that this is a lot of *ways* to set values on the
        // message, policy, etc.  Let's get clear on how many ways we need and why
        // and when we use what, etc., then simplify it back to that per reasons.
        if (_pipelineOptions.NetworkTimeout.HasValue)
        {
            ResponseBufferingPolicy.SetNetworkTimeout(message, _pipelineOptions.NetworkTimeout.Value);
        }
    }

    public virtual ErrorBehavior ErrorBehavior { get; set; }

    public virtual CancellationToken CancellationToken { get; set; }

    // TODO: Should RequestOptions be freezable too, to prevent client-authors from
    // modifying client-user-passed options values?
    public virtual MessageClassifier? MessageClassifier { get; set; }

    internal PipelineOptions PipelineOptions => _pipelineOptions;

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        switch (position)
        {
            case PipelinePosition.PerCall:
                _pipelineOptions.PerCallPolicies = AddPolicy(policy, _pipelineOptions.PerCallPolicies);
                break;
            case PipelinePosition.PerTry:
                _pipelineOptions.PerTryPolicies = AddPolicy(policy, _pipelineOptions.PerTryPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }

    private static PipelinePolicy[] AddPolicy(PipelinePolicy policy, PipelinePolicy[]? policies)
    {
        if (policies is null)
        {
            policies = new PipelinePolicy[1];
        }
        else
        {
            var perCallPolicies = new PipelinePolicy[policies.Length + 1];
            policies.CopyTo(perCallPolicies.AsSpan());
        }

        policies[policies.Length - 1] = policy;
        return policies;
    }
}
