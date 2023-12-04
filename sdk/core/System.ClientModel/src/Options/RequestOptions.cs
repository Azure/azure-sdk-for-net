// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  For the duration of pipeline.Send,
/// this may change some behaviors in various pipeline policies and the transport.
/// </summary>
public class RequestOptions
{
    private PipelinePolicy[]? _perCallPolicies;
    private PipelinePolicy[]? _perTryPolicies;

    public RequestOptions()
    {
        CancellationToken = CancellationToken.None;
        ErrorBehavior = ErrorBehavior.Default;
        RequestHeaders = new PipelineRequestHeaders();
    }

    public CancellationToken CancellationToken { get; set; }

    public ErrorBehavior ErrorBehavior { get; set; }

    public MessageHeaders RequestHeaders { get; }

    // Set options on the message before sending it through the pipeline.
    protected internal void Apply(PipelineMessage message, MessageClassifier? messageClassifier = default)
    {
        // TODO: Even though we're overriding the message.CancellationToken, this
        // works today because message.CancellationToken is overridden in Azure.Core
        // clients in HttpPipeline.Send.  We will need to resolve this e2e story
        // before merging the Azure.Core 2.0 PR.
        message.CancellationToken = CancellationToken;

        // We don't overwrite the classifier on the message if it's already set.
        // This is needed for Azure.Core so a ClientModel MessageClassifier
        // doesn't overwrite an Azure.Core ResponseClassifier.  The classifier
        // should never be pre-set on a ClientModel client.
        message.MessageClassifier ??=

            // The classifier passed by the client-author.
            messageClassifier ??

            // The internal global default classifier.
            MessageClassifier.Default;

        // Copy custom pipeline policies.
        message.PerCallPolicies = _perCallPolicies;
        message.PerTryPolicies = _perTryPolicies;
    }

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        if (policy is null) throw new ArgumentNullException(nameof(policy));

        switch (position)
        {
            case PipelinePosition.PerCall:
                _perCallPolicies = ServiceClientOptions.AddPolicy(policy, _perCallPolicies);
                break;
            case PipelinePosition.PerTry:
                _perTryPolicies = ServiceClientOptions.AddPolicy(policy, _perTryPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }
}
