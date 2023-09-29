// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel.Rest.Core;
using System.Threading;

namespace System.ServiceModel.Rest;

// Make options freezable
public class PipelineOptions
{
    private object _lock = new object();
    private MessagePipeline? _pipeline;
    private volatile bool _isFrozen;

    private IPipelinePolicy<PipelineMessage>? _retryPolicy;
    private IPipelinePolicy<PipelineMessage>? _loggingPolicy;
    private PipelineTransport<PipelineMessage> _transport;
    private ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _perTryPolicies;
    private ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _perCallPolicies;

    public PipelineOptions(PipelineTransport<PipelineMessage> transport)
    {
        _transport = transport;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual MessagePipeline GetPipeline()
    {
        if (_pipeline != null) return _pipeline;

        lock (_lock) {
            if (IsFrozen) {
                Debug.Assert(_pipeline != null);
                return _pipeline!;
            }
            _pipeline = MessagePipeline.Create(this);
            Freeze();
            return _pipeline;
        }
    }

    protected bool IsFrozen => _isFrozen;
    protected void Freeze() => _isFrozen = true;

    public ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> PerTryPolicies {
        get => _perTryPolicies;
        set {
            AssertNotFrozen();
            _perTryPolicies = value;
        }
    }

    public ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> PerCallPolicies {
        get => _perCallPolicies;
        set {
            AssertNotFrozen();
            _perCallPolicies = value;
        }
    }

    public IPipelinePolicy<PipelineMessage>? RetryPolicy {
        get => _retryPolicy;
        set {
            AssertNotFrozen();
            _retryPolicy = value;
        }
    }

    public IPipelinePolicy<PipelineMessage>? LoggingPolicy {
        get => _loggingPolicy;
        set {
            AssertNotFrozen();
            _loggingPolicy = value;
        }
    }
    public PipelineTransport<PipelineMessage> Transport {
        get => _transport;
        private set {
            AssertNotFrozen();
            _transport = value;
        }
    }

    public static IPipelinePolicy<PipelineMessage>? DefaultRetryPolicy { get; set; }

    public static IPipelinePolicy<PipelineMessage> DefaultLoggingPolicy { get; set; } = new ConsoleLoggingPolicy();

    public static PipelineTransport<PipelineMessage>? DefaultTransport { get; set; }

    public static CancellationToken DefaultCancellationToken { get; set; } = Threading.CancellationToken.None;

    protected void AssertNotFrozen()
    {
        if (IsFrozen) throw new Exception("the object is frozen");
    }
}
