// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions, which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    private readonly object _lock = new();
    private MessagePipeline? _pipeline;

    // TODO: don't freeze but track changes
    private volatile bool _isFrozen;

    private PipelinePolicy[]? _perCallPolicies;
    private PipelinePolicy[]? _perTryPolicies;
    private PipelinePolicy? _retryPolicy;
    private PipelineTransport? _transport;

    private string? _serviceVersion;
    private TimeSpan? _networkTimeout;
    private MessageClassifier? _messageClassifier;

    public PipelineOptions()
    {
    }

    public virtual MessagePipeline GetPipeline()
    {
        if (_pipeline != null) return _pipeline;

        lock (_lock)
        {
            if (IsFrozen)
            {
                if (_pipeline == null)
                {
                    throw new InvalidOperationException("Unexpected state: null pipeline and frozen options.");
                }

                return _pipeline;
            }

            _pipeline = MessagePipeline.Create(this);

            Freeze();

            return _pipeline;
        }
    }

    private bool IsFrozen => _isFrozen;

    private void Freeze() => _isFrozen = true;

    #region Pipeline creation options

    // Note that all properties on PipelineOptions are nullable.
    // This gives us the ability to understand whether a caller passed them
    // as input or whether anything we add/set on PipelineOptions was set
    // internally.  If a property on PipelineOptions has a null value initially,
    // we will set a default value for it when options is frozen.

    public PipelinePolicy[]? PerCallPolicies
    {
        get => _perCallPolicies;
        set
        {
            AssertNotFrozen();
            _perCallPolicies = value;
        }
    }

    public PipelinePolicy[]? PerTryPolicies
    {
        get => _perTryPolicies;
        set
        {
            AssertNotFrozen();
            _perTryPolicies = value;
        }
    }

    public PipelinePolicy? RetryPolicy
    {
        get => _retryPolicy;
        set
        {
            AssertNotFrozen();
            _retryPolicy = value;
        }
    }

    public PipelineTransport? Transport
    {
        get => _transport;
        set
        {
            AssertNotFrozen();
            _transport = value;
        }
    }

    public string? ServiceVersion
    {
        get => _serviceVersion;
        set
        {
            AssertNotFrozen();
            _serviceVersion = value;
        }
    }

    public TimeSpan? NetworkTimeout
    {
        get => _networkTimeout;
        set
        {
            // This one doesn't freeze with the pipeline
            _networkTimeout = value;
        }
    }

    public virtual MessageClassifier? MessageClassifier
    {
        get => _messageClassifier;
        set
        {
            // This one doesn't freeze with the pipeline
            _messageClassifier = value;
        }
    }

    #endregion

    private void AssertNotFrozen()
    {
        if (IsFrozen)
        {
            throw new InvalidOperationException("Cannot modify PipelineOptions after the pipeline has been created.");
        }
    }
}
