// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The in-memory live backing: constant memory, no replay. Subscribers only see
/// events emitted after their iteration begins.
/// </summary>
internal sealed class BroadcastEventStream : AgentEventStream, IDestroyableStream
{
    private readonly object _gate = new();
    private readonly SubscriberHub _hub = new();
    private readonly string _id;
    private StreamState _state = StreamState.Active;
    private string? _lastEventId;

    public BroadcastEventStream(string id) => _id = id;

    public override ValueTask EmitAsync(SseItem<string> item, bool close = false, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new AgentEventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
            }

            if (_state == StreamState.Closed)
            {
                throw new AgentEventStreamClosedException($"Stream '{_id}' is closed; emit is not allowed.");
            }

            _hub.Publish(item);
            _lastEventId = item.EventId ?? _lastEventId;
            if (close)
            {
                _state = StreamState.Closed;
                _hub.CompleteAll();
            }
        }

        return default;
    }

    public override ValueTask CloseAsync(CancellationToken cancellationToken = default)
    {
        lock (_gate)
        {
            if (_state == StreamState.Active)
            {
                _state = StreamState.Closed;
                _hub.CompleteAll();
            }
        }

        return default;
    }

    public override IAsyncEnumerable<SseItem<string>> Subscribe(
        string? afterEventId = null, CancellationToken cancellationToken = default)
    {
        // Validate eagerly (mirroring a synchronous `subscribe`): a NotFound for a destroyed
        // stream must surface at the call site, not be deferred until the caller begins enumerating.
        Channel<SseItem<string>> channel;
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new AgentEventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
            }

            channel = _hub.Add();
            if (_state == StreamState.Closed)
            {
                _hub.Remove(channel);
                channel.Writer.TryComplete();
            }
        }

        return Iterate(channel, cancellationToken);
    }

    private async IAsyncEnumerable<SseItem<string>> Iterate(
        Channel<SseItem<string>> channel, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        try
        {
            await foreach (SseItem<string> item in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            {
                yield return item;
            }
        }
        finally
        {
            lock (_gate)
            {
                _hub.Remove(channel);
            }
        }
    }

    public override ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default)
    {
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new AgentEventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
            }

            // The live backing retains no history, but it still tracks the last emitted id.
            return new ValueTask<string?>(_lastEventId);
        }
    }

    /// <summary>Registry-initiated destruction: completes subscribers and rejects later ops.</summary>
    public void Destroy()
    {
        lock (_gate)
        {
            _state = StreamState.Destroyed;
            _hub.CompleteAll();
        }
    }

    // The broadcast (no-replay) backing has no close-clock TTL, so it never auto-destroys on lookup.
    public bool TryAutoDestroyIfElapsed() => false;
}
