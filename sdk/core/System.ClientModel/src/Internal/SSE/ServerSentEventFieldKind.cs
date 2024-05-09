// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal enum ServerSentEventFieldKind
{
    Ignore,
    Event,
    Data,
    Id,
    Retry,
}
