// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

/// <summary>
/// Represents an SSE event.
/// See SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
/// </summary>
internal readonly struct ServerSentEvent
{
    // Gets the value of the SSE "event type" buffer, used to distinguish
    // between event kinds.
    public string EventType { get; }

    // Gets the value of the SSE "data" buffer, which holds the payload of the
    // server-sent event.
    public string Data { get; }

    public ServerSentEvent(string type, string data)
    {
        EventType = type;
        Data = data;
    }
}
