// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reactive.Subjects;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// A seekable replay subject that wraps <see cref="ConcurrentReplayAsyncSubject{T}"/>
/// with sequence number assignment and cursor-based filtering.
/// </summary>
/// <remarks>
/// <para>
/// Internal storage uses <c>(long SequenceNumber, ResponseStreamEvent Event)</c> tuples.
/// The publisher assigns monotonically increasing sequence numbers.
/// Subscribers can provide a cursor to skip events at or before the cursor value.
/// </para>
/// <para>
/// Write serialization is enforced via a <see cref="SemaphoreSlim"/> to ensure
/// sequential writes per the R2 design decision.
/// </para>
/// </remarks>
internal sealed class SeekableReplaySubject : IDisposable
{
    private readonly ConcurrentReplayAsyncSubject<(long SequenceNumber, ResponseStreamEvent Event)> _inner;
    private readonly SemaphoreSlim _writeLock = new(1, 1);
    private long _nextSequenceId;

    /// <summary>
    /// Initializes a new instance of <see cref="SeekableReplaySubject"/> with a TTL window.
    /// </summary>
    /// <param name="window">The time-to-live for buffered events.</param>
    public SeekableReplaySubject(TimeSpan window)
    {
        _inner = new ConcurrentReplayAsyncSubject<(long, ResponseStreamEvent)>(window);
    }

    /// <summary>
    /// Returns a projecting <see cref="IAsyncObserver{T}"/> that accepts
    /// <see cref="ResponseStreamEvent"/> values, assigns sequence numbers,
    /// and pushes <c>(long, ResponseStreamEvent)</c> tuples to the inner subject.
    /// </summary>
    public IAsyncObserver<ResponseStreamEvent> GetPublisher() => new PublishingObserver(this);

    /// <summary>
    /// Subscribes an observer to the inner subject. If a cursor is provided,
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
        if (cursor.HasValue)
        {
            var filtering = new FilteringObserver(observer, cursor.Value);
            return await _inner.SubscribeAsync(filtering).ConfigureAwait(false);
        }

        return await _inner.SubscribeAsync(observer).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _writeLock.Dispose();
        // ConcurrentReplayAsyncSubject does not implement IDisposable,
        // but we null-out to aid GC.
    }

    /// <summary>
    /// A projecting observer that accepts raw <see cref="ResponseStreamEvent"/> values,
    /// assigns sequence numbers, and publishes <c>(long, ResponseStreamEvent)</c> tuples
    /// to the inner subject.
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
                await _subject._inner.OnNextAsync((seqNo, value)).ConfigureAwait(false);
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
                await _subject._inner.OnErrorAsync(error).ConfigureAwait(false);
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
                await _subject._inner.OnCompletedAsync().ConfigureAwait(false);
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
}
