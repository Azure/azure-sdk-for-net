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

    private MessagePipeline(ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> policies)
    {
        _transport = (PipelineTransport<PipelineMessage>)policies.Span[policies.Length-1];
        _pipeline = policies;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MessagePipeline Create(RequestOptions options)
    {
        int pipelineLength = 0;

        if (options.PerTryPolicies != null) pipelineLength += options.PerTryPolicies.Length;
        if (options.PerCallPolicies != null) pipelineLength += options.PerCallPolicies.Length;
        pipelineLength += options.RetryPolicy==null?0:1;
        pipelineLength += options.LoggingPolicy == null ? 0 : 1;
        pipelineLength++; // for transport
        var pipeline = new IPipelinePolicy<PipelineMessage>[pipelineLength];

        int index = 0;
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
            pipeline[index++] = new MessagePipelineTransport();
        }
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
        ProcessNext(message, _pipeline);
    }
 }
