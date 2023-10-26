// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

public class MessagePipeline : Pipeline<PipelineMessage>
{
    private readonly ReadOnlyMemory<PipelinePolicy<PipelineMessage>> _policies;
    private readonly PipelineTransport<PipelineMessage> _transport;

    public MessagePipeline(
        PipelineTransport<PipelineMessage> transport,
        ReadOnlyMemory<PipelinePolicy<PipelineMessage>> policies)
    {
        _transport = transport;
        var larger = new PipelinePolicy<PipelineMessage>[policies.Length + 1];
        policies.Span.CopyTo(larger);
        larger[policies.Length] = transport;
        _policies = larger;
    }

    private MessagePipeline(ReadOnlyMemory<PipelinePolicy<PipelineMessage>> policies)
    {
        _transport = (PipelineTransport<PipelineMessage>)policies.Span[policies.Length - 1];
        _policies = policies;
    }

    public static MessagePipeline Create(
        PipelineOptions options,
        params PipelinePolicy<PipelineMessage>[] perTryPolicies)
        => Create(options, perTryPolicies, ReadOnlySpan<PipelinePolicy<PipelineMessage>>.Empty);

    public static MessagePipeline Create(
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy<PipelineMessage>> perCallPolicies,
        ReadOnlySpan<PipelinePolicy<PipelineMessage>> perTryPolicies)
    {
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
        pipelineLength += options.LoggingPolicy is null ? 0 : 1;

        pipelineLength++; // for response buffering policy
        pipelineLength++; // for transport

        PipelinePolicy<PipelineMessage>[] pipeline
            = new PipelinePolicy<PipelineMessage>[pipelineLength];

        int index = 0;

        perCallPolicies.CopyTo(pipeline.AsSpan(index));
        index += perCallPolicies.Length;

        if (options.PerCallPolicies != null)
        {
            options.PerCallPolicies.CopyTo(pipeline.AsSpan());
            index += options.PerCallPolicies.Length;
        }

        if (options.RetryPolicy != null)
        {
            pipeline[index++] = options.RetryPolicy;
        }

        if (options.PerTryPolicies != null)
        {
            options.PerTryPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.PerTryPolicies.Length;
        }

        perTryPolicies.CopyTo(pipeline.AsSpan(index));
        index += perTryPolicies.Length;

        if (options.LoggingPolicy != null)
        {
            pipeline[index++] = options.LoggingPolicy;
        }

        TimeSpan networkTimeout = options.NetworkTimeout ?? PipelineOptions.DefaultNetworkTimeout;
        ResponseBufferingPolicy bufferingPolicy = new(networkTimeout);
        pipeline[index++] = bufferingPolicy;

        if (options.Transport != null)
        {
            pipeline[index++] = options.Transport;
        }
        else
        {
            // Add default transport.
            // TODO: Note this adds an HTTP dependency we should be aware of.
            pipeline[index++] = HttpPipelineMessageTransport.Shared;
        }

        return new MessagePipeline(pipeline);
    }

    public override PipelineMessage CreateMessage()
        => _transport.CreateMessage();

    public override void Send(PipelineMessage message)
    {
        IPipelineEnumerator enumerator = new MessagePipelineExecutor(message, _policies);
        enumerator.ProcessNext();
    }

    public override async ValueTask SendAsync(PipelineMessage message)
    {
        IPipelineEnumerator enumerator = new MessagePipelineExecutor(message, _policies);
        await enumerator.ProcessNextAsync().ConfigureAwait(false);
    }

    private struct MessagePipelineExecutor : IPipelineEnumerator
    {
        private PipelineMessage _message;
        private ReadOnlyMemory<PipelinePolicy<PipelineMessage>> _policies;

        public MessagePipelineExecutor(
            PipelineMessage message,
            ReadOnlyMemory<PipelinePolicy<PipelineMessage>> policies )
        {
            _message = message;
            _policies = policies;
        }

        public int Length => _policies.Length;

        public bool ProcessNext()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            first.Process(_message, this);
            return _policies.Length > 0;
        }

        public async ValueTask<bool> ProcessNextAsync()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            await first.ProcessAsync(_message, this).ConfigureAwait(false);
            return _policies.Length > 0;
        }
    }
}
