// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A seekable replay subject that buffers events with sequence numbers and supports
/// cursor-based seeking and time-based expiry.
/// </summary>
/// <remarks>
/// <para>
/// Internal storage uses <c>(long SequenceNumber, ResponseStreamEvent Event)</c> tuples
/// with timestamps for TTL-based eviction. The publisher assigns monotonically increasing
/// sequence numbers. Subscribers can provide a cursor to skip events at or before the cursor value.
/// </para>
/// <para>
/// Write serialization is enforced via a <see cref="SemaphoreSlim"/> to ensure
/// sequential writes per the R2 design decision.
/// </para>
/// </remarks>
internal sealed class SeekableReplaySubject : IDisposable
{
    private readonly TimeSpan _window;
    private readonly TimeProvider _timeProvider;
    private readonly SemaphoreSlim _writeLock = new(1, 1);
    private readonly List<BufferedItem> _buffer = new();
    private readonly List<SubscriberEntry> _subscribers = new();
    private readonly object _subscribersLock = new();
    private long _nextSequenceId;
    private bool _completed;
    private Exception? _error;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of <see cref="SeekableReplaySubject"/> with a TTL window.
    /// </summary>
    /// <param name="window">The time-to-live for buffered events.</param>
    /// <param name="timeProvider">Optional time provider for testing. Defaults to <see cref="TimeProvider.System"/>.</param>
    public SeekableReplaySubject(TimeSpan window, TimeProvider? timeProvider = null)
    {
        _window = window;
        _timeProvider = timeProvider ?? TimeProvider.System;
    }

    /// <summary>
    /// Returns a projecting <see cref="IAsyncObserver{T}"/> that accepts
    /// <see cref="ResponseStreamEvent"/> values, assigns sequence numbers,
    /// and pushes <c>(long, ResponseStreamEvent)</c> tuples to the internal buffer.
    /// </summary>
    public IAsyncObserver<ResponseStreamEvent> GetPublisher() => new PublishingObserver(this);

