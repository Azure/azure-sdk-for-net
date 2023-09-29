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

    private MessagePipeline(ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> policies)
    {
        _transport = (PipelineTransport<PipelineMessage>)policies.Span[policies.Length-1];
        _policies = policies;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="options">User settings and policies</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MessagePipeline Create(
        PipelineOptions options)
    {
        int pipelineLength = 0;
        pipelineLength += options.PerTryPolicies.Length;
        pipelineLength += options.PerCallPolicies.Length;
        pipelineLength += options.RetryPolicy==null?0:1;
        pipelineLength += options.LoggingPolicy == null ? 0 : 1;
        pipelineLength++; // for transport
        var pipeline = new IPipelinePolicy<PipelineMessage>[pipelineLength];

        int index = 0;

        options.PerCallPolicies.Span.CopyTo(pipeline.AsSpan());
        index += options.PerCallPolicies.Length;

        if (options.RetryPolicy != null) pipeline[index++] = options.RetryPolicy;

        options.PerTryPolicies.Span.CopyTo(pipeline.AsSpan(index));
        index += options.PerTryPolicies.Length;

        if (options.LoggingPolicy != null) pipeline[index++] = options.LoggingPolicy;

        pipeline[index++] = options.Transport;
        return new MessagePipeline(pipeline);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="verb"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override PipelineMessage CreateMessage(string verb, Uri uri)
    {
        var message = _transport.CreateMessage(verb, uri);
        return message;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    public override void Send(PipelineMessage message)
    {
        var enumerator = new MessagePipelineExecutor(_policies, message);
        enumerator.ProcessNext();
    }

    internal class MessagePipelineExecutor : PipelineEnumerator
    {
        private PipelineMessage _message;
        private ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _policies;

        public MessagePipelineExecutor(ReadOnlyMemory<IPipelinePolicy<PipelineMessage>>  policies, PipelineMessage message)
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
