// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
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
    internal static readonly ResponseBufferingPolicy Shared = new();

    public ResponseBufferingPolicy()
    {
    }

    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        CancellationToken oldToken = message.CancellationToken;
        using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);

        TimeSpan invocationNetworkTimeout = (TimeSpan)message.NetworkTimeout!;
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

        if (!message.BufferResponse)
        {
            return;
        }

        message.AssertResponse();

        // Set the network timeout on the response.
        message.Response!.NetworkTimeout = invocationNetworkTimeout;

        Stream? responseContentStream = message.Response!.ContentStream;
        if (responseContentStream is null ||
            message.Response.TryGetBufferedContent(out var _))
        {
            // There is either no content on the response, or the content has already
            // been buffered.
            return;
        }

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

    #region Buffer Response Override

    public static void SetBufferingEnabled(PipelineMessage message, bool bufferingEnabled)
        => message.BufferResponse = bufferingEnabled;

    public static bool GetBufferingEnabled(PipelineMessage message)
        => message.BufferResponse;

    #endregion

    #region Network Timeout Override

    public static void SetNetworkTimeout(PipelineMessage message, TimeSpan? networkTimeout)
        => message.NetworkTimeout = networkTimeout;

    public static TimeSpan? GetNetworkTimeout(PipelineMessage message)
        => message.NetworkTimeout;

    #endregion
}