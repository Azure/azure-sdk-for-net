// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
internal readonly struct ServerSentEvent
{
    // Gets the value of the SSE "event type" buffer, used to distinguish between event kinds.
    public string EventType { get; }

    // Gets the value of the SSE "data" buffer, which holds the payload of the server-sent event.
    public string Data { get; }

    // Gets the value of the "last event ID" buffer, with which a user agent can reestablish a session.
    public string? Id { get; }

    // If present, gets the defined "retry" value for the event, which represents the delay before reconnecting.
    public TimeSpan? ReconnectionTime { get; }

    public ServerSentEvent(string type, string data, string? id, string? retry)
    {
        EventType = type;
        Data = data;
        Id = id;
        ReconnectionTime = retry is null ? null :
            int.TryParse(retry, out int time) ? TimeSpan.FromMilliseconds(time) : null;
    }
}
