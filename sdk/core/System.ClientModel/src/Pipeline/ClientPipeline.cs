// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
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

    private ClientPipeline(ReadOnlyMemory<PipelinePolicy> policies, int perCallIndex, int perTryIndex, int beforeTransportIndex)
    {
        if (perCallIndex > perTryIndex) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "perCallIndex cannot be greater than perTryIndex.");

        if (policies.Span[policies.Length - 1] is not PipelineTransport)
        {
            throw new ArgumentException("Last policy in the array must be of type 'PipelineTransport'.", nameof(policies));
        }

        _transport = (PipelineTransport)policies.Span[policies.Length - 1];
        _policies = policies;

        _perCallIndex = perCallIndex;
        _perTryIndex = perTryIndex;
        _beforeTransportIndex = beforeTransportIndex;
    }

    public static ClientPipeline Create()
        => Create(ClientPipelineOptions.Default,
            ReadOnlySpan<PipelinePolicy>.Empty,
            ReadOnlySpan<PipelinePolicy>.Empty,
            ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline Create(ClientPipelineOptions options, params PipelinePolicy[] perCallPolicies)
        => Create(options,
            perCallPolicies,
            ReadOnlySpan<PipelinePolicy>.Empty,
            ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline Create(
        ClientPipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies,
        ReadOnlySpan<PipelinePolicy> beforeTransportPolicies)
    {
        Argument.AssertNotNull(options, nameof(options));

        int pipelineLength = perCallPolicies.Length + perTryPolicies.Length + beforeTransportPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            pipelineLength += options.PerTryPolicies.Length;
        }

        if (options.PerCallPolicies != null)
        {
            pipelineLength += options.PerCallPolicies.Length;
        }

        if (options.BeforeTransportPolicies != null)
        {
            pipelineLength += options.BeforeTransportPolicies.Length;
        }

        pipelineLength++; // for retry policy
        pipelineLength++; // for transport

        PipelinePolicy[] policies = new PipelinePolicy[pipelineLength];

        int index = 0;

        perCallPolicies.CopyTo(policies.AsSpan(index));
        index += perCallPolicies.Length;

        if (options.PerCallPolicies != null)
        {
            options.PerCallPolicies.CopyTo(policies.AsSpan(index));
            index += options.PerCallPolicies.Length;
        }

        int perCallIndex = index;

        if (options.RetryPolicy != null)
        {
            policies[index++] = options.RetryPolicy;
        }
        else
        {
            policies[index++] = new ClientRetryPolicy();
        }

        perTryPolicies.CopyTo(policies.AsSpan(index));
        index += perTryPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            options.PerTryPolicies.CopyTo(policies.AsSpan(index));
            index += options.PerTryPolicies.Length;
        }

        int perTryIndex = index;

        TimeSpan networkTimeout = options.NetworkTimeout ?? DefaultNetworkTimeout;

        beforeTransportPolicies.CopyTo(policies.AsSpan(index));
        index += beforeTransportPolicies.Length;

        if (options.BeforeTransportPolicies != null)
        {
            options.BeforeTransportPolicies.CopyTo(policies.AsSpan(index));
            index += options.BeforeTransportPolicies.Length;
        }

        int beforeTransportIndex = index;

        if (options.Transport != null)
        {
            policies[index++] = options.Transport;
        }
        else
        {
            // Add default transport.
            policies[index++] = new HttpClientPipelineTransport(networkTimeout);
            //policies[index++] = HttpClientPipelineTransport.Shared;
        }

        return new ClientPipeline(policies, perCallIndex, perTryIndex, beforeTransportIndex); ;
    }

    public PipelineMessage CreateMessage() => _transport.CreateMessage();

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
        if (message.CustomRequestPipeline)
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

                return null!;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext() => ++_current < _policies.Count;

        public void Reset() => _current = -1;

        public void Dispose() { }
    }
}