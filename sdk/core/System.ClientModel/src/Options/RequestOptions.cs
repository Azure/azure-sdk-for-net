// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
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

    private CancellationToken _cancellationToken = CancellationToken.None;
    private ClientErrorBehaviors _errorOptions = ClientErrorBehaviors.Default;

    private PipelinePolicy[]? _perCallPolicies;
    private PipelinePolicy[]? _perTryPolicies;
    private PipelinePolicy[]? _beforeTransportPolicies;

    private List<HeadersUpdate>? _headersUpdates;

    public RequestOptions()
    {
    }

    public CancellationToken CancellationToken
    {
        get => _cancellationToken;
        set
        {
            AssertNotFrozen();

            _cancellationToken = value;
        }
    }

    public ClientErrorBehaviors ErrorOptions
    {
        get => _errorOptions;
        set
        {
            AssertNotFrozen();

            _errorOptions = value;
        }
    }

    public void AddHeader(string name, string value)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _headersUpdates ??= new();
        _headersUpdates.Add(new HeadersUpdate(HeaderOperation.Add, name, value));
    }

    public void SetHeader(string name, string value)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _headersUpdates ??= new();
        _headersUpdates.Add(new HeadersUpdate(HeaderOperation.Set, name, value));
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
        Freeze();

        // Set the cancellation token on the message so pipeline policies
        // will have access to it as the message flows through the pipeline.
        // This doesn't affect Azure.Core-based clients because the HttpMessage
        // cancellation token will be set again in HttpPipeline.Send.
        message.CancellationToken = CancellationToken;

        // Copy custom pipeline policies to the message.
        message.PerCallPolicies = _perCallPolicies;
        message.PerTryPolicies = _perTryPolicies;
        message.BeforeTransportPolicies = _beforeTransportPolicies;

        // Apply adds and sets to request headers if applicable.
        if (_headersUpdates is not null)
        {
            foreach (var update in _headersUpdates)
            {
                switch (update.Operation)
                {
                    case HeaderOperation.Add:

                        message.Request.Headers.Add(update.HeaderName, update.HeaderValue);
                        break;
                    case HeaderOperation.Set:
                        message.Request.Headers.Set(update.HeaderName, update.HeaderValue);
                        break;
                    default:
                        throw new InvalidOperationException("Unrecognized header update operation value.");
                }
            }
        }
    }

    public virtual void Freeze() => _frozen = true;

    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a RequestOptions instance after it has been passed to a client method.");
        }
    }

    private readonly struct HeadersUpdate
    {
        public HeadersUpdate(HeaderOperation operation, string name, string value)
        {
            Operation = operation;
            HeaderName = name;
            HeaderValue = value;
        }

        public HeaderOperation Operation { get; }
        public string HeaderName { get; }
        public string HeaderValue { get; }
    }

    private enum HeaderOperation
    {
        Add,
        Set
    }
}