    /// <summary>
    /// Subscribes an observer to the subject. If a cursor is provided,
    /// events with <c>SequenceNumber &lt;= cursor</c> are skipped.
    /// </summary>
    /// <param name="observer">
    /// The observer to receive <c>(long SequenceNumber, ResponseStreamEvent Event)</c> tuples.
    /// </param>
    /// <param name="cursor">
    /// Optional cursor. When non-null, only events with <c>SequenceNumber &gt; cursor</c>
    /// are delivered. When null, all buffered events are delivered.
    /// </param>
    /// <returns>An <see cref="IAsyncDisposable"/> that unsubscribes when disposed.</returns>
    public async ValueTask<IAsyncDisposable> SubscribeAsync(
        IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)> observer,
        long? cursor)
    {
        var effectiveObserver = cursor.HasValue
            ? new FilteringObserver(observer, cursor.Value)
            : observer;

        // Replay buffered items and register for live events atomically.
        // We hold the write lock to ensure no events arrive between replay and registration.
        await _writeLock.WaitAsync().ConfigureAwait(false);
        try
        {
            PruneExpired();

            // Replay buffered items
            foreach (var item in _buffer)
            {
                await effectiveObserver.OnNextAsync((item.SequenceNumber, item.Event)).ConfigureAwait(false);
            }

            // If already completed or errored, send terminal signal
            if (_error != null)
            {
                await effectiveObserver.OnErrorAsync(_error).ConfigureAwait(false);
                return new NoOpDisposable();
            }

            if (_completed)
            {
                await effectiveObserver.OnCompletedAsync().ConfigureAwait(false);
                return new NoOpDisposable();
            }

            // Register for live events
            var entry = new SubscriberEntry(effectiveObserver);
            lock (_subscribersLock)
            {
                _subscribers.Add(entry);
            }

            return new SubscriptionDisposable(this, entry);
        }
        finally
        {
            _writeLock.Release();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_disposed)
            return;
        _disposed = true;
        _writeLock.Dispose();
        lock (_subscribersLock)
        {
            _subscribers.Clear();
        }
        _buffer.Clear();
    }

    private void PruneExpired()
    {
        var cutoff = _timeProvider.GetUtcNow() - _window;
        _buffer.RemoveAll(item => item.Timestamp < cutoff);
    }

    private void RemoveSubscriber(SubscriberEntry entry)
    {
        lock (_subscribersLock)
        {
            _subscribers.Remove(entry);
        }
    }

    private async ValueTask PublishToSubscribersAsync((long SequenceNumber, ResponseStreamEvent Event) value)
    {
        List<SubscriberEntry> snapshot;
        lock (_subscribersLock)
        {
            snapshot = new List<SubscriberEntry>(_subscribers);
        }

        foreach (var entry in snapshot)
        {
            try
            {
                await entry.Observer.OnNextAsync(value).ConfigureAwait(false);
            }
            catch
            {
                // If a subscriber throws, remove it to prevent cascading failures
                RemoveSubscriber(entry);
            }
        }
    }

    private async ValueTask CompleteSubscribersAsync()
    {
        List<SubscriberEntry> snapshot;
        lock (_subscribersLock)
        {
            snapshot = new List<SubscriberEntry>(_subscribers);
            _subscribers.Clear();
        }

        foreach (var entry in snapshot)
        {
            try
            {
                await entry.Observer.OnCompletedAsync().ConfigureAwait(false);
            }
            catch
            {
                // Swallow subscriber errors during completion
            }
        }
    }

    private async ValueTask ErrorSubscribersAsync(Exception error)
    {
        List<SubscriberEntry> snapshot;
        lock (_subscribersLock)
        {
            snapshot = new List<SubscriberEntry>(_subscribers);
            _subscribers.Clear();
        }

        foreach (var entry in snapshot)
        {
            try
            {
                await entry.Observer.OnErrorAsync(error).ConfigureAwait(false);
            }
            catch
            {
                // Swallow subscriber errors during error propagation
            }
        }
    }

    // ── Nested types ───────────────────────────────────────

    private sealed record BufferedItem(long SequenceNumber, ResponseStreamEvent Event, DateTimeOffset Timestamp);

    private sealed class SubscriberEntry
    {
        public IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)> Observer { get; }

        public SubscriberEntry(IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)> observer)
        {
            Observer = observer;
        }
    }

    /// <summary>
    /// A projecting observer that accepts raw <see cref="ResponseStreamEvent"/> values,
    /// assigns sequence numbers, and publishes to the buffer and live subscribers.
    /// </summary>
    private sealed class PublishingObserver : IAsyncObserver<ResponseStreamEvent>
    {
        private readonly SeekableReplaySubject _subject;

        public PublishingObserver(SeekableReplaySubject subject)
        {
            _subject = subject;
        }

        public async ValueTask OnNextAsync(ResponseStreamEvent value)
        {
            await _subject._writeLock.WaitAsync().ConfigureAwait(false);
            try
            {
                var seqNo = _subject._nextSequenceId++;
                value.SequenceNumber = seqNo;
                var timestamp = _subject._timeProvider.GetUtcNow();
                _subject._buffer.Add(new BufferedItem(seqNo, value, timestamp));
                _subject.PruneExpired();
                await _subject.PublishToSubscribersAsync((seqNo, value)).ConfigureAwait(false);
            }
            finally
            {
                _subject._writeLock.Release();
            }
        }

        public async ValueTask OnErrorAsync(Exception error)
        {
            await _subject._writeLock.WaitAsync().ConfigureAwait(false);
            try
            {
                _subject._error = error;
                await _subject.ErrorSubscribersAsync(error).ConfigureAwait(false);
            }
            finally
            {
                _subject._writeLock.Release();
            }
        }

        public async ValueTask OnCompletedAsync()
        {
            await _subject._writeLock.WaitAsync().ConfigureAwait(false);
            try
            {
                _subject._completed = true;
                await _subject.CompleteSubscribersAsync().ConfigureAwait(false);
            }
            finally
            {
                _subject._writeLock.Release();
            }
        }
    }

    /// <summary>
    /// A filtering observer that skips events with <c>SequenceNumber &lt;= cursor</c>
    /// and forwards the rest.
    /// </summary>
    private sealed class FilteringObserver : IAsyncObserver<(long SequenceNumber, ResponseStreamEvent Event)>
    {
        private readonly IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)> _inner;
        private readonly long _cursor;

        public FilteringObserver(
            IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)> inner,
            long cursor)
        {
            _inner = inner;
            _cursor = cursor;
        }

        public async ValueTask OnNextAsync((long SequenceNumber, ResponseStreamEvent Event) value)
        {
            if (value.SequenceNumber > _cursor)
            {
                await _inner.OnNextAsync(value).ConfigureAwait(false);
            }
        }

        public ValueTask OnErrorAsync(Exception error) => _inner.OnErrorAsync(error);

        public ValueTask OnCompletedAsync() => _inner.OnCompletedAsync();
    }

    private sealed class NoOpDisposable : IAsyncDisposable
    {
        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
    }

    private sealed class SubscriptionDisposable : IAsyncDisposable
    {
        private readonly SeekableReplaySubject _subject;
        private readonly SubscriberEntry _entry;

        public SubscriptionDisposable(SeekableReplaySubject subject, SubscriberEntry entry)
        {
            _subject = subject;
            _entry = entry;
        }

        public ValueTask DisposeAsync()
        {
            _subject.RemoveSubscriber(_entry);
            return ValueTask.CompletedTask;
        }
    }
}
