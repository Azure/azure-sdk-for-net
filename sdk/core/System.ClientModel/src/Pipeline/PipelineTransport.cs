// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineTransport : PipelinePolicy
{
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

        if (message.Response is not null)
        {
            throw new InvalidOperationException("Response should not be set before transport is invoked.");
        }

        return message;
    }

    protected abstract PipelineMessage CreateMessageCore();

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public void Process(PipelineMessage message)
        => ProcessSyncOrAsync(message, async: false).EnsureCompleted();

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public async ValueTask ProcessAsync(PipelineMessage message)
        => await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
    {
        Debug.Assert(message.NetworkTimeout is not null);

        if (async)
        {
            await ProcessCoreAsync(message).ConfigureAwait(false);
        }
        else
        {
            ProcessCore(message);
        }

        if (message.Response is null)
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        message.Response.SetIsError(ClassifyResponse(message));
    }

    protected abstract void ProcessCore(PipelineMessage message);

    protected abstract ValueTask ProcessCoreAsync(PipelineMessage message);

    private static bool ClassifyResponse(PipelineMessage message)
    {
        if (!message.MessageClassifier.TryClassify(message, out bool isError))
        {
            bool classified = PipelineMessageClassifier.Default.TryClassify(message, out isError);

            Debug.Assert(classified);
        }

        return isError;
    }

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Process(message);

        Debug.Assert(++currentIndex == pipeline.Count);
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(message).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count);
    }
}
