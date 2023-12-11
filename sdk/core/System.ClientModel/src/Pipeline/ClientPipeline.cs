// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class ClientPipeline
{
    private readonly int _perCallIndex;
    private readonly int _perTryIndex;
    private readonly int _beforeTransportIndex;

    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly PipelineTransport _transport;

    private ClientPipeline(ReadOnlyMemory<PipelinePolicy> policies, int perCallIndex, int perTryIndex, int beforeTransportIndex)
    {
        if (perCallIndex > 255) throw new ArgumentOutOfRangeException(nameof(perCallIndex), "Cannot create pipeline with more than 255 policies.");
        if (perTryIndex > 255) throw new ArgumentOutOfRangeException(nameof(perTryIndex), "Cannot create pipeline with more than 255 policies.");
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

    public static ClientPipeline Create(PipelineOptions options, params PipelinePolicy[] perCallPolicies)
        => Create(options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty, ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline Create(
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies,
        ReadOnlySpan<PipelinePolicy> beforeTransportPolicies)
    {
        if (options is null) throw new ArgumentNullException(nameof(options));

        int pipelineLength = perCallPolicies.Length + perTryPolicies.Length;

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

        pipelineLength += options.RetryPolicy is null ? 0 : 1;

        pipelineLength++; // for response buffering policy
        pipelineLength++; // for transport

        PipelinePolicy[] pipeline = new PipelinePolicy[pipelineLength];

        int index = 0;

        perCallPolicies.CopyTo(pipeline.AsSpan(index));
        index += perCallPolicies.Length;

        if (options.PerCallPolicies != null)
        {
            options.PerCallPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.PerCallPolicies.Length;
        }

        int perCallIndex = index;

        if (options.RetryPolicy != null)
        {
            pipeline[index++] = options.RetryPolicy;
        }

        perTryPolicies.CopyTo(pipeline.AsSpan(index));
        index += perTryPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            options.PerTryPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.PerTryPolicies.Length;
        }

        int perTryIndex = index;

        TimeSpan networkTimeout = options.NetworkTimeout ?? ResponseBufferingPolicy.DefaultNetworkTimeout;
        ResponseBufferingPolicy bufferingPolicy = new(networkTimeout);
        pipeline[index++] = bufferingPolicy;

        beforeTransportPolicies.CopyTo(pipeline.AsSpan(index));
        index += beforeTransportPolicies.Length;

        if (options.BeforeTransportPolicies != null)
        {
            options.BeforeTransportPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.BeforeTransportPolicies.Length;
        }

        int beforeTransportIndex = index;

        if (options.Transport != null)
        {
            pipeline[index++] = options.Transport;
        }
        else
        {
            // Add default transport.
            pipeline[index++] = HttpClientPipelineTransport.Shared;
        }

        return new ClientPipeline(pipeline, perCallIndex, perTryIndex, beforeTransportIndex);
    }

    // TODO: note that without a common base type, nothing validates that MessagePipeline
    // and Azure.Core.HttpPipeline have the same API shape. This is something a human
    // must keep track of if we wanted to add a common base class later.
    public PipelineMessage CreateMessage() => _transport.CreateMessage();

    public void Send(PipelineMessage message)
    {
        IEnumerable<PipelinePolicy> policies = GetProcessor(message);
        IEnumerator<PipelinePolicy> enumerator = policies.GetEnumerator();
        if (enumerator.MoveNext())
        {
            enumerator.Current.Process(message, policies);
        }
    }

    public async ValueTask SendAsync(PipelineMessage message)
    {
        IEnumerable<PipelinePolicy> policies = GetProcessor(message);
        IEnumerator<PipelinePolicy> enumerator = policies.GetEnumerator();
        if (enumerator.MoveNext())
        {
            await enumerator.Current.ProcessAsync(message, policies).ConfigureAwait(false);
        }
    }

    private IEnumerable<PipelinePolicy> GetProcessor(PipelineMessage message)
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

    private struct PipelineProcessor : IEnumerable<PipelinePolicy>
    {
        private readonly PolicyEnumerator _enumerator;

        public PipelineProcessor(ReadOnlyMemory<PipelinePolicy> policies)
        {
            _enumerator = new(policies);
        }

        public readonly IEnumerator<PipelinePolicy> GetEnumerator()
            => _enumerator;

        readonly IEnumerator IEnumerable.GetEnumerator()
            => _enumerator;
    }

    private class PolicyEnumerator : IEnumerator<PipelinePolicy>
    {
        private readonly ReadOnlyMemory<PipelinePolicy> _policies;
        private int _current;

        public PolicyEnumerator(ReadOnlyMemory<PipelinePolicy> policies)
        {
            _policies = policies;
            _current = -1;
        }

        public PolicyEnumerator GetEnumerator() => this;

        public bool MoveNext()
        {
            _current++;
            return _current < _policies.Length;
        }

        public void Reset()
        {
            _current = 0;
        }

        public void Dispose() { }

        public PipelinePolicy Current => _policies.Span[_current];

        object IEnumerator.Current => Current;
    }
}
