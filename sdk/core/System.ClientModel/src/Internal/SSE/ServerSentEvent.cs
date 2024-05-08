// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Internal;

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

    internal ServerSentEvent(IReadOnlyList<ServerSentEventField> fields)
    {
        int dataLength = 0;
        foreach (ServerSentEventField field in fields)
        {
            switch (field.FieldType)
            {
                case ServerSentEventFieldKind.Event:
                    EventName = field.Value;
                    break;
                case ServerSentEventFieldKind.Data:
                    dataLength += field.Value.Length + 1;
                    break;
                case ServerSentEventFieldKind.Id:
                    LastEventId = field.Value;
                    break;
                case ServerSentEventFieldKind.Retry:
#if NETSTANDARD2_0
                    ReconnectionTime = int.TryParse(field.Value.ToString(), out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
#else
                    ReconnectionTime = int.TryParse(field.Value.Span, out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
#endif
                    break;
                default:
                    break;
            }
        }

        if (dataLength > 0)
        {
            Memory<char> buffer = new(new char[dataLength]);

            int curr = 0;

            foreach (ServerSentEventField field in fields)
            {
                if (field.FieldType == ServerSentEventFieldKind.Data)
                {
                    field.Value.Span.CopyTo(buffer.Span.Slice(curr));
                    buffer.Span[curr + field.Value.Length] = LF;
                    curr += field.Value.Length + 1;
                }
            }

            Data = buffer;
        }
    }
}
