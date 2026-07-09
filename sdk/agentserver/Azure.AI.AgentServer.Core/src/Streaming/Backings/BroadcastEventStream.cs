// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>
/// The in-memory live backing: constant memory, no replay. Subscribers only see
/// events emitted after their iteration begins. Mirrors Python's live backing.
/// </summary>
internal sealed class BroadcastEventStream : IEventStream, IDestroyableStream
{
    private readonly object _gate = new();
    private readonly SubscriberHub _hub = new();
    private readonly string _id;
    private StreamState _state = StreamState.Active;

    public BroadcastEventStream(string id) => _id = id;

    public ValueTask EmitAsync(object payload, bool close = false, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new EventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
            }

            if (_state == StreamState.Closed)
            {
                throw new EventStreamClosedException($"Stream '{_id}' is closed; emit is not allowed.");
            }

            _hub.Publish(payload);
            if (close)
            {
                _state = StreamState.Closed;
                _hub.CompleteAll();
            }
        }

        return default;
    }

    public ValueTask CloseAsync(CancellationToken cancellationToken = default)
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

    public IAsyncEnumerable<object> Subscribe(
        int? after = null, CancellationToken cancellationToken = default)
    {
        // Validate eagerly (mirroring Python's synchronous `subscribe`): a NotFound for a destroyed
        // stream must surface at the call site, not be deferred until the caller begins enumerating.
        Channel<object> channel;
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new EventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
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

    private async IAsyncEnumerable<object> Iterate(
        Channel<object> channel, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        try
        {
            await foreach (object item in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
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

    public ValueTask<int?> GetLastCursorAsync(CancellationToken cancellationToken = default)
    {
        lock (_gate)
        {
            if (_state == StreamState.Destroyed)
            {
                throw new EventStreamNotFoundException($"Stream '{_id}' is not a live stream.");
            }
        }

        // The live backing has no cursor function.
        return new ValueTask<int?>((int?)null);
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
