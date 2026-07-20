// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A no-op event publisher that assigns monotonically increasing sequence numbers
/// but discards all events. Used for execution modes where SSE replay is not
/// applicable (any mode other than <c>background=true, stream=true</c>).
/// </summary>
/// <remarks>
/// <para>
/// Sequence number assignment is still required because the orchestrator reads back
/// <see cref="ResponseStreamEvent.SequenceNumber"/> after publishing to track
/// <see cref="ResponseExecution.LastEmittedSequenceNumber"/> (B9).
/// </para>
/// <para>
/// This avoids allocating a full <see cref="SeekableReplaySubject"/> (with its
/// buffer, write lock, subscriber list, and TTL-based eviction) for modes where
/// the events will never be replayed.
/// </para>
/// </remarks>
internal sealed class NullPublisher : IAsyncObserver<ResponseStreamEvent>
{
    private long _nextSequenceNumber;

    /// <summary>
    /// Assigns a sequence number to the event and discards it.
    /// </summary>
    public ValueTask OnNextAsync(ResponseStreamEvent value)
    {
        value.SequenceNumber = _nextSequenceNumber++;
        return ValueTask.CompletedTask;
    }

    /// <inheritdoc/>
    public ValueTask OnErrorAsync(Exception error) => ValueTask.CompletedTask;

    /// <inheritdoc/>
    public ValueTask OnCompletedAsync() => ValueTask.CompletedTask;
}
