// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Threading;

namespace System.Net.ClientModel;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  For the duration of pipeline.Send,
/// this may change some behaviors in various pipeline policies and the transport.
/// </summary>
public class RequestOptions
{
    public RequestOptions()
    {
        PipelineOptions = new PipelineOptions();
        ErrorBehavior = ErrorBehavior.Default;
        CancellationToken = CancellationToken.None;
    }

    public RequestOptions(PipelineOptions pipelineOptions)
    {
        PipelineOptions = new(pipelineOptions);
        ErrorBehavior = ErrorBehavior.Default;
        CancellationToken = CancellationToken.None;
    }

    protected internal virtual void Apply(ClientMessage message)
    {
        // Wire up options on message
        message.CancellationToken = CancellationToken;
        message.MessageClassifier = GetMessageClassifier();

        // TODO: note that this is a lot of *ways* to set values on the
        // message, policy, etc.  Let's get clear on how many ways we need and why
        // and when we use what, etc., then simplify it back to that per reasons.
        if (PipelineOptions.NetworkTimeout.HasValue)
        {
            ResponseBufferingPolicy.SetNetworkTimeout(message, PipelineOptions.NetworkTimeout.Value);
        }
    }

    // Hard-codes precedence rules for MessageClassifier
    private MessageClassifier GetMessageClassifier()
    {
        // TODO: We have a bug in this logic currently because classifiers are not chaining
        if (MessageClassifier is not null)
        {
            return MessageClassifier;
        }

        if (PipelineOptions.MessageClassifier is not null)
        {
            return PipelineOptions.MessageClassifier;
        }

        return MessageClassifier.Default;
    }

    public PipelineOptions PipelineOptions { get; }

    public virtual ErrorBehavior ErrorBehavior { get; set; }

    public virtual CancellationToken CancellationToken { get; set; }

    public virtual MessageClassifier? MessageClassifier { get; set; }

    public MessagePipeline Pipeline => PipelineOptions.Pipeline;

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        switch (position)
        {
            case PipelinePosition.PerCall:
                PipelineOptions.PerCallPolicies = AddPolicy(policy, PipelineOptions.PerCallPolicies);
                break;
            case PipelinePosition.PerTry:
                PipelineOptions.PerTryPolicies = AddPolicy(policy, PipelineOptions.PerTryPolicies);
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
