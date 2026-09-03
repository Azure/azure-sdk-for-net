// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// A single producer/consumer event stream: one or more producers
/// <see cref="EmitAsync"/> <see cref="SseItem{T}"/> events that every attached
/// subscriber receives by iterating <see cref="Subscribe"/>. The event payload is a
/// Server-Sent-Events item (<see cref="SseItem{T}"/> of <see cref="string"/>): the
/// caller places the already-serialized event text in <see cref="SseItem{T}.Data"/>
/// and, for a replay backing, an opaque <see cref="SseItem{T}.EventId"/> used as the
/// resume/reconnect token. Obtain instances from <see cref="AgentEventStreamRegistry"/>.
/// </summary>
public abstract class AgentEventStream
{
    /// <summary>Initializes a new instance of the <see cref="AgentEventStream"/> class.</summary>
    protected AgentEventStream()
    {
    }

    /// <summary>
    /// Publishes one event to every currently-attached subscriber. When
    /// <paramref name="close"/> is <see langword="true"/>, the item is delivered and
    /// the stream is closed atomically.
    /// </summary>
    /// <param name="item">
    /// The event to publish. <see cref="SseItem{T}.Data"/> is the event text; a replay
    /// backing uses <see cref="SseItem{T}.EventId"/> as the opaque resume token.
    /// </param>
    /// <param name="close">Whether to close the stream atomically after delivering the item.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the event has been published.</returns>
    public abstract ValueTask EmitAsync(SseItem<string> item, bool close = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks the stream done. Idempotent — calling it twice (or on a destroyed
    /// stream) is a no-op. After close, <see cref="EmitAsync"/> raises
    /// <see cref="AgentEventStreamClosedException"/> and subscriber iterators drain
    /// then complete.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the stream is closed.</returns>
    public abstract ValueTask CloseAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an async iterator over emitted items. With a replay backing,
    /// <paramref name="afterEventId"/> resumes strictly after the retained item whose
    /// <see cref="SseItem{T}.EventId"/> equals it (the reconnection primitive); a
    /// <see langword="null"/> value yields all retained items, and an id no longer in
    /// the retained window replays all retained items (best-effort, matching SSE
    /// <c>Last-Event-ID</c> semantics). It is silently ignored by a live (non-replay)
    /// backing, which has no history.
    /// </summary>
    /// <param name="afterEventId">The event id to resume strictly after, or <see langword="null"/> for all retained items.</param>
    /// <param name="cancellationToken">A token to stop iterating.</param>
    /// <returns>An asynchronous sequence of event items.</returns>
    public abstract IAsyncEnumerable<SseItem<string>> Subscribe(string? afterEventId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the most recently assigned event id — the <see cref="SseItem{T}.EventId"/> of the
    /// latest emitted item that carried one — or <see langword="null"/> when no emitted item has
    /// carried an id. An item emitted without an <see cref="SseItem{T}.EventId"/> leaves the last
    /// assigned id unchanged (matching SSE last-event-ID buffer semantics). Safe to call on a closed
    /// stream (the producer's recovery primitive).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The most recently assigned event id, or <see langword="null"/>.</returns>
    public abstract ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default);
}
