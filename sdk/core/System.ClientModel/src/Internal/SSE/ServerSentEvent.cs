// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace System.ClientModel.Internal;

internal struct PendingEvent
{
    private List<ServerSentEventField>? _dataFields;

    public int DataLength { get; set; }
    public List<ServerSentEventField> DataFields => _dataFields ??= new();
    public ServerSentEventField? EventNameField { get; set; }
    public ServerSentEventField? IdField { get; set; }
    public ServerSentEventField? RetryField { get; set; }
}

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal readonly struct ServerSentEvent
{
    private const char LF = '\n';

    // Gets the value of the SSE "event type" buffer, used to distinguish between event kinds.
    public ReadOnlyMemory<char> EventName { get; }
    // Gets the value of the SSE "data" buffer, which holds the payload of the server-sent event.
    public ReadOnlyMemory<char> Data { get; }
    // Gets the value of the "last event ID" buffer, with which a user agent can reestablish a session.
    public ReadOnlyMemory<char> LastEventId { get; }
    // If present, gets the defined "retry" value for the event, which represents the delay before reconnecting.
    public TimeSpan? ReconnectionTime { get; }

    internal ServerSentEvent(PendingEvent pending)
    {
        if (pending.EventNameField.HasValue)
        {
            EventName = pending.EventNameField.Value.Value;
        }

        if (pending.IdField.HasValue)
        {
            LastEventId = pending.IdField.Value.Value;
        }

        if (pending.RetryField.HasValue)
        {
#if NETSTANDARD2_0
            ReconnectionTime = int.TryParse(pending.RetryField.Value.Value.ToString(), out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
#else
            ReconnectionTime = int.TryParse(pending.RetryField.Value.Value.Span, out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
#endif
        }

        Debug.Assert(pending.DataLength > 0);

        Memory<char> buffer = new(new char[pending.DataLength]);

        int curr = 0;

        foreach (ServerSentEventField field in pending.DataFields)
        {
            Debug.Assert(field.FieldType == ServerSentEventFieldKind.Data);

            field.Value.Span.CopyTo(buffer.Span.Slice(curr));
            buffer.Span[curr + field.Value.Length] = LF;
            curr += field.Value.Length + 1;
        }

        // remove trailing LF.
        Data = buffer.Slice(0, buffer.Length - 1);

        if (EventName.Length == 0)
        {
            // Per spec, if event type buffer is empty, set event.type to "message".
            EventName = "message".ToCharArray();
        }
    }
}
