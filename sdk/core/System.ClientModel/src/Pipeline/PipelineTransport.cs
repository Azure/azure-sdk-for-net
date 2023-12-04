// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineTransport : PipelinePolicy
{
    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public void Process(PipelineMessage message)
    {
        ProcessCore(message);

        if (!message.TryGetResponse(out PipelineResponse response))
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        response.IsError = message.MessageClassifier?.IsErrorResponse(message) ?? default;
    }

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public async ValueTask ProcessAsync(PipelineMessage message)
    {
        await ProcessCoreAsync(message).ConfigureAwait(false);

        if (!message.TryGetResponse(out PipelineResponse response))
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        response.IsError = message.MessageClassifier?.IsErrorResponse(message) ?? default;
    }

    protected abstract void ProcessCore(PipelineMessage message);

    protected abstract ValueTask ProcessCoreAsync(PipelineMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    public PipelineMessage CreateMessage()
    {
        PipelineMessage message = CreateMessageCore();

        if (message.Request is null)
        {
            throw new InvalidOperationException("Request was not set on message.");
        }

        if (message.TryGetResponse(out PipelineResponse _))
        {
            throw new InvalidOperationException("Response should not be set before transport is invoked.");
        }

        return message;
    }

    protected abstract PipelineMessage CreateMessageCore();

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.
    public sealed override void Process(PipelineMessage message, PipelineProcessor pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        Process(message);
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await ProcessAsync(message).ConfigureAwait(false);
    }
}
