// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

/// <summary>
/// An SSE event reader that reads lines from an SSE stream and composes them
/// into SSE events.
/// See SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
/// </summary>
internal sealed class ServerSentEventReader
{
    private readonly StreamReader _reader;

    public ServerSentEventReader(Stream stream)
    {
        Argument.AssertNotNull(stream, nameof(stream));

        // The creator of the reader has responsibility for disposing the
        // stream passed to the reader's constructor.
        _reader = new StreamReader(stream);

        LastEventId = string.Empty;
        ReconnectionInterval = Timeout.InfiniteTimeSpan;
    }

    public string LastEventId { get; private set; }

    public TimeSpan ReconnectionInterval { get; private set; }

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
        PendingEvent pending = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Note: would be nice to have polyfill that takes cancellation token,
            // but may become moot if we shift to all UTF-8.
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
        PendingEvent pending = default;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Note: would be nice to have polyfill that takes cancellation token,
            // but may become moot if we shift to all UTF-8.
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

    private void ProcessLine(string line, ref PendingEvent pending, out bool dispatch)
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
                    LastEventId = field.Value.ToString();
                    break;
                case ServerSentEventFieldKind.Retry:
                    if (field.Value.Length > 0 && int.TryParse(field.Value.ToString(), out int retry))
                    {
                        ReconnectionInterval = TimeSpan.FromMilliseconds(retry);
                    }
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

        public ServerSentEvent ToEvent()
        {
            Debug.Assert(DataLength > 0);

            // Per spec, if event type buffer is empty, set event.type to "message".
            string type = EventTypeField.HasValue ?
                EventTypeField.Value.Value.ToString() :
                "message";

            Memory<char> buffer = new(new char[DataLength]);

            int curr = 0;
            foreach (ServerSentEventField field in DataFields)
            {
                Debug.Assert(field.FieldType == ServerSentEventFieldKind.Data);

                field.Value.Span.CopyTo(buffer.Span.Slice(curr));

                // Per spec, append trailing LF to each data field value.
                buffer.Span[curr + field.Value.Length] = LF;
                curr += field.Value.Length + 1;
            }

            // Per spec, remove trailing LF from concatenated data fields.
            string data = buffer.Slice(0, buffer.Length - 1).ToString();

            return new ServerSentEvent(type, data);
        }
    }
}
