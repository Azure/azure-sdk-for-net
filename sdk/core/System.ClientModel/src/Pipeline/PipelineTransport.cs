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
    #region CreateMessage
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
    #endregion

    #region Process message

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

        // Implement network timeout around call to concrete transport
        // implementation of ProcessCore.
        TimeSpan networkTimeout = (TimeSpan)message.NetworkTimeout!;

        CancellationToken userToken = message.CancellationToken;
        using CancellationTokenSource joinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(userToken);
        joinedTokenSource.CancelAfter(networkTimeout);
        message.CancellationToken = joinedTokenSource.Token;

        try
        {
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
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(userToken,
                joinedTokenSource.Token, ex, networkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = userToken;
            joinedTokenSource.CancelAfter(Timeout.Infinite);
        }

        // Validate the transport implementation set a response.
        if (message.Response is null)
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        // Set meta-data required by the pipeline on the message
        message.Response.SetIsError(ClassifyResponse(message));
        message.Response.NetworkTimeout = networkTimeout;

        // Buffer the response if applicable.
        if (async)
        {
            await BufferResponseAsync(message, networkTimeout, userToken, joinedTokenSource).ConfigureAwait(false);
        }
        else
        {
            BufferResponse(message, networkTimeout, userToken, joinedTokenSource);
        }
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

    private void BufferResponse(PipelineMessage message, TimeSpan networkTimeout, CancellationToken userToken, CancellationTokenSource joinedTokenSource)
        => BufferResponseSyncOrAsync(message, networkTimeout, userToken, joinedTokenSource, async: false).EnsureCompleted();

    private async Task BufferResponseAsync(PipelineMessage message, TimeSpan networkTimeout, CancellationToken userToken, CancellationTokenSource joinedTokenSource)
     => await BufferResponseSyncOrAsync(message, networkTimeout, userToken, joinedTokenSource, async: true).ConfigureAwait(false);

    private async Task BufferResponseSyncOrAsync(PipelineMessage message, TimeSpan networkTimeout, CancellationToken userToken, CancellationTokenSource joinedTokenSource, bool async)
    {
        if (message.Response!.ContentStream is not null)
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

        // If cancellation is possible, either due to network timeout or a user
        // cancellation token being cancelled, register a callback to dispose
        // the stream on cancellation.
        if (networkTimeout != Timeout.InfiniteTimeSpan || userToken.CanBeCanceled)
        {
            joinedTokenSource.Token.Register(state => ((Stream?)state)?.Dispose(),
                message.Response!.ContentStream!);
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
        // We dispose stream on timeout or user cancellation so catch and check
        // if cancellation token was cancelled.
        catch (Exception ex) when (ex is ObjectDisposedException
                                      or IOException
                                      or OperationCanceledException
                                      or NotSupportedException)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(userToken, joinedTokenSource.Token, ex, networkTimeout);
            throw;
        }
    }

    private static void WrapNetworkStream(PipelineMessage message, TimeSpan networkTimeout)
    {
        if (networkTimeout != Timeout.InfiniteTimeSpan)
        {
            Stream contentStream = message.Response!.ContentStream!;
            message.Response!.ContentStream = new ReadTimeoutStream(contentStream, networkTimeout);
        }
    }

    #endregion

    #region PipelinePolicy.Process overrides
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
    #endregion
}
