// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel.Primitives;

/// <summary>
/// Options that can be used to control the behavior of a request sent by a client.
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

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestOptions"/> class
    /// </summary>
    public RequestOptions()
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="CancellationToken"/> used for the duration
    /// of the call to <see cref="ClientPipeline.Send(PipelineMessage)"/>.
    /// </summary>
    public CancellationToken CancellationToken
    {
        get => _cancellationToken;
        set
        {
            AssertNotFrozen();

            _cancellationToken = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that describes when a client's service method will
    /// raise an exception if the underlying response is considered an error.
    /// </summary>
    public ClientErrorBehaviors ErrorOptions
    {
        get => _errorOptions;
        set
        {
            AssertNotFrozen();

            _errorOptions = value;
        }
    }

    /// <summary>
    /// Adds the specified header and its value to the request's header
    /// collection. If a header with this name is already present in the
    /// collection, the value will be added to the comma-separated list of
    /// values associated with the header.
    /// </summary>
    /// <param name="name">The name of the header to add.</param>
    /// <param name="value">The value of the header.</param>
    public void AddHeader(string name, string value)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _headersUpdates ??= new();
        _headersUpdates.Add(new HeadersUpdate(HeaderOperation.Add, name, value));
    }

    /// <summary>
    /// Sets the specified header and its value in the request's header
    /// collection. If a header with this name is already present in the
    /// collection, the header's value will be replaced with the specified value.
    /// </summary>
    /// <param name="name">The name of the header to set.</param>
    /// <param name="value">The value of the header.</param>
    public void SetHeader(string name, string value)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(value, nameof(value));

        AssertNotFrozen();

        _headersUpdates ??= new();
        _headersUpdates.Add(new HeadersUpdate(HeaderOperation.Set, name, value));
    }

    /// <summary>
    /// Adds a <see cref="PipelinePolicy"/> into the pipeline for the duration
    /// of this request.
    /// </summary>
    /// <param name="policy">The <see cref="PipelinePolicy"/> to add to the
    /// pipeline.</param>
    /// <param name="position">The position of the policy in the pipeline.</param>
    /// <exception cref="ArgumentException">Thrown when the provided policy
    /// is <c>null</c>.</exception>
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

    /// <summary>
    /// Freeze this instance of <see cref="RequestOptions"/>.  After this method
    /// has been called, any attempt to set properties on the instance or call
    /// methods that would change its state will throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze() => _frozen = true;

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="RequestOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="RequestOptions"/> instance
    /// after <see cref="Freeze"/> has been called.</exception>
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
