// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// A single producer/consumer event stream: one or more producers
/// <see cref="EmitAsync"/> events that every attached subscriber receives by
/// iterating <see cref="Subscribe"/>. Mirrors Python's <c>EventStream</c>
/// protocol; obtain instances from <see cref="IEventStreamRegistry"/>.
/// </summary>
public interface IEventStream
{
    /// <summary>
    /// Publishes one event to every currently-attached subscriber. When
    /// <paramref name="close"/> is <see langword="true"/>, the payload is
    /// delivered and the stream is closed atomically.
    /// </summary>
    /// <param name="payload">The event payload (any value compatible with the configured serializer).</param>
    /// <param name="close">Whether to close the stream atomically after delivering the payload.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the event has been published.</returns>
    ValueTask EmitAsync(object payload, bool close = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks the stream done. Idempotent — calling it twice (or on a destroyed
    /// stream) is a no-op. After close, <see cref="EmitAsync"/> raises
    /// <see cref="EventStreamClosedException"/> and subscriber iterators drain
    /// then complete.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the stream is closed.</returns>
    ValueTask CloseAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an async iterator over emitted payloads. With a replay backing,
    /// <paramref name="after"/> yields only events whose cursor is strictly
    /// greater than the supplied value (the reconnection primitive); it is
    /// silently ignored when the backing has no cursor function.
    /// </summary>
    /// <param name="after">The exclusive lower-bound cursor to resume after, or <see langword="null"/> for all events.</param>
    /// <param name="cancellationToken">A token to stop iterating.</param>
    /// <returns>An asynchronous sequence of event payloads.</returns>
    IAsyncEnumerable<object> Subscribe(int? after = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the highest cursor value seen so far, or <see langword="null"/>
    /// when no events were emitted or the backing has no cursor function. Safe
    /// to call on a closed stream (the producer's recovery primitive).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The highest cursor seen, or <see langword="null"/>.</returns>
    ValueTask<int?> GetLastCursorAsync(CancellationToken cancellationToken = default);
}
