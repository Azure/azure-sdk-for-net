// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class AsyncServerSentEventEnumerable : IAsyncEnumerable<ServerSentEvent>
{
    // Note: in this factoring, the creator of the enumerable has responsibility
    // for disposing the content stream.
    private readonly Stream _contentStream;

    public AsyncServerSentEventEnumerable(Stream contentStream)
    {
        _contentStream = contentStream;
    }

    public IAsyncEnumerator<ServerSentEvent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncServerSentEventEnumerator(_contentStream, cancellationToken);
    }

    private sealed class AsyncServerSentEventEnumerator : IAsyncEnumerator<ServerSentEvent>
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ServerSentEventReader _reader;

        public ServerSentEvent Current { get; private set; }

        public AsyncServerSentEventEnumerator(Stream contentStream, CancellationToken cancellationToken = default)
        {
            _reader = new(contentStream);
            _cancellationToken = cancellationToken;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (_reader is null)
            {
                throw new ObjectDisposedException(nameof(AsyncServerSentEventEnumerator));
            }

            ServerSentEvent? nextEvent = await _reader.TryGetNextEventAsync(_cancellationToken).ConfigureAwait(false);

            if (nextEvent.HasValue)
            {
                Current = nextEvent.Value;
                return true;
            }

            Current = default;
            return false;
        }

        public ValueTask DisposeAsync() => new ValueTask();
    }
}
