// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

/// <summary>
/// The kind of line or field received over an SSE stream.
/// See SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
/// </summary>
internal enum ServerSentEventFieldKind
{
    Ignore,
    Event,
    Data,
    Id,
    Retry,
}
