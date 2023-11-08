// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Net.ClientModel.Internal.Core;

namespace System.Net.ClientModel.Core;

public class MessagePipeline
{
    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly PipelineTransport _transport;

    private MessagePipeline(ReadOnlyMemory<PipelinePolicy> policies)
    {
        if (policies.Span[policies.Length - 1] is not PipelineTransport)
        {
            throw new ArgumentException("Last policy in the array must be of type 'PipelineTransport'.", nameof(policies));
        }

        _transport = (PipelineTransport)policies.Span[policies.Length - 1];
        _policies = policies;
    }

    public static MessagePipeline GetPipeline(PipelineOptions options, params PipelinePolicy[] perCallPolicies)
        => GetPipeline(options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static MessagePipeline GetPipeline(PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
    {
        if (options.IsFrozen)
        {
            return options.Pipeline;
        }

        MessagePipeline pipeline = Create(options, perCallPolicies, perTryPolicies);

        // Set and freeze the pipeline.
        options.SetPipeline(pipeline);

        return pipeline;
    }

    public static MessagePipeline GetPipeline(RequestOptions options, params PipelinePolicy[] perCallPolicies)
        => GetPipeline(options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static MessagePipeline GetPipeline(RequestOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
    {
        // If PipelineOptions haven't been modified, we don't need to create a new pipeline.
        if (!options.PipelineOptions.Modified)
        {
            options.PipelineOptions.Freeze();
            return options.PipelineOptions.Pipeline;
        }

        return GetPipeline(options.PipelineOptions, perCallPolicies, perTryPolicies);
    }

    // Simplest factory method: construct a pipeline from a list of policies
    internal static MessagePipeline Create(ReadOnlyMemory<PipelinePolicy> policies)
        => new MessagePipeline(policies);

    // Builder from options: lets a client-author specify policies without modifying
    // client-user's passed-in options.
    internal static MessagePipeline Create(
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
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
            // TODO: Note this adds an HTTP dependency we should be aware of.
            pipeline[index++] = HttpClientPipelineTransport.Shared;
        }

        return new MessagePipeline(pipeline);
    }

    // TODO: note that without a common base type, nothing validates that MessagePipeline
    // and Azure.Core.HttpPipeline have the same API shape. This is something a human
    // must keep track of if we wanted to add a common base class later.
    public ClientMessage CreateMessage(RequestOptions options)
    {
        ClientMessage message = _transport.CreateMessage();
        options.Apply(message);
        return message;
    }

    public void Send(ClientMessage message)
    {
        PipelineEnumerator enumerator = new MessagePipelineExecutor(message, _policies);
        enumerator.ProcessNext();
    }

    public async ValueTask SendAsync(ClientMessage message)
    {
        PipelineEnumerator enumerator = new MessagePipelineExecutor(message, _policies);
        await enumerator.ProcessNextAsync().ConfigureAwait(false);
    }

    private class MessagePipelineExecutor : PipelineEnumerator
    {
        private readonly ClientMessage _message;
        private ReadOnlyMemory<PipelinePolicy> _policies;

        public MessagePipelineExecutor(
            ClientMessage message,
            ReadOnlyMemory<PipelinePolicy> policies)
        {
            _message = message;
            _policies = policies;
        }

        public override int Length => _policies.Length;

        public override bool ProcessNext()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            first.Process(_message, this);
            return _policies.Length > 0;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            await first.ProcessAsync(_message, this).ConfigureAwait(false);
            return _policies.Length > 0;
        }
    }
}
