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

    public int? LastEventId { get; private set; }

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

        PendingEvent pending = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // TODO: Pass cancellationToken?
            string? line = _reader.ReadLine();

            if (line is null)
            {
                // A null line indicates end of input
                return null;
            }

            ProcessLine(line, ref pending, out bool dispatch);

            if (dispatch)
            {
                return pending.ToEvent();
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

        PendingEvent pending = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // TODO: Pass cancellationToken?
            string? line = await _reader.ReadLineAsync().ConfigureAwait(false);

            if (line is null)
            {
                // A null line indicates end of input
                return null;
            }

            ProcessLine(line, ref pending, out bool dispatch);

            if (dispatch)
            {
                return pending.ToEvent();
            }
        }
    }

    private static void ProcessLine(string line, ref PendingEvent pending, out bool dispatch)
    {
        dispatch = false;

        if (line.Length == 0)
        {
            if (pending.DataLength == 0)
            {
                // Per spec, if there's no data, don't dispatch an event.
                pending = default;
            }
            else
            {
                dispatch = true;
            }
        }
        else if (line[0] != ':')
        {
            // Per spec, ignore comment lines (i.e. that begin with ':').
            // If we got this far, process the field + value and accumulate
            // it for the next dispatched event.
            ServerSentEventField field = new(line);
            switch (field.FieldType)
            {
                case ServerSentEventFieldKind.Event:
                    pending.EventTypeField = field;
                    break;
                case ServerSentEventFieldKind.Data:
                    // Per spec, we'll append \n when we concatenate the data lines.
                    pending.DataLength += field.Value.Length + 1;
                    pending.DataFields.Add(field);
                    break;
                case ServerSentEventFieldKind.Id:
                    pending.IdField = field;
                    break;
                case ServerSentEventFieldKind.Retry:
                    pending.RetryField = field;
                    break;
                default:
                    // Ignore
                    break;
            }
        }
    }

    private struct PendingEvent
    {
        private const char LF = '\n';

        private List<ServerSentEventField>? _dataFields;

        public int DataLength { get; set; }
        public List<ServerSentEventField> DataFields => _dataFields ??= new();
        public ServerSentEventField? EventTypeField { get; set; }
        public ServerSentEventField? IdField { get; set; }
        public ServerSentEventField? RetryField { get; set; }

        public ServerSentEvent ToEvent()
        {
            // Per spec, if event type buffer is empty, set event.type to "message".
            string type = EventTypeField.HasValue ?
                EventTypeField.Value.Value.ToString() :
                "message";

            string? id = IdField.HasValue && IdField.Value.Value.Length > 0 ?
                IdField.Value.Value.ToString() : default;

            string? retry = RetryField.HasValue && RetryField.Value.Value.Length > 0 ?
                RetryField.Value.Value.ToString() : default;

            Debug.Assert(DataLength > 0);

            Memory<char> buffer = new(new char[DataLength]);

            int curr = 0;

            foreach (ServerSentEventField field in DataFields)
            {
                Debug.Assert(field.FieldType == ServerSentEventFieldKind.Data);

                field.Value.Span.CopyTo(buffer.Span.Slice(curr));
                buffer.Span[curr + field.Value.Length] = LF;
                curr += field.Value.Length + 1;
            }

            // Per spec, remove trailing LF
            string data = buffer.Slice(0, buffer.Length - 1).ToString();

            return new ServerSentEvent(type, data, id, retry);
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
