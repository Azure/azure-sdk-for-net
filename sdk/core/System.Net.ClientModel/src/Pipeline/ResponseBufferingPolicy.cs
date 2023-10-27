﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.ClientModel.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

/// <summary>
/// Pipeline policy to buffer response content or add a timeout to response content managed by the client
/// </summary>
public class ResponseBufferingPolicy : PipelinePolicy<PipelineMessage>
{
    // Same value as Stream.CopyTo uses by default
    private const int DefaultCopyBufferSize = 81920;

    private readonly TimeSpan _networkTimeout;

    public ResponseBufferingPolicy(TimeSpan networkTimeout)
    {
        // Note: we set this in the constructor because we need a value for it and
        // don't want to expect/require a caller to know/remember to set it on the message.
        // The one on the message then becomes and invocation-time override of what was
        // baked in at pipeline-construction time.

        // TODO: It feels like this should live on the transport and not a random policy.
        // Revisit this and see if we can do it and what it would look like.
        _networkTimeout = networkTimeout;
    }

    public override void Process(PipelineMessage message, IPipelineEnumerator pipeline)

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, pipeline, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public override async ValueTask ProcessAsync(PipelineMessage message, IPipelineEnumerator pipeline)
        => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IPipelineEnumerator pipeline, bool async)
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
                await pipeline.ProcessNextAsync().ConfigureAwait(false);
            }
            else
            {
                pipeline.ProcessNext();
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

        MessageBody? responseContent = message.Response.Content;
        if (responseContent is null || responseContent.IsBuffered)
        {
            return;
        }

        // If cancellation is possible (whether due to network timeout or a user cancellation
        // token being passed), then register callback to dispose the content stream on cancellation.
        if (invocationNetworkTimeout != Timeout.InfiniteTimeSpan || oldToken.CanBeCanceled)
        {
            Action<object?> callback = content => ((MessageBody?)content)?.Dispose();
            cts.Token.Register(callback, responseContent);
        }

        try
        {
            Stream bufferedStream = new MemoryStream();

            // Set network timeout before starting to buffer
            cts.CancelAfter(invocationNetworkTimeout);

            if (async)
            {
                await responseContent.WriteToAsync(bufferedStream, cts.Token).ConfigureAwait(false);
            }
            else
            {
                responseContent.WriteTo(bufferedStream, cts.Token);
            }

            // Reset timeout after buffering is complete.
            cts.CancelAfter(Timeout.InfiniteTimeSpan);

            responseContent.Dispose();
            bufferedStream.Position = 0;
            MessageBody bufferedContent = MessageBody.CreateContent(bufferedStream);
            message.Response.Content = bufferedContent;
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
        ClientUtilities.ThrowIfCancellationRequested(originalToken);

        if (timeoutToken.IsCancellationRequested)
        {
            // TODO: Make this error message correct
            throw ClientUtilities.CreateOperationCanceledException(
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
