// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Adapts a Core <see cref="IEventStream"/> to the orchestrator's push-based
/// <see cref="IAsyncObserver{T}"/> publisher contract. The Responses layer no longer owns an
/// event-stream store; it publishes response events onto the Core event-stream primitive
/// (obtained from <see cref="IEventStreamRegistry"/>), mirroring the Python implementation.
/// </summary>
/// <remarks>
/// <para>
/// Sequence numbers are assigned here (monotonic) before an event is published, mirroring
/// <see cref="NullPublisher"/> — the orchestrator reads back
/// <see cref="ResponseStreamEvent.SequenceNumber"/> to track
/// <see cref="ResponseExecution.LastEmittedSequenceNumber"/> (B9), and the Core stream's cursor
/// function reads the same field from the payload for replay/reconnect.
/// </para>
/// <para>
/// When the stream is a durable rehydrated stream from a prior (crashed) lifetime — created via
/// <see cref="CreateAsync"/>, which reads the rehydrated watermark from
/// <see cref="IEventStream.GetLastCursorAsync"/> — two crash-recovery invariants are preserved so
/// the durable stream a client replays stays contiguous with exactly one logical
/// <c>response.created</c> across lifetimes (US3, T036):
/// (1) new events continue numbering past the pre-crash watermark rather than restarting at 0;
/// (2) a re-emitted <c>response.created</c> is dropped (the pre-crash created is already durable),
/// so <c>response.in_progress</c> becomes the client-visible reset.
/// </para>
/// <para>
/// Completion and error both close the Core stream (Core has no separate error channel), which
/// drains attached subscribers and ends SSE replay.
/// </para>
/// </remarks>
internal sealed class EventStreamObserver : IAsyncObserver<ResponseStreamEvent>
{
    private readonly IEventStream _stream;
    private long _nextSequenceNumber;
    private bool _hasCreated;

    private EventStreamObserver(IEventStream stream, long nextSequenceNumber, bool hasCreated)
    {
        _stream = stream;
        _nextSequenceNumber = nextSequenceNumber;
        _hasCreated = hasCreated;
    }

    /// <summary>
    /// Creates a publisher over <paramref name="stream"/>, seeding the sequence counter and the
    /// single-created gate from the stream's rehydrated watermark. For a fresh (empty) stream the
    /// watermark is <see langword="null"/> so numbering starts at 0 and the first
    /// <c>response.created</c> is appended normally; for a durable rehydrated stream (recovery) the
    /// watermark continues numbering and the re-emitted created is deduplicated.
    /// </summary>
    public static async ValueTask<EventStreamObserver> CreateAsync(
        IEventStream stream, CancellationToken cancellationToken = default)
    {
        var lastCursor = await stream.GetLastCursorAsync(cancellationToken).ConfigureAwait(false);
        return lastCursor is int watermark
            ? new EventStreamObserver(stream, watermark + 1, hasCreated: true)
            : new EventStreamObserver(stream, nextSequenceNumber: 0, hasCreated: false);
    }

    public ValueTask OnNextAsync(ResponseStreamEvent value)
    {
        // Idempotent-create gate (T036): a durable stream carries exactly one response.created
        // across process lifetimes. On recovery the handler re-emits created, but the pre-crash
        // created is already durable (reflected by _hasCreated seeded from the watermark). Drop the
        // duplicate without consuming a sequence number or emitting to the stream so the subsequent
        // response.in_progress reset is contiguous with the pre-crash suffix.
        if (value is ResponseCreatedEvent && _hasCreated)
        {
            return ValueTask.CompletedTask;
        }

        if (value is ResponseCreatedEvent)
        {
            _hasCreated = true;
        }

        value.SequenceNumber = _nextSequenceNumber++;
        return _stream.EmitAsync(value);
    }

    public ValueTask OnErrorAsync(Exception error)
        => _stream.CloseAsync();

    public ValueTask OnCompletedAsync()
        => _stream.CloseAsync();
}
