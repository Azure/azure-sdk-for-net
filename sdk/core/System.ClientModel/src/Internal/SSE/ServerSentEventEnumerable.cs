// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace System.ClientModel.Internal;

/// <summary>
/// Represents a collection of SSE events that can be enumerated as a C# collection.
/// </summary>
internal class ServerSentEventEnumerable : IEnumerable<ServerSentEvent>
{
    private readonly Stream _contentStream;

    public ServerSentEventEnumerable(Stream contentStream)
    {
        Argument.AssertNotNull(contentStream, nameof(contentStream));

        _contentStream = contentStream;

        LastEventId = string.Empty;
        ReconnectionInterval = Timeout.InfiniteTimeSpan;
    }

    public string LastEventId { get; private set; }

    public TimeSpan ReconnectionInterval { get; private set; }

    public IEnumerator<ServerSentEvent> GetEnumerator()
    {
        return new ServerSentEventEnumerator(_contentStream, this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private sealed class ServerSentEventEnumerator : IEnumerator<ServerSentEvent>
    {
        private readonly ServerSentEventReader _reader;
        private readonly ServerSentEventEnumerable _enumerable;

        public ServerSentEventEnumerator(Stream contentStream, ServerSentEventEnumerable enumerable)
        {
            _reader = new(contentStream);
            _enumerable = enumerable;
        }

        public ServerSentEvent Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            ServerSentEvent? nextEvent = _reader.TryGetNextEvent();
            _enumerable.LastEventId = _reader.LastEventId;
            _enumerable.ReconnectionInterval= _reader.ReconnectionInterval;

            if (nextEvent.HasValue)
            {
                Current = nextEvent.Value;
                return true;
            }

            Current = default;
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException("Cannot seek back in an SSE stream.");
        }

        public void Dispose()
        {
            // The creator of the enumerable has responsibility for disposing
            // the content stream passed to the enumerable constructor.
        }
    }
}
