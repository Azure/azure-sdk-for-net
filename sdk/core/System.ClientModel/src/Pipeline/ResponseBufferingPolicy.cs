// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Pipeline policy to buffer response content or add a timeout to response content
/// managed by the client.
/// </summary>
public class ResponseBufferingPolicy : PipelinePolicy
{
    internal static readonly ResponseBufferingPolicy Default = new();

    public ResponseBufferingPolicy()
    {
    }

    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        Debug.Assert(message.NetworkTimeout is not null);

        TimeSpan invocationNetworkTimeout = (TimeSpan)message.NetworkTimeout!;

        CancellationToken oldToken = message.CancellationToken;
        using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);
        cts.CancelAfter(invocationNetworkTimeout);

        try
        {
            message.CancellationToken = cts.Token;
            if (async)
            {
                await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline, currentIndex);
            }
        }
        catch (OperationCanceledException ex)
        {
            ThrowIfCancellationRequestedOrTimeout(oldToken, cts.Token, ex, invocationNetworkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = oldToken;
            cts.CancelAfter(Timeout.Infinite);
        }

        message.AssertResponse();
        message.Response!.NetworkTimeout = invocationNetworkTimeout;

        Stream? responseContentStream = message.Response!.ContentStream;
        if (responseContentStream is null ||
            message.Response.TryGetBufferedContent(out var _))
        {
            // There is either no content on the response, or the content has already
            // been buffered.
            return;
        }

        if (!message.BufferResponse)
        {
            // Client has requested not to buffer the message response content.
            // If applicable, wrap it in a read-timeout stream.
            if (invocationNetworkTimeout != Timeout.InfiniteTimeSpan)
            {
                message.Response.ContentStream = new ReadTimeoutStream(responseContentStream, invocationNetworkTimeout);
            }

            return;
        }

        // If we got this far, buffer the response.

        // If cancellation is possible (whether due to network timeout or a user cancellation token being passed), then
        // register callback to dispose the stream on cancellation.
        if (invocationNetworkTimeout != Timeout.InfiniteTimeSpan || oldToken.CanBeCanceled)
        {
            cts.Token.Register(state => ((Stream?)state)?.Dispose(), responseContentStream);
        }

        try
        {
            if (async)
            {
                await message.Response.BufferContentAsync(invocationNetworkTimeout, cts).ConfigureAwait(false);
            }
            else
            {
                message.Response.BufferContent(invocationNetworkTimeout, cts);
            }
        }
        // We dispose stream on timeout or user cancellation so catch and check if cancellation token was cancelled
        catch (Exception ex)
            when (ex is ObjectDisposedException
                      or IOException
                      or OperationCanceledException
                      or NotSupportedException)
        {
            ThrowIfCancellationRequestedOrTimeout(oldToken, cts.Token, ex, invocationNetworkTimeout);
            throw;
        }
    }

    /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="originalToken"/> or <paramref name="timeoutToken"/>.</summary>
    /// <param name="originalToken">The customer provided token.</param>
    /// <param name="timeoutToken">The linked token that is cancelled on timeout provided token.</param>
    /// <param name="inner">The inner exception to use.</param>
    /// <param name="timeout">The timeout used for the operation.</param>
#pragma warning disable CA1068 // Cancellation token has to be the last parameter
    internal static void ThrowIfCancellationRequestedOrTimeout(CancellationToken originalToken, CancellationToken timeoutToken, Exception? inner, TimeSpan timeout)
#pragma warning restore CA1068
    {
        CancellationHelper.ThrowIfCancellationRequested(originalToken);

        if (timeoutToken.IsCancellationRequested)
        {
            throw CancellationHelper.CreateOperationCanceledException(
                inner,
                timeoutToken,
                $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. ");
        }
    }
}