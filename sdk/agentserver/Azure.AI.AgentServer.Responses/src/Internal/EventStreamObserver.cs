// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Adapts a Core <see cref="AgentEventStream"/> or task-bound <see cref="TaskStreamWriter"/> to the
/// orchestrator's push-based <see cref="IAsyncObserver{T}"/> publisher contract. The Responses layer
/// no longer owns an event-stream store; it publishes response events through Core.
/// </summary>
/// <remarks>
/// <para>
/// Sequence numbers are assigned here (monotonic) before an event is published, mirroring
/// <see cref="NullPublisher"/> — the orchestrator reads back
/// <see cref="ResponseStreamEvent.SequenceNumber"/> to track
/// <see cref="ResponseExecution.LastEmittedSequenceNumber"/> (B9), and the sequence number is carried
/// as the Core stream item's event id so replay/reconnect can resume after it.
/// </para>
/// <para>
/// When the stream is a durable rehydrated stream from a prior (crashed) lifetime — created via
/// a stream writer factory, which reads the rehydrated watermark from
/// <see cref="AgentEventStream.GetLastEventIdAsync"/> — two crash-recovery invariants are preserved so
/// the durable stream a client replays stays contiguous with exactly one logical
/// <c>response.created</c> across lifetimes (US3, T036):
/// (1) new events continue numbering past the pre-crash watermark rather than restarting at 0;
/// (2) a re-emitted <c>response.created</c> is dropped (the pre-crash created is already durable),
/// so <c>response.in_progress</c> becomes the client-visible reset.
/// </para>
/// <para>
/// For raw registry streams, completion and error close the stream. For task-bound streams,
/// completion is a no-op because Core closes the transport after the task's terminal transition.
/// </para>
/// </remarks>
internal sealed class EventStreamObserver : IAsyncObserver<ResponseStreamEvent>
{
    private readonly Func<SseItem<string>, CancellationToken, ValueTask> _emit;
    private readonly Func<ValueTask> _complete;
    private readonly Func<Exception, ValueTask> _error;
    private long _nextSequenceNumber;
    private bool _hasCreated;

    private EventStreamObserver(
        Func<SseItem<string>, CancellationToken, ValueTask> emit,
        Func<ValueTask> complete,
        Func<Exception, ValueTask> error,
        long nextSequenceNumber,
        bool hasCreated)
    {
        _emit = emit;
        _complete = complete;
        _error = error;
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
        AgentEventStream stream, CancellationToken cancellationToken = default)
    {
        var lastEventId = await stream.GetLastEventIdAsync(cancellationToken).ConfigureAwait(false);
        GetSequenceSeed(lastEventId, out long nextSequenceNumber, out bool hasCreated);
        return new EventStreamObserver(
            (item, ct) => stream.EmitAsync(item, cancellationToken: ct),
            () => stream.CloseAsync(),
            _ => stream.CloseAsync(),
            nextSequenceNumber,
            hasCreated);
    }

    /// <summary>
    /// Creates a publisher over a task-bound writer. Core owns transport closure for this mode,
    /// after the resilient task's terminal state transition succeeds.
    /// </summary>
    public static async ValueTask<EventStreamObserver> CreateAsync(
        TaskStreamWriter stream,
        CancellationToken cancellationToken = default)
    {
        var lastEventId = await stream.GetLastEventIdAsync(cancellationToken).ConfigureAwait(false);
        GetSequenceSeed(lastEventId, out long nextSequenceNumber, out bool hasCreated);
        return new EventStreamObserver(
            stream.EmitAsync,
            () => ValueTask.CompletedTask,
            error => new ValueTask(Task.FromException(error)),
            nextSequenceNumber,
            hasCreated);
    }

    private static void GetSequenceSeed(
        string? lastEventId,
        out long nextSequenceNumber,
        out bool hasCreated)
    {
        hasCreated = long.TryParse(
            lastEventId,
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            out long watermark);
        nextSequenceNumber = hasCreated ? watermark + 1 : 0;
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
        return _emit(
            ResponseWireStreamCodec.ToWireItem(value, SharedJsonOptions.Instance),
            CancellationToken.None);
    }

    public ValueTask OnErrorAsync(Exception error)
        => _error(error);

    public ValueTask OnCompletedAsync()
        => _complete();
}
