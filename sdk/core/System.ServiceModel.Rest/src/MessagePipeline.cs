// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipeline : Pipeline<PipelineMessage>
{
    private readonly ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _policies;
    private readonly PipelineTransport<PipelineMessage> _transport;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="transport"></param>
    /// <param name="policies"></param>
    public MessagePipeline(
        PipelineTransport<PipelineMessage> transport,
        ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> policies
    )
    {
        _transport = transport;
        var larger = new IPipelinePolicy<PipelineMessage>[policies.Length + 1];
        policies.Span.CopyTo(larger);
        larger[policies.Length] = transport;
        _policies = larger;
    }

    private MessagePipeline(ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> policies)
    {
        _transport = (PipelineTransport<PipelineMessage>)policies.Span[policies.Length - 1];
        _policies = policies;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="defaultTransport">TDODO: this should be removed</param>
    /// <param name="options">User settings and policies</param>
    /// <param name="clientPerTryPolicies">client implementation policies</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MessagePipeline Create(
        PipelineTransport<PipelineMessage> defaultTransport, // TODO: this parameter should be removed
        RequestOptions options,
        params IPipelinePolicy<PipelineMessage>[] clientPerTryPolicies)
        => Create(defaultTransport, options, clientPerTryPolicies, ReadOnlySpan<IPipelinePolicy<PipelineMessage>>.Empty);

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="defaultTransport">TDODO: this should be removed</param>
    /// <param name="options">User settings and policies</param>
    /// <param name="clientPerTryPolicies">client implementation policies</param>
    /// <param name="clientPerCallPolicies">client implementation policies</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MessagePipeline Create(
        PipelineTransport<PipelineMessage> defaultTransport, // TODO: this parameter should be removed
        RequestOptions options,
        ReadOnlySpan<IPipelinePolicy<PipelineMessage>> clientPerTryPolicies,
        ReadOnlySpan<IPipelinePolicy<PipelineMessage>> clientPerCallPolicies)
    {
        int pipelineLength = clientPerCallPolicies.Length + clientPerTryPolicies.Length;

        if (options.PerTryPolicies != null) pipelineLength += options.PerTryPolicies.Length;
        if (options.PerCallPolicies != null) pipelineLength += options.PerCallPolicies.Length;
        pipelineLength += options.RetryPolicy == null ? 0 : 1;
        pipelineLength += options.LoggingPolicy == null ? 0 : 1;

        pipelineLength++; // for transport

        IPipelinePolicy<PipelineMessage>[] pipeline
            = new IPipelinePolicy<PipelineMessage>[pipelineLength];

        int index = 0;

        clientPerCallPolicies.CopyTo(pipeline.AsSpan(index));
        index += clientPerCallPolicies.Length;

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

        clientPerTryPolicies.CopyTo(pipeline.AsSpan(index));
        index += clientPerTryPolicies.Length;

        if (options.LoggingPolicy != null)
        {
            pipeline[index++] = options.LoggingPolicy;
        }
        if (options.Transport != null)
        {
            pipeline[index++] = options.Transport;
        }
        else
        {
            pipeline[index++] = defaultTransport;
        }
        return new MessagePipeline(pipeline);
    }

    public override PipelineMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier)
    {
        return _transport.CreateMessage(options, classifier);
    }

    ///// <summary>
    ///// TBD.
    ///// </summary>
    ///// <param name="verb"></param>
    ///// <param name="uri"></param>
    ///// <returns></returns>
    ///// <exception cref="NotImplementedException"></exception>
    //public override PipelineMessage CreateMessage(string verb, Uri uri)
    //{
    //    var message = _transport.CreateMessage(verb, uri);
    //    return message;
    //}

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    public override void Send(PipelineMessage message)
    {
        var enumerator = new MessagePipelineExecutor(_policies, message);
        enumerator.ProcessNext();

        // Send is complete, we can annotate the response.
        message.PipelineResponse!.IsError = message.ResponseErrorClassifier.IsErrorResponse(message);
    }

    public override async ValueTask SendAsync(PipelineMessage message)
    {
        var enumerator = new MessagePipelineExecutor(_policies, message);
        await enumerator.ProcessNextAsync().ConfigureAwait(false);

        // Send is complete, we can annotate the response.
        message.PipelineResponse!.IsError = message.ResponseErrorClassifier.IsErrorResponse(message);
    }

    internal class MessagePipelineExecutor : PipelineEnumerator
    {
        private PipelineMessage _message;
        private ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _policies;

        public MessagePipelineExecutor(ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> policies, PipelineMessage message)
        {
            _policies = policies;
            _message = message;
        }
        public override bool ProcessNext()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            first.Process(_message, this);
            return _policies.Length > 0;
        }

        public async override ValueTask<bool> ProcessNextAsync()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            await first.ProcessAsync(_message, this).ConfigureAwait(false);
            return _policies.Length > 0;
        }
    }
}
