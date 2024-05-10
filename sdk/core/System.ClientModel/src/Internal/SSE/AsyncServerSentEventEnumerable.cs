// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

/// <summary>
/// Represents a collection of SSE events that can be enumerated as a C# async stream.
/// </summary>
internal class AsyncServerSentEventEnumerable : IAsyncEnumerable<ServerSentEvent>
{
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
            ServerSentEvent? nextEvent = await _reader.TryGetNextEventAsync(_cancellationToken).ConfigureAwait(false);

            if (nextEvent.HasValue)
            {
                Current = nextEvent.Value;
                return true;
            }

            Current = default;
            return false;
        }

        public ValueTask DisposeAsync()
        {
            // The creator of the enumerable has responsibility for disposing
            // the content stream passed to the enumerable constructor.

#if NET6_0_OR_GREATER
            return ValueTask.CompletedTask;
#else
            return new ValueTask();
#endif
        }
    }
}
