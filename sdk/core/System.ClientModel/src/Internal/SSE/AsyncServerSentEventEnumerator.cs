// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal sealed class AsyncServerSentEventEnumerator : IAsyncEnumerator<ServerSentEvent>
{
    // TODO: make this configurable per coming from TypeSpec
    private static readonly ReadOnlyMemory<char> _doneToken = "[DONE]".AsMemory();

    private readonly CancellationToken _cancellationToken;
    private ServerSentEventReader? _reader;

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

        if (_cancellationToken.IsCancellationRequested)
        {
            // TODO: correct to return false in this case?
            // Or do we throw TaskCancelledException?
            return false;
        }

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
