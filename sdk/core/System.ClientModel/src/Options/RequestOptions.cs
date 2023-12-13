// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
    private bool _frozen;

    private PipelinePolicy[]? _perCallPolicies;
    private PipelinePolicy[]? _perTryPolicies;
    private PipelinePolicy[]? _beforeTransportPolicies;

    private readonly MessageHeaders _requestHeaders;

    public RequestOptions()
    {
        CancellationToken = CancellationToken.None;
        ErrorBehavior = ErrorBehavior.Default;

        _requestHeaders = new PipelineRequestHeaders();
    }

    public CancellationToken CancellationToken { get; set; }

    public ErrorBehavior ErrorBehavior { get; set; }

    public void AddHeader(string name, string value)
    {
        ClientUtilities.AssertNotNull(name, nameof(name));
        ClientUtilities.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _requestHeaders.Add(name, value);
    }

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        ClientUtilities.AssertNotNull(policy, nameof(policy));

        AssertNotFrozen();

        switch (position)
        {
            case PipelinePosition.PerCall:
                _perCallPolicies = PipelineOptions.AddPolicy(policy, _perCallPolicies);
                break;
            case PipelinePosition.PerTry:
                _perTryPolicies = PipelineOptions.AddPolicy(policy, _perTryPolicies);
                break;
            case PipelinePosition.BeforeTransport:
                _beforeTransportPolicies = PipelineOptions.AddPolicy(policy, _beforeTransportPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }

    // Set options on the message before sending it through the pipeline.
    internal void Apply(PipelineMessage message, PipelineMessageClassifier? messageClassifier = default)
    {
        _frozen = true;

        // Even though we're overriding the message.CancellationToken, this works
        // with Azure.Core clients because message.CancellationToken is overridden
        // in Azure.Core's HttpPipeline.Send, which will be the last update before
        // the message flows though the pipeline.
        message.CancellationToken = CancellationToken;

        // We don't overwrite the classifier on the message if it's already set.
        // This is needed for Azure.Core so a ClientModel MessageClassifier
        // doesn't overwrite an Azure.Core ResponseClassifier.  The classifier
        // should never be pre-set on a ClientModel client.
        message.MessageClassifier ??=
            // The classifier passed by the client-author.
            messageClassifier ??
            // The internal global default classifier.
            PipelineMessageClassifier.Default;

        // Copy custom pipeline policies.
        message.PerCallPolicies = _perCallPolicies;
        message.PerTryPolicies = _perTryPolicies;
        message.BeforeTransportPolicies = _beforeTransportPolicies;

        foreach (var header in _requestHeaders)
        {
            message.Request.Headers.Add(header.Key, header.Value);
        }
    }

    private void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot make changes to RequestOptions after its first use.");
        }
    }
}
