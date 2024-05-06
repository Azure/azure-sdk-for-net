// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

// TODO: Different sync and async readers to dispose differently?
internal sealed class ServerSentEventReader : IDisposable, IAsyncDisposable
{
    private Stream? _stream;
    private StreamReader? _reader;

    public ServerSentEventReader(Stream stream)
    {
        _stream = stream;
        _reader = new StreamReader(stream);
    }

    /// <summary>
    /// Synchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    /// available and returning null once no further data is present on the stream.
    /// </summary>
    /// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    /// <returns>
    ///     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    /// </returns>
    public ServerSentEvent? TryGetNextEvent(CancellationToken cancellationToken = default)
    {
        if (_reader is null)
        {
            throw new ObjectDisposedException(nameof(ServerSentEventReader));
        }

        List<ServerSentEventField>? fields = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // TODO: Pass cancellationToken?
            string? line = _reader.ReadLine();

            if (line == null)
            {
                // A null line indicates end of input
                return null;
            }
            else if (line.Length == 0)
            {
                Debug.Assert(fields is not null);

                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields!);
                fields = default;
                return nextEvent;
            }
            else if (line[0] == ':')
            {
                // A line beginning with a colon is a comment and should be ignored
                continue;
            }
            else
            {
                // Otherwise, process the the field + value and accumulate it for the next dispatched event
                fields ??= new();
                fields.Add(new ServerSentEventField(line));
            }
        }
    }

    /// <summary>
    /// Asynchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    /// available and returning null once no further data is present on the stream.
    /// </summary>
    /// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    /// <returns>
    ///     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    /// </returns>
    public async Task<ServerSentEvent?> TryGetNextEventAsync(CancellationToken cancellationToken = default)
    {
        if (_reader is null)
        {
            throw new ObjectDisposedException(nameof(ServerSentEventReader));
        }

        List<ServerSentEventField>? fields = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string? line = await _reader.ReadLineAsync().ConfigureAwait(false);

            if (line == null)
            {
                // A null line indicates end of input
                return null;
            }
            else if (line.Length == 0)
            {
                Debug.Assert(fields is not null);

                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields!);
                fields = default;
                return nextEvent;
            }
            else if (line[0] == ':')
            {
                // A line beginning with a colon is a comment and should be ignored
                continue;
            }
            else
            {
                // Otherwise, process the the field + value and accumulate it for the next dispatched event
                fields ??= new();
                fields.Add(new ServerSentEventField(line));
            }
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _reader?.Dispose();
            _reader = null;

            _stream?.Dispose();
            _stream = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    private async ValueTask DisposeAsyncCore()
    {
        if (_reader is IAsyncDisposable reader)
        {
            await reader.DisposeAsync().ConfigureAwait(false);
        }
        else
        {
            _reader?.Dispose();
        }

        if (_stream is IAsyncDisposable stream)
        {
            await stream.DisposeAsync().ConfigureAwait(false);
        }
        else
        {
            _stream?.Dispose();
        }

        _reader = null;
        _stream = null;
    }
}
