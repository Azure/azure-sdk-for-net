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
    private readonly TimeSpan _networkTimeout;

    // TODO: Solve where client-option network timeout lives.
    public PipelineTransport(TimeSpan? networkTimeout = default)
    {
        _networkTimeout = networkTimeout ?? PipelineResponse.DefaultNetworkTimeout;
    }

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public void Process(PipelineMessage message)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public async ValueTask ProcessAsync(PipelineMessage message)
    => await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
    {
        CancellationToken oldToken = message.CancellationToken;
        using CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(oldToken);

        // Get the network timeout for this particular invocation of the pipeline.
        // We either use the default that the policy was constructed with at
        // pipeline-creation time, or we get an override value from the message that
        // we use for the duration of this invocation only.
        TimeSpan invocationNetworkTimeout = _networkTimeout;
        if (TryGetNetworkTimeout(message, out TimeSpan networkTimeoutOverride))
        {
            invocationNetworkTimeout = networkTimeoutOverride;
        }

        cts.CancelAfter(invocationNetworkTimeout);
        try
        {
            message.CancellationToken = cts.Token;
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
            ThrowIfCancellationRequestedOrTimeout(oldToken, cts.Token, ex, invocationNetworkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = oldToken;
            cts.CancelAfter(Timeout.Infinite);
        }

        // Default to true if property is not present
        if (TryGetBufferResponse(message, out bool bufferResponse) && !bufferResponse)
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

        if (message.Response is null)
        {
            throw new InvalidOperationException("Response was not set by transport.");
        }

        message.Response.SetIsError(ClassifyResponse(message));
    }

    private static bool ClassifyResponse(PipelineMessage message) =>
        message.MessageClassifier?.IsErrorResponse(message) ??
        PipelineMessageClassifier.Default.IsErrorResponse(message);

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

        Debug.Assert(++currentIndex == pipeline.Count);
    }

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(message).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count);
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
            // TODO: Make this error message correct
            throw CancellationHelper.CreateOperationCanceledException(
                inner,
                timeoutToken,
                $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. ");
        }
    }

    #region Buffer Response Override

    public static void SetBufferResponse(PipelineMessage message, bool bufferResponse)
        => message.SetProperty(typeof(BufferResponsePropertyKey), bufferResponse);

    public static bool TryGetBufferResponse(PipelineMessage message, out bool bufferResponse)
    {
        if (message.TryGetProperty(typeof(BufferResponsePropertyKey), out object? value) &&
            value is bool doBuffer)
        {
            bufferResponse = doBuffer;
            return true;
        }

        bufferResponse = default;
        return false;
    }

    private struct BufferResponsePropertyKey { }

    #endregion

    #region Network Timeout Override

    public static void SetNetworkTimeout(PipelineMessage message, TimeSpan networkTimeout)
        => message.SetProperty(typeof(NetworkTimeoutPropertyKey), networkTimeout);

    public static bool TryGetNetworkTimeout(PipelineMessage message, out TimeSpan networkTimeout)
    {
        if (message.TryGetProperty(typeof(NetworkTimeoutPropertyKey), out object? value) &&
            value is TimeSpan timeout)
        {
            networkTimeout = timeout;
            return true;
        }

        networkTimeout = default;
        return false;
    }

    private struct NetworkTimeoutPropertyKey { }

    #endregion
}
