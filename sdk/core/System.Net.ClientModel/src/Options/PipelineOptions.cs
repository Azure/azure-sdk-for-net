// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

/// <summary>
/// Controls the creation of the pipeline.
/// Works with RequestOptions, which controls the behavior of the pipeline.
/// </summary>
public class PipelineOptions
{
    //private readonly object _lock = new();
    private ClientPipeline? _pipeline;
    private bool _isFrozen;

    private bool _modified;

    private PipelinePolicy[]? _perCallPolicies;
    private PipelinePolicy[]? _perTryPolicies;
    private PipelinePolicy? _retryPolicy;
    private PipelineTransport? _transport;

    private TimeSpan? _networkTimeout;

    public PipelineOptions()
    {
    }

    public PipelineOptions(object client, ReadOnlyMemory<PipelinePolicy> policies)
    {
        if (client is null) throw new ArgumentNullException(nameof(client));

        ClientPipeline pipeline = ClientPipeline.Create(client.GetType(), policies);
        SetPipeline(pipeline);
    }

    // Copy Constructor
    internal PipelineOptions(PipelineOptions options)
    {
        _perCallPolicies = options.PerCallPolicies;
        _perTryPolicies = options.PerTryPolicies;
        _retryPolicy = options.RetryPolicy;
        _transport = options.Transport;
        _networkTimeout = options.NetworkTimeout;

        // Cache the pipeline for possible reuse, but don't freeze it yet.
        _pipeline = options.Pipeline;
    }

    internal bool IsFrozen => _isFrozen;

    internal void Freeze() => _isFrozen = true;

    internal bool Modified => _modified;

    internal void SetPipeline(ClientPipeline pipeline)
    {
        _pipeline = pipeline;
        Freeze();
    }

    internal ClientPipeline Pipeline
    {
        get
        {
            if (_pipeline is null || !IsFrozen)
            {
                throw new InvalidOperationException("ClientPipeline.Create must be called to cache a pipeline instance prior to accessing PipelineOptions.Pipeline");
            }

            return _pipeline;
        }
    }

    //public virtual ClientPipeline GetPipeline()
    //{
    //    if (_pipeline != null) return _pipeline;

    //    lock (_lock)
    //    {
    //        if (IsFrozen)
    //        {
    //            if (_pipeline == null)
    //            {
    //                throw new InvalidOperationException("Unexpected state: null pipeline and frozen options.");
    //            }

    //            return _pipeline;
    //        }

    //        ClientPipeline.Create(this);

    //        Freeze();

    //        return _pipeline;
    //    }
    //}

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
            _modified = true;
        }
    }

    public PipelinePolicy[]? PerTryPolicies
    {
        get => _perTryPolicies;
        set
        {
            AssertNotFrozen();
            _perTryPolicies = value;
            _modified = true;
        }
    }

    public PipelinePolicy? RetryPolicy
    {
        get => _retryPolicy;
        set
        {
            AssertNotFrozen();
            _retryPolicy = value;
            _modified = true;
        }
    }

    public PipelineTransport? Transport
    {
        get => _transport;
        set
        {
            AssertNotFrozen();
            _transport = value;
            _modified = true;
        }
    }

    public TimeSpan? NetworkTimeout
    {
        get => _networkTimeout;
        set
        {
            AssertNotFrozen();
            _networkTimeout = value;
            _modified = true;
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
