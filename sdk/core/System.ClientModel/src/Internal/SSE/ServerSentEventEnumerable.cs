// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace System.ClientModel.Internal;

internal class ServerSentEventEnumerable : IEnumerable<ServerSentEvent>
{
    private readonly Stream _contentStream;

    public ServerSentEventEnumerable(Stream contentStream)
    {
        _contentStream = contentStream;
    }

    public IEnumerator<ServerSentEvent> GetEnumerator()
    {
        return new ServerSentEventEnumerator(_contentStream);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private sealed class ServerSentEventEnumerator : IEnumerator<ServerSentEvent>
    {
        private readonly ServerSentEventReader _reader;

        public ServerSentEventEnumerator(Stream contentStream)
        {
            _reader = new(contentStream);
        }

        public ServerSentEvent Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            ServerSentEvent? nextEvent = _reader.TryGetNextEvent();

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
