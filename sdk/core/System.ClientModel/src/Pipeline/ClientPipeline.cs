// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public partial class ClientPipeline
{
    private readonly int _perCallIndex;
    private readonly int _perTryIndex;

    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly PipelineTransport _transport;

    private ClientPipeline(ReadOnlyMemory<PipelinePolicy> policies, int perCallIndex, int perTryIndex)
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
    }

    public static ClientPipeline Create(PipelineOptions options, params PipelinePolicy[] perCallPolicies)
        => Create(options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline Create(
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
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

        if (options.Transport != null)
        {
            pipeline[index++] = options.Transport;
        }
        else
        {
            // Add default transport.
            pipeline[index++] = HttpClientPipelineTransport.Shared;
        }

        return new ClientPipeline(pipeline, perCallIndex, perTryIndex);
    }

    // TODO: note that without a common base type, nothing validates that MessagePipeline
    // and Azure.Core.HttpPipeline have the same API shape. This is something a human
    // must keep track of if we wanted to add a common base class later.
    public PipelineMessage CreateMessage() => _transport.CreateMessage();

    public void Send(PipelineMessage message)
    {
        PipelineProcessor processor = GetProcessor(message);
        processor.ProcessNext();
    }

    public async ValueTask SendAsync(PipelineMessage message)
    {
        PipelineProcessor processor = GetProcessor(message);
        await processor.ProcessNextAsync().ConfigureAwait(false);
    }

    private PipelineProcessor GetProcessor(PipelineMessage message)
    {
        if (message.CustomRequestPipeline)
        {
            return new RequestOptionsProcessor(message,
                _policies,
                message.PerCallPolicies,
                message.PerTryPolicies,
                _perCallIndex,
                _perTryIndex);
        }

        return new ClientPipelineProcessor(message, _policies);
    }

    private class ClientPipelineProcessor : PipelineProcessor
    {
        private readonly PipelineMessage _message;
        private ReadOnlyMemory<PipelinePolicy> _policies;

        public ClientPipelineProcessor(PipelineMessage message,
            ReadOnlyMemory<PipelinePolicy> policies)
        {
            _message = message;
            _policies = policies;
        }

        public override bool ProcessNext()
        {
            if (_policies.Length == 0)
            {
                return false;
            }

            var next = _policies.Span[0];
            _policies = _policies.Slice(1);

            next.Process(_message, this);

            return _policies.Length > 0;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            if (_policies.Length == 0)
            {
                return false;
            }

            var next = _policies.Span[0];
            _policies = _policies.Slice(1);

            await next.ProcessAsync(_message, this).ConfigureAwait(false);

            return _policies.Length > 0;
        }
    }
}
