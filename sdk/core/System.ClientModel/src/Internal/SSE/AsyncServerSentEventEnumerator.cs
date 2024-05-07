// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal sealed class AsyncServerSentEventEnumerator : IAsyncEnumerator<ServerSentEvent>
{
    private readonly ReadOnlyMemory<char> _terminalEvent;
    private readonly CancellationToken _cancellationToken;

    private ServerSentEventReader? _reader;
    private ServerSentEvent _current;

    public ServerSentEvent Current => _current;

    public AsyncServerSentEventEnumerator(Stream contentStream, string terminalEvent, CancellationToken cancellationToken = default)
    {
        _reader = new(contentStream);
        _cancellationToken = cancellationToken;
        _terminalEvent = terminalEvent.AsMemory();
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
            if (nextEvent.Value.Data.Span.SequenceEqual(_terminalEvent.Span))
            {
                _current = default;
                return false;
            }

            _current = nextEvent.Value;
            return true;
        }

        return false;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        GC.SuppressFinalize(this);
    }

    private async ValueTask DisposeAsyncCore()
    {
        if (_reader is not null)
        {
            await _reader.DisposeAsync().ConfigureAwait(false);
            _reader = null;
        }
    }
}
