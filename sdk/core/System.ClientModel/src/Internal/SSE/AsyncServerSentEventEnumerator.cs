// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal sealed class AsyncServerSentEventEnumerator : IAsyncEnumerator<ServerSentEvent>, IDisposable, IAsyncDisposable
{
    private static readonly ReadOnlyMemory<char> _doneToken = "[DONE]".AsMemory();

    private readonly ServerSentEventReader _reader;
    private CancellationToken _cancellationToken;
    private bool _disposedValue;

    public ServerSentEvent Current { get; private set; }

    public AsyncServerSentEventEnumerator(ServerSentEventReader reader, CancellationToken cancellationToken = default)
    {
        _reader = reader;
        _cancellationToken = cancellationToken;
    }

    public async ValueTask<bool> MoveNextAsync()
    {
        ServerSentEvent? nextEvent = await _reader.TryGetNextEventAsync(_cancellationToken).ConfigureAwait(false);
        if (nextEvent.HasValue)
        {
            if (nextEvent.Value.Data.Span.SequenceEqual(_doneToken.Span))
            {
                return false;
            }
            Current = nextEvent.Value;
            return true;
        }
        return false;
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _reader.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public ValueTask DisposeAsync()
    {
        Dispose();
        return new ValueTask();
    }
}
