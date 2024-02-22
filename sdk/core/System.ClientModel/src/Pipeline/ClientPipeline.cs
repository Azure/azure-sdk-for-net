﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public sealed partial class ClientPipeline
{
    internal static TimeSpan DefaultNetworkTimeout { get; } = TimeSpan.FromSeconds(100);

    private readonly int _perCallIndex;
    private readonly int _perTryIndex;
    private readonly int _beforeTransportIndex;

    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly PipelineTransport _transport;

    private readonly TimeSpan _networkTimeout;

    private ClientPipeline(ReadOnlyMemory<PipelinePolicy> policies, TimeSpan networkTimeout, int perCallIndex, int perTryIndex, int beforeTransportIndex)
    {
        if (policies.Span[policies.Length - 1] is not PipelineTransport)
        {
            throw new ArgumentException("The last policy must be of type 'PipelineTransport'.", nameof(policies));
        }

        Debug.Assert(perCallIndex <= perTryIndex);
        Debug.Assert(perTryIndex <= beforeTransportIndex);

        _transport = (PipelineTransport)policies.Span[policies.Length - 1];
        _policies = policies;

        _perCallIndex = perCallIndex;
        _perTryIndex = perTryIndex;
        _beforeTransportIndex = beforeTransportIndex;

        _networkTimeout = networkTimeout;
    }

    #region Factory methods for creating a pipeline instance

    public static ClientPipeline Create(ClientPipelineOptions? options = default)
        => Create(options ?? ClientPipelineOptions.Default,
            ReadOnlySpan<PipelinePolicy>.Empty,
            ReadOnlySpan<PipelinePolicy>.Empty,
            ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline Create(
        ClientPipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies,
        ReadOnlySpan<PipelinePolicy> beforeTransportPolicies)
    {
        Argument.AssertNotNull(options, nameof(options));

        options.Freeze();

        // Add length of client-specific policies.
        int pipelineLength = perCallPolicies.Length + perTryPolicies.Length + beforeTransportPolicies.Length;

        // Add length of end-user provided policies.
        pipelineLength += options.PerTryPolicies?.Length ?? 0;
        pipelineLength += options.PerCallPolicies?.Length ?? 0;
        pipelineLength += options.BeforeTransportPolicies?.Length ?? 0;

        pipelineLength++; // for retry policy
        pipelineLength++; // for transport

        PipelinePolicy[] policies = new PipelinePolicy[pipelineLength];

        int index = 0;

        // Per call policies come before the retry policy.
        perCallPolicies.CopyTo(policies.AsSpan(index));
        index += perCallPolicies.Length;

        if (options.PerCallPolicies != null)
        {
            options.PerCallPolicies.CopyTo(policies.AsSpan(index));
            index += options.PerCallPolicies.Length;
        }

        int perCallIndex = index;

        // Add retry policy.
        policies[index++] = options.RetryPolicy ?? ClientRetryPolicy.Default;

        // Per try policies come after the retry policy.
        perTryPolicies.CopyTo(policies.AsSpan(index));
        index += perTryPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            options.PerTryPolicies.CopyTo(policies.AsSpan(index));
            index += options.PerTryPolicies.Length;
        }

        int perTryIndex = index;

        // Before transport policies come before the transport.
        beforeTransportPolicies.CopyTo(policies.AsSpan(index));
        index += beforeTransportPolicies.Length;

        if (options.BeforeTransportPolicies != null)
        {
            options.BeforeTransportPolicies.CopyTo(policies.AsSpan(index));
            index += options.BeforeTransportPolicies.Length;
        }

        int beforeTransportIndex = index;

        // Add the transport.
        policies[index++] = options.Transport ?? HttpClientPipelineTransport.Shared;

        return new ClientPipeline(policies,
            options.NetworkTimeout ?? DefaultNetworkTimeout,
            perCallIndex, perTryIndex, beforeTransportIndex);
    }

    #endregion

    public PipelineMessage CreateMessage()
    {
        PipelineMessage message = _transport.CreateMessage();
        message.NetworkTimeout = _networkTimeout;
        return message;
    }

    public void Send(PipelineMessage message)
    {
        IReadOnlyList<PipelinePolicy> policies = GetProcessor(message);
        policies[0].Process(message, policies, 0);
    }

    public async ValueTask SendAsync(PipelineMessage message)
    {
        IReadOnlyList<PipelinePolicy> policies = GetProcessor(message);
        await policies[0].ProcessAsync(message, policies, 0).ConfigureAwait(false);
    }

    private IReadOnlyList<PipelinePolicy> GetProcessor(PipelineMessage message)
    {
        if (message.UseCustomRequestPipeline)
        {
            return new RequestOptionsProcessor(_policies,
                message.PerCallPolicies,
                message.PerTryPolicies,
                message.BeforeTransportPolicies,
                _perCallIndex,
                _perTryIndex,
                _beforeTransportIndex);
        }

        return new PipelineProcessor(_policies);
    }

    private struct PipelineProcessor : IReadOnlyList<PipelinePolicy>
    {
        private readonly ReadOnlyMemory<PipelinePolicy> _policies;
        private PolicyEnumerator? _enumerator;

        public PipelineProcessor(ReadOnlyMemory<PipelinePolicy> policies)
            => _policies = policies;

        public PipelinePolicy this[int index] => _policies.Span[index];

        public int Count => _policies.Length;

        public IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator ??= new(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    private class PolicyEnumerator : IEnumerator<PipelinePolicy>
    {
        private readonly IReadOnlyList<PipelinePolicy> _policies;
        private int _current;

        public PolicyEnumerator(IReadOnlyList<PipelinePolicy> policies)
        {
            _policies = policies;
            _current = -1;
        }

        public PipelinePolicy Current
        {
            get
            {
                if (_current >= 0 && _current < _policies.Count)
                {
                    return _policies[_current];
                }

                throw new InvalidOperationException("'Current' is outside the bounds of the policy collection.");
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext() => ++_current < _policies.Count;

        public void Reset() => _current = -1;

        public void Dispose() { }
    }
}
