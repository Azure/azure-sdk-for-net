// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

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

    private readonly PipelineRequestHeaders _addHeaders;

    public RequestOptions()
    {
        CancellationToken = CancellationToken.None;
        ErrorOptions = ClientErrorBehaviors.Default;

        _addHeaders = new ArrayBackedRequestHeaders();
    }

    public CancellationToken CancellationToken { get; set; }

    public ClientErrorBehaviors ErrorOptions { get; set; }

    public void AddHeader(string name, string value)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _addHeaders.Add(name, value);
    }

    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        Argument.AssertNotNull(policy, nameof(policy));

        AssertNotFrozen();

        switch (position)
        {
            case PipelinePosition.PerCall:
                _perCallPolicies = ClientPipelineOptions.AddPolicy(policy, _perCallPolicies);
                break;
            case PipelinePosition.PerTry:
                _perTryPolicies = ClientPipelineOptions.AddPolicy(policy, _perTryPolicies);
                break;
            case PipelinePosition.BeforeTransport:
                _beforeTransportPolicies = ClientPipelineOptions.AddPolicy(policy, _beforeTransportPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }

    // Set options on the message before sending it through the pipeline.
    internal void Apply(PipelineMessage message)
    {
        _frozen = true;

        // Set the cancellation token on the message so pipeline policies
        // will have access to it as the message flows through the pipeline.
        // This doesn't affect Azure.Core-based clients because the HttpMessage
        // cancellation token will be set again in HttpPipeline.Send.
        message.CancellationToken = CancellationToken;

        // We don't overwrite the classifier on the message if it's already set.
        // This preserves any values set by the client author, and is also
        // needed for Azure.Core-based clients so we don't overwrite a default
        // Azure.Core ResponseClassifier.
        message.MessageClassifier ??= PipelineMessageClassifier.Default;

        // Copy custom pipeline policies to the message.
        message.PerCallPolicies = _perCallPolicies;
        message.PerTryPolicies = _perTryPolicies;
        message.BeforeTransportPolicies = _beforeTransportPolicies;

        // Add the values of any headers set via AddHeader.
        foreach (var header in _addHeaders)
        {
            message.Request.Headers.Add(header.Key, header.Value);
        }
    }

    private void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a RequestOptions instance after it has been passed to a client method.");
        }
    }
}
