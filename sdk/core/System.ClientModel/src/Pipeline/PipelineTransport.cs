// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineTransport : PipelinePolicy
{
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
        Debug.Assert(message.NetworkTimeout is not null, "NetworkTimeout is not set on PipelineMessage.");
        TimeSpan networkTimeout = (TimeSpan)message.NetworkTimeout!;

        CancellationToken userToken = message.CancellationToken;
        using CancellationTokenSource joinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(userToken);
        joinedTokenSource.CancelAfter(networkTimeout);

        try
        {
            message.CancellationToken = joinedTokenSource.Token;

            if (async)
            {
                await ProcessCoreAsync(message).ConfigureAwait(false);
            }
            else
            {
                ProcessCore(message);
            }
        }
        catch (OperationCanceledException ex)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(userToken, joinedTokenSource.Token, ex, networkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = userToken;
            joinedTokenSource.CancelAfter(Timeout.Infinite);
        }

        if (message.Response is null)
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        message.Response.SetIsError(ClassifyResponse(message));
        message.Response!.NetworkTimeout = networkTimeout;

        if (message.Response!.ContentStream is null)
        {
            // No need to buffer if there is no content stream.
            return;
        }

        if (!message.BufferResponse)
        {
            // Don't buffer the response content, e.g. in order to return the
            // network stream to the end user of a client as part of a streaming
            // API.  In this case, we wrap the content stream in a read-timeout
            // stream, to respect the client's network timeout setting.
            WrapNetworkStream(message, networkTimeout);
            return;
        }

        // If we got this far, buffer the response.

        // If cancellation is possible (whether due to network timeout or a user cancellation token being passed), then
        // register callback to dispose the stream on cancellation.
        if (networkTimeout != Timeout.InfiniteTimeSpan || userToken.CanBeCanceled)
        {
            joinedTokenSource.Token.Register(state => ((Stream?)state)?.Dispose(), message.Response!.ContentStream);
        }

        try
        {
            if (async)
            {
                await message.Response.BufferContentAsync(networkTimeout, joinedTokenSource).ConfigureAwait(false);
            }
            else
            {
                message.Response.BufferContent(networkTimeout, joinedTokenSource);
            }
        }
        // We dispose stream on timeout or user cancellation so catch and check if cancellation token was cancelled
        catch (Exception ex)
            when (ex is ObjectDisposedException
                      or IOException
                      or OperationCanceledException
                      or NotSupportedException)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(userToken, joinedTokenSource.Token, ex, networkTimeout);
            throw;
        }
    }

    private static bool ClassifyResponse(PipelineMessage message)
    {
        if (!message.ResponseClassifier.TryClassify(message, out bool isError))
        {
            bool classified = PipelineMessageClassifier.Default.TryClassify(message, out isError);

            Debug.Assert(classified, "Error classifier did not classify message.");
        }

        return isError;
    }

    private static void WrapNetworkStream(PipelineMessage message, TimeSpan networkTimeout)
    {
        if (networkTimeout != Timeout.InfiniteTimeSpan)
        {
            Stream contentStream = message.Response!.ContentStream!;
            message.Response!.ContentStream = new ReadTimeoutStream(contentStream, networkTimeout);
        }
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

        if (message.Response is not null)
        {
            throw new InvalidOperationException("Response should not be set before transport is invoked.");
        }

        return message;
    }

    protected abstract PipelineMessage CreateMessageCore();

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Process(message);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(message).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }
}
