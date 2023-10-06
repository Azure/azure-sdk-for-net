// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// No: This is the one that works on all the abstractions without introducing dependencies on e.g. Http
//
// This is the one that makes assumptions about the same of the message, that it is a PipelineMessage,
// and with that, assumptions that the policy type is a PipelinePolicy that takes a PipelineMessage.
// TODO: pus this through.

public class MessagePipeline : Pipeline<PipelineMessage>
{
    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly MessagePipelineTransport _transport;

    public MessagePipeline(
        MessagePipelineTransport transport,
        ReadOnlyMemory<PipelinePolicy> policies)
    {
        _transport = transport;
        PipelinePolicy[] larger = new PipelinePolicy[policies.Length + 1];
        policies.Span.CopyTo(larger);
        larger[policies.Length] = new MessagePipelineTransportPolicy(_transport);
        _policies = larger;
    }

    // TODO: This is ugly, rethink a biut
    private MessagePipeline(ReadOnlyMemory<PipelinePolicy> policies,
        MessagePipelineTransport transport)
    {
        // Note: we only keep transport to use to call CreateMessage on it later.
        _transport = transport;
        _policies = policies;
    }

    public static MessagePipeline Create(
        RequestOptions options,
        params PipelinePolicy[] perTryPolicies)
        => Create(options, perTryPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static MessagePipeline Create(
        RequestOptions options,
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
        pipelineLength += options.LoggingPolicy is null ? 0 : 1;

        pipelineLength++; // for response buffering policy
        pipelineLength++; // for transport

        PipelinePolicy[] pipeline = new PipelinePolicy[pipelineLength];

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

        // TODO: add NetworkTimeout to RetryOptions
        // TODO: would it make sense for this to live on options instead?
        ResponseBufferingPolicy bufferingPolicy = new(TimeSpan.FromSeconds(100), options.BufferResponse);
        pipeline[index++] = bufferingPolicy;

        // Note: this fixes this at HTTP, which we should be aware of!
        MessagePipelineTransport transport = options.Transport ?? new HttpPipelineMessageTransport();

        pipeline[index++] = new MessagePipelineTransportPolicy(transport);

        return new MessagePipeline(pipeline, transport);
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        return _transport.CreateMessage(options, classifier);
    }

    public override void Send(PipelineMessage message)
    {
        //PipelineEnumerator enumerator = new MessagePipelineExecutor(_policies, message);
        //enumerator.ProcessNext();

        ReadOnlyMemory<PipelinePolicy> nextPolicy = (ReadOnlyMemory<PipelinePolicy>)_policies.Slice(1);

        _policies.Span[0].Process(message, nextPolicy);

        message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
    }

    public override async ValueTask SendAsync(PipelineMessage message)
    {
        //PipelineEnumerator enumerator = new MessagePipelineExecutor(_policies, message);
        //await enumerator.ProcessNextAsync().ConfigureAwait(false);

        await _policies.Span[0].ProcessAsync(message, _policies.Slice(1)).ConfigureAwait(false);

        message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
    }
}
