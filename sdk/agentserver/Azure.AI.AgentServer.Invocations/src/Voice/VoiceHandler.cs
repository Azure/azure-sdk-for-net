// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Voice.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Base class for a typed Voice Live Bridge Protocol 1.0 agent. Derive from this
/// type and override the turn callbacks; the library owns the WebSocket receive
/// loop, activation handshake, wire framing, and ordering.
/// </summary>
/// <remarks>
/// <para>The agent stays text-in and text-out. Voice Live owns audio, speech to
/// text, text to speech, voice activity detection, turn-taking, and barge-in.
/// This handler runs inside the hosted agent container over the existing
/// <c>invocations_ws</c> transport.</para>
/// <para>Register the handler with
/// <see cref="VoiceBuilderExtensions.AddVoice{THandler}"/>
/// or run it with <see cref="VoiceServer.Run{THandler}"/>.</para>
/// </remarks>
public abstract class VoiceHandler : InvocationWebSocketHandler
{
    /// <summary>
    /// Invoked once, after a validated <c>session.start</c> and before readiness,
    /// to perform customer session startup. Reconnect startup must be idempotent.
    /// </summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="startEvent">The immutable session-start event.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnSessionStartAsync(VoiceSession session, SessionStartEvent startEvent, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    /// <summary>
    /// Invoked for each completed user turn.
    /// </summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="message">The completed user turn.</param>
    /// <param name="response">The library-owned response bound to this turn's input prefix.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected abstract Task OnUserMessageAsync(
        VoiceSession session,
        UserMessageEvent message,
        VoiceResponse response,
        CancellationToken cancellationToken);

    /// <summary>Invoked for a bridge-generated caller-silence turn.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="noInput">The no-input turn.</param>
    /// <param name="response">The response bound to the no-input item.</param>
    /// <param name="cancellationToken">Cancelled when this turn reaches a terminal boundary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnUserNoInputAsync(
        VoiceSession session,
        UserNoInputEvent noInput,
        VoiceResponse response,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked for the advisory caller-speech-started signal.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="speechStarted">The advisory event.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnUserSpeechStartedAsync(
        VoiceSession session,
        UserSpeechStartedEvent speechStarted,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked for one raw, session-scoped DTMF key.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="dtmf">The raw key event.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnDtmfKeyAsync(
        VoiceSession session,
        DtmfKeyEvent dtmf,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked for one completed DTMF collection turn.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="dtmf">The collected DTMF turn.</param>
    /// <param name="response">The response bound to the collected input item.</param>
    /// <param name="cancellationToken">Cancelled when this turn reaches a terminal boundary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnDtmfCollectedAsync(
        VoiceSession session,
        DtmfCollectedEvent dtmf,
        VoiceResponse response,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked when the bridge rejects a DTMF collection request.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="rejected">The collection rejection.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnDtmfCollectionRejectedAsync(
        VoiceSession session,
        DtmfCollectionRejectedEvent rejected,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked when a DTMF collection ends without a collected turn.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="cancelled">The collection cancellation.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnDtmfCollectionCancelledAsync(
        VoiceSession session,
        DtmfCollectionCancelledEvent cancelled,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked for a bridge-generated handoff recovery turn.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="failure">The target activation failure.</param>
    /// <param name="response">The response bound to the recovery input item.</param>
    /// <param name="cancellationToken">Cancelled when this turn reaches a terminal boundary.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnHandoffFailedAsync(
        VoiceSession session,
        HandoffFailedEvent failure,
        VoiceResponse response,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked to durably persist one caller-app history item.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="create">The history create request.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task that completes only after durable persistence succeeds.</returns>
    protected virtual Task OnConversationItemCreateAsync(
        VoiceSession session,
        ConversationItemCreateEvent create,
        CancellationToken cancellationToken) =>
        Task.FromException(new InvalidOperationException("No conversation item create callback is implemented."));

    /// <summary>Invoked to durably delete one conversation history item.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="delete">The history delete request.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task that completes only after durable deletion succeeds.</returns>
    protected virtual Task OnConversationItemDeleteAsync(
        VoiceSession session,
        ConversationItemDeleteEvent delete,
        CancellationToken cancellationToken) =>
        Task.FromException(new InvalidOperationException("No conversation item delete callback is implemented."));

    /// <summary>Invoked after a caller interruption terminalizes a response.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="bargeIn">The playback reconciliation event.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnBargeInAsync(
        VoiceSession session,
        BargeInEvent bargeIn,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>Invoked after timed-out work has been terminalized and cancelled.</summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="timeout">The timeout event.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnResponseTimeoutAsync(
        VoiceSession session,
        ResponseTimeoutEvent timeout,
        CancellationToken cancellationToken) => Task.CompletedTask;

    /// <summary>
    /// Invoked during bounded teardown after <c>session.end</c>. Callbacks are
    /// normally serialized; if an earlier callback ignores terminal cancellation,
    /// this terminal callback may overlap it so teardown remains bounded.
    /// </summary>
    /// <param name="session">The read-only session context.</param>
    /// <param name="sessionEnd">The session terminal event.</param>
    /// <param name="cancellationToken">A token to observe for connection cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected virtual Task OnSessionEndAsync(
        VoiceSession session,
        SessionEndEvent sessionEnd,
        CancellationToken cancellationToken) => Task.CompletedTask;

    internal Task InvokeSessionStartAsync(VoiceSession session, SessionStartEvent startEvent, CancellationToken cancellationToken) =>
        OnSessionStartAsync(session, startEvent, cancellationToken);

    internal Task InvokeUserMessageAsync(VoiceSession session, UserMessageEvent message, VoiceResponse response, CancellationToken cancellationToken) =>
        OnUserMessageAsync(session, message, response, cancellationToken);

    internal Task InvokeUserNoInputAsync(VoiceSession session, UserNoInputEvent noInput, VoiceResponse response, CancellationToken cancellationToken) =>
        OnUserNoInputAsync(session, noInput, response, cancellationToken);

    internal Task InvokeUserSpeechStartedAsync(VoiceSession session, UserSpeechStartedEvent speechStarted, CancellationToken cancellationToken) =>
        OnUserSpeechStartedAsync(session, speechStarted, cancellationToken);

    internal Task InvokeDtmfKeyAsync(VoiceSession session, DtmfKeyEvent dtmf, CancellationToken cancellationToken) =>
        OnDtmfKeyAsync(session, dtmf, cancellationToken);

    internal Task InvokeDtmfCollectedAsync(VoiceSession session, DtmfCollectedEvent dtmf, VoiceResponse response, CancellationToken cancellationToken) =>
        OnDtmfCollectedAsync(session, dtmf, response, cancellationToken);

    internal Task InvokeDtmfCollectionRejectedAsync(VoiceSession session, DtmfCollectionRejectedEvent rejected, CancellationToken cancellationToken) =>
        OnDtmfCollectionRejectedAsync(session, rejected, cancellationToken);

    internal Task InvokeDtmfCollectionCancelledAsync(VoiceSession session, DtmfCollectionCancelledEvent cancelled, CancellationToken cancellationToken) =>
        OnDtmfCollectionCancelledAsync(session, cancelled, cancellationToken);

    internal Task InvokeHandoffFailedAsync(VoiceSession session, HandoffFailedEvent failure, VoiceResponse response, CancellationToken cancellationToken) =>
        OnHandoffFailedAsync(session, failure, response, cancellationToken);

    internal Task InvokeConversationItemCreateAsync(VoiceSession session, ConversationItemCreateEvent create, CancellationToken cancellationToken) =>
        OnConversationItemCreateAsync(session, create, cancellationToken);

    internal Task InvokeConversationItemDeleteAsync(VoiceSession session, ConversationItemDeleteEvent delete, CancellationToken cancellationToken) =>
        OnConversationItemDeleteAsync(session, delete, cancellationToken);

    internal Task InvokeBargeInAsync(VoiceSession session, BargeInEvent bargeIn, CancellationToken cancellationToken) =>
        OnBargeInAsync(session, bargeIn, cancellationToken);

    internal Task InvokeResponseTimeoutAsync(VoiceSession session, ResponseTimeoutEvent timeout, CancellationToken cancellationToken) =>
        OnResponseTimeoutAsync(session, timeout, cancellationToken);

    internal Task InvokeSessionEndAsync(VoiceSession session, SessionEndEvent sessionEnd, CancellationToken cancellationToken) =>
        OnSessionEndAsync(session, sessionEnd, cancellationToken);

    /// <inheritdoc/>
    public sealed override async Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(webSocket);
        ArgumentNullException.ThrowIfNull(context);

        var connection = new VoiceConnection(webSocket, this, cancellationToken);
        await connection.RunAsync().ConfigureAwait(false);
    }
}
