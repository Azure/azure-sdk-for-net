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
        message.NetworkTimeout ??= ClientPipeline.DefaultNetworkTimeout;

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
        Debug.Assert(message.NetworkTimeout is not null, "NetworkTimeout is not set on PipelineMessage.");

        // Implement network timeout behavior around call to ProcessCore.
        TimeSpan networkTimeout = (TimeSpan)message.NetworkTimeout!;
        CancellationToken messageToken = message.CancellationToken;
        using CancellationTokenSource timeoutTokenSource = CancellationTokenSource.CreateLinkedTokenSource(messageToken);
        timeoutTokenSource.CancelAfter(networkTimeout);

        try
        {
            message.CancellationToken = timeoutTokenSource.Token;

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
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(messageToken, timeoutTokenSource.Token, ex, networkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = messageToken;
            timeoutTokenSource.CancelAfter(Timeout.Infinite);
        }

        message.AssertResponse();
        message.Response!.IsErrorCore = ClassifyResponse(message);

        // The remainder of the method handles response content according to
        // buffering logic specified by value of message.BufferResponse.

        Stream? contentStream = message.Response!.ContentStream;
        if (contentStream is null)
        {
            // There is no response content.
            return;
        }

        if (!message.BufferResponse)
        {
            // Client has requested not to buffer the message response content.
            // If applicable, wrap it in a read-timeout stream.
            if (networkTimeout != Timeout.InfiniteTimeSpan)
            {
                message.Response.ContentStream = new ReadTimeoutStream(contentStream, networkTimeout);
            }

            return;
        }

        try
        {
            // If cancellation is possible (whether due to network timeout or a user
            // cancellation token being passed), then register callback to dispose the
            // stream on cancellation.
            if (networkTimeout != Timeout.InfiniteTimeSpan || messageToken.CanBeCanceled)
            {
                timeoutTokenSource.Token.Register(state => ((Stream?)state)?.Dispose(), contentStream);
                timeoutTokenSource.CancelAfter(networkTimeout);
            }

            if (async)
            {
                await message.Response.BufferContentAsync(timeoutTokenSource.Token).ConfigureAwait(false);
            }
            else
            {
                message.Response.BufferContent(timeoutTokenSource.Token);
            }
        }
        // We dispose stream on timeout or user cancellation so catch and check if
        // cancellation token was cancelled
        catch (Exception ex) when (ex is ObjectDisposedException
                                      or IOException
                                      or OperationCanceledException
                                      or NotSupportedException)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(messageToken, timeoutTokenSource.Token, ex, networkTimeout);
            throw;
        }
    }

    protected abstract void ProcessCore(PipelineMessage message);

    protected abstract ValueTask ProcessCoreAsync(PipelineMessage message);

    private static bool ClassifyResponse(PipelineMessage message)
    {
        if (!message.ResponseClassifier.TryClassify(message, out bool isError))
        {
            bool classified = PipelineMessageClassifier.Default.TryClassify(message, out isError);

            Debug.Assert(classified, "Error classifier did not classify message.");
        }

        return isError;
    }

    #endregion

    #region PipelinePolicy.Process overrides

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

    #endregion
}
