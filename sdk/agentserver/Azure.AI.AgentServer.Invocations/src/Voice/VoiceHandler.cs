// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Invocations.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Thin typed event relay for Voice Live Bridge Protocol 1.0.</summary>
/// <remarks>
/// Callbacks are awaited in wire order. Applications that need work to outlive a callback
/// create, track, cancel, and observe their own tasks; the relay retains no application work
/// or cross-message protocol state.
/// </remarks>
[Experimental("AAAS001")]
public abstract class VoiceHandler : InvocationWebSocketHandler
{
    private static readonly UTF8Encoding StrictUtf8 = new(false, true);

    internal virtual VoiceHandler ApplicationHandler => this;

    /// <inheritdoc />
    public sealed override async Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        _ = await HandleWebSocketWithOutcomeAsync(
            webSocket,
            context,
            cancellationToken).ConfigureAwait(false);
    }

    internal sealed override IInvocationsWebSocketEndpointLifecycle CreateEndpointLifecycle(
        Microsoft.AspNetCore.Http.HttpContext httpContext,
        InvocationCorrelationBaggage correlationBaggage)
    {
        VoiceTracingRegistration.MarkEndpointEntered(httpContext);
        return VoiceWebSocketLifecycle.Start(
            this,
            httpContext.Request.Headers,
            correlationBaggage);
    }

    internal sealed override Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        VoiceWebSocketLifecycle.HandleAsync(
            this,
            webSocket,
            context,
            traceContext: default,
            cancellationToken);

    /// <summary>Handles an explicit application start event.</summary>
    protected virtual Task OnSessionStartAsync(
        VoiceSession session,
        VoiceSessionStartEvent start,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles a completed user text turn.</summary>
    protected virtual Task OnUserMessageAsync(
        VoiceSession session,
        VoiceUserMessageEvent message,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles a Bridge-generated no-input turn.</summary>
    protected virtual Task OnUserNoInputAsync(
        VoiceSession session,
        VoiceUserNoInputEvent noInput,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles the advisory caller-speech-start signal.</summary>
    protected virtual Task OnUserSpeechStartedAsync(
        VoiceSession session,
        VoiceUserSpeechStartedEvent speechStarted,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles caller interruption of a response.</summary>
    protected virtual Task OnBargeInAsync(
        VoiceSession session,
        VoiceBargeInEvent bargeIn,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles proactive response acceptance.</summary>
    protected virtual Task OnResponseAcceptedAsync(
        VoiceSession session,
        VoiceResponseAcceptedEvent accepted,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles proactive response rejection or expiry.</summary>
    protected virtual Task OnResponseDroppedAsync(
        VoiceSession session,
        VoiceResponseDroppedEvent dropped,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles the winning response self-cancel outcome.</summary>
    protected virtual Task OnResponseCancelledAsync(
        VoiceSession session,
        VoiceResponseCancelledEvent cancelled,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles a response or pending-input timeout.</summary>
    protected virtual Task OnResponseTimeoutAsync(
        VoiceSession session,
        VoiceResponseTimeoutEvent timeout,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Handles Bridge-initiated session termination.</summary>
    protected virtual Task OnSessionEndAsync(
        VoiceSession session,
        VoiceSessionEndEvent end,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>
    /// Notifies the application once, after the session becomes unwritable and before transport close.
    /// Cancel application-owned work here; do not block or send another Voice message.
    /// </summary>
    protected virtual void OnConnectionTerminating(VoiceSession session)
    {
    }

    internal async Task<InvocationsWebSocketCloseResult> HandleWebSocketConnectionAsync(
        InvocationsWebSocketConnection connection,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        await HandleWebSocketConnectionAsync(
            connection,
            context,
            traceContext: default,
            cancellationToken).ConfigureAwait(false);

    internal async Task<InvocationsWebSocketCloseResult> HandleWebSocketConnectionAsync(
        InvocationsWebSocketConnection connection,
        InvocationContext context,
        ActivityContext connectionContext,
        CancellationToken cancellationToken) =>
        await HandleWebSocketConnectionAsync(
            connection,
            context,
            new VoiceTraceContext(connectionContext, default),
            cancellationToken).ConfigureAwait(false);

    internal async Task<InvocationsWebSocketCloseResult> HandleWebSocketConnectionAsync(
        InvocationsWebSocketConnection connection,
        InvocationContext context,
        VoiceTraceContext traceContext,
        CancellationToken cancellationToken)
    {
        var session = new VoiceSession(connection, context, traceContext);
        InvocationsWebSocketCloseResult outcome;
        try
        {
            while (true)
            {
                var received = await ReceiveMessageAsync(connection, cancellationToken).ConfigureAwait(false);
                if (received.IsClose)
                {
                    var peerStatus = connection.PeerCloseStatus;
                    outcome = new InvocationsWebSocketCloseResult(
                        peerStatus,
                        connection.PeerCloseStatusDescription ?? string.Empty,
                        ErrorCode: null,
                        Exception: null);
                    break;
                }

                var message = VoiceProtocolCodec.Decode(received.Payload);
                if (message is not null)
                {
                    try
                    {
                        await DispatchAsync(
                            session,
                            message,
                            traceContext,
                            cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException exception)
                        when (exception.CancellationToken == cancellationToken &&
                              cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception exception) when (connection.IsSendFailure(exception))
                    {
                        outcome = new InvocationsWebSocketCloseResult(
                            Status: null,
                            Reason: string.Empty,
                            ErrorCode: null,
                            exception);
                        break;
                    }
                    catch (Exception exception)
                    {
                        outcome = new InvocationsWebSocketCloseResult(
                            WebSocketCloseStatus.InternalServerError,
                            "Internal server error",
                            InvocationsWebSocketConstants.ErrorCodeInternalError,
                            exception);
                        break;
                    }
                }
            }
        }
        catch (VoiceProtocolException exception)
        {
            outcome = ProtocolOutcome(exception);
        }
        catch (OperationCanceledException exception)
            when (exception.CancellationToken == cancellationToken &&
                  cancellationToken.IsCancellationRequested)
        {
            outcome = new InvocationsWebSocketCloseResult(
                Status: null,
                Reason: string.Empty,
                ErrorCode: null,
                Exception: null);
        }
        catch (Exception exception) when (exception is WebSocketException or IOException or ObjectDisposedException)
        {
            outcome = new InvocationsWebSocketCloseResult(
                Status: null,
                Reason: string.Empty,
                ErrorCode: null,
                exception);
        }
        catch (Exception exception)
        {
            outcome = new InvocationsWebSocketCloseResult(
                WebSocketCloseStatus.InternalServerError,
                "Internal server error",
                InvocationsWebSocketConstants.ErrorCodeInternalError,
                exception);
        }

        connection.StopSending();
        Exception? cleanupException = null;
        try
        {
            ApplicationHandler.OnConnectionTerminating(session);
        }
        catch (Exception exception)
        {
            cleanupException = exception;
        }

        return outcome with { CleanupException = cleanupException };
    }

    private async Task DispatchAsync(
        VoiceSession session,
        VoiceInboundMessage message,
        VoiceTraceContext traceContext,
        CancellationToken cancellationToken)
    {
        using var callbackTrace = VoiceCallbackTrace.Start(
            traceContext,
            message.MessageType);
        using var callbackScope = callbackTrace.Activate();
        try
        {
            await DispatchCallbackAsync(session, message, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException exception)
            when (exception.CancellationToken == cancellationToken &&
                  cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            callbackTrace.RecordFailure(exception);
            throw;
        }
    }

    private Task DispatchCallbackAsync(
        VoiceSession session,
        VoiceInboundMessage message,
        CancellationToken cancellationToken) => message switch
        {
            VoiceSessionStartEvent start => ApplicationHandler.OnSessionStartAsync(session, start, cancellationToken),
            VoiceUserMessageEvent userMessage => ApplicationHandler.OnUserMessageAsync(session, userMessage, cancellationToken),
            VoiceUserNoInputEvent noInput => ApplicationHandler.OnUserNoInputAsync(session, noInput, cancellationToken),
            VoiceUserSpeechStartedEvent speechStarted =>
                ApplicationHandler.OnUserSpeechStartedAsync(session, speechStarted, cancellationToken),
            VoiceBargeInEvent bargeIn => ApplicationHandler.OnBargeInAsync(session, bargeIn, cancellationToken),
            VoiceResponseAcceptedEvent accepted => ApplicationHandler.OnResponseAcceptedAsync(session, accepted, cancellationToken),
            VoiceResponseDroppedEvent dropped => ApplicationHandler.OnResponseDroppedAsync(session, dropped, cancellationToken),
            VoiceResponseCancelledEvent cancelled => ApplicationHandler.OnResponseCancelledAsync(session, cancelled, cancellationToken),
            VoiceResponseTimeoutEvent timeout => ApplicationHandler.OnResponseTimeoutAsync(session, timeout, cancellationToken),
            VoiceSessionEndEvent end => ApplicationHandler.OnSessionEndAsync(session, end, cancellationToken),
            _ => Task.CompletedTask,
        };

    private static async Task<ReceivedVoiceMessage> ReceiveMessageAsync(
        InvocationsWebSocketConnection connection,
        CancellationToken cancellationToken)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(4096);
        var length = 0;
        try
        {
            while (true)
            {
                if (length == buffer.Length)
                {
                    if (buffer.Length >= VoiceProtocolCodec.MaxFrameBytes)
                    {
                        var overflowBuffer = new byte[1];
                        while (true)
                        {
                            var continuation = await connection.ReceiveAsync(
                                overflowBuffer,
                                cancellationToken).ConfigureAwait(false);
                            if (continuation.MessageType == WebSocketMessageType.Close)
                            {
                                return new ReceivedVoiceMessage(
                                    IsClose: true,
                                    ReadOnlyMemory<byte>.Empty);
                            }
                            if (continuation.MessageType != WebSocketMessageType.Text ||
                                continuation.Count != 0)
                            {
                                throw new VoiceProtocolException("Voice frame exceeds the maximum size.", 1009);
                            }
                            if (continuation.EndOfMessage)
                            {
                                break;
                            }
                        }

                        ValidateUtf8(buffer, length);
                        return new ReceivedVoiceMessage(
                            IsClose: false,
                            buffer.AsMemory(0, length).ToArray());
                    }

                    var expanded = ArrayPool<byte>.Shared.Rent(
                        Math.Min(buffer.Length * 2, VoiceProtocolCodec.MaxFrameBytes));
                    buffer.AsSpan(0, length).CopyTo(expanded);
                    ArrayPool<byte>.Shared.Return(buffer);
                    buffer = expanded;
                }

                var received = await connection.ReceiveAsync(
                    buffer.AsMemory(length, buffer.Length - length),
                    cancellationToken).ConfigureAwait(false);
                if (received.MessageType == WebSocketMessageType.Close)
                {
                    return new ReceivedVoiceMessage(IsClose: true, ReadOnlyMemory<byte>.Empty);
                }
                if (received.MessageType != WebSocketMessageType.Text)
                {
                    throw new VoiceProtocolException("Voice accepts text frames only.", 1003);
                }

                length = checked(length + received.Count);
                if (length > VoiceProtocolCodec.MaxFrameBytes)
                {
                    throw new VoiceProtocolException("Voice frame exceeds the maximum size.", 1009);
                }
                if (!received.EndOfMessage)
                {
                    continue;
                }

                ValidateUtf8(buffer, length);
                return new ReceivedVoiceMessage(IsClose: false, buffer.AsMemory(0, length).ToArray());
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private static void ValidateUtf8(byte[] buffer, int length)
    {
        try
        {
            _ = StrictUtf8.GetCharCount(buffer, 0, length);
        }
        catch (DecoderFallbackException exception)
        {
            throw new VoiceProtocolException(
                "Voice frame is not valid UTF-8.",
                1007,
                exception);
        }
    }

    private static InvocationsWebSocketCloseResult ProtocolOutcome(VoiceProtocolException exception) =>
        new(
            (WebSocketCloseStatus)exception.CloseCode,
            exception.CloseCode switch
            {
                1003 => "Unsupported Voice message",
                1007 => "Invalid Voice text data",
                1009 => "Voice message too large",
                _ => "Voice protocol error",
            },
            ErrorCode: "protocol_error",
            exception);

    private readonly record struct ReceivedVoiceMessage(bool IsClose, ReadOnlyMemory<byte> Payload);
}
