// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class MessagePipeline : Pipeline<PipelineMessage>
{
    private readonly ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> _pipeline;
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
        _pipeline = larger;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MessagePipeline Create(RequestOptions options)
    {
        return new MessagePipeline(
            new MessagePipelineTransport(),
            Array.Empty<IPipelinePolicy<PipelineMessage>>());
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
        ProcessNext(message, _pipeline);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    public static void ProcessNext<TMessage>(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        pipeline.Span[0].Process(message, pipeline.Slice(1));
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    public static async ValueTask ProcessNextAsync<TMessage>(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        await pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
    }
}
