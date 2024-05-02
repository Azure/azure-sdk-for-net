// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Internal;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal readonly struct ServerSentEvent
{
    // Gets the value of the SSE "event type" buffer, used to distinguish between event kinds.
    public ReadOnlyMemory<char> EventName { get; }
    // Gets the value of the SSE "data" buffer, which holds the payload of the server-sent event.
    public ReadOnlyMemory<char> Data { get; }
    // Gets the value of the "last event ID" buffer, with which a user agent can reestablish a session.
    public ReadOnlyMemory<char> LastEventId { get; }
    // If present, gets the defined "retry" value for the event, which represents the delay before reconnecting.
    public TimeSpan? ReconnectionTime { get; }

    private readonly IReadOnlyList<ServerSentEventField> _fields;
    private readonly string _multiLineData;

    internal ServerSentEvent(IReadOnlyList<ServerSentEventField> fields)
    {
        _fields = fields;
        StringBuilder multiLineDataBuilder = null;
        for (int i = 0; i < _fields.Count; i++)
        {
            ReadOnlyMemory<char> fieldValue = _fields[i].Value;
            switch (_fields[i].FieldType)
            {
                case ServerSentEventFieldKind.Event:
                    EventName = fieldValue;
                    break;
                case ServerSentEventFieldKind.Data:
                    {
                        if (multiLineDataBuilder != null)
                        {
                            multiLineDataBuilder.Append(fieldValue);
                        }
                        else if (Data.IsEmpty)
                        {
                            Data = fieldValue;
                        }
                        else
                        {
                            multiLineDataBuilder ??= new();
                            multiLineDataBuilder.Append(fieldValue);
                            Data = null;
                        }
                        break;
                    }
                case ServerSentEventFieldKind.Id:
                    LastEventId = fieldValue;
                    break;
                case ServerSentEventFieldKind.Retry:
                    ReconnectionTime = Int32.TryParse(fieldValue.ToString(), out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
                    break;
                default:
                    break;
            }
            if (multiLineDataBuilder != null)
            {
                _multiLineData = multiLineDataBuilder.ToString();
                Data = _multiLineData.AsMemory();
            }
        }
    }
}
