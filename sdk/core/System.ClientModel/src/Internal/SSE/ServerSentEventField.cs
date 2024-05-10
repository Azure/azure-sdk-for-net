// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
internal readonly struct ServerSentEventField
{
    private static readonly ReadOnlyMemory<char> s_eventFieldName = "event".AsMemory();
    private static readonly ReadOnlyMemory<char> s_dataFieldName = "data".AsMemory();
    private static readonly ReadOnlyMemory<char> s_lastEventIdFieldName = "id".AsMemory();
    private static readonly ReadOnlyMemory<char> s_retryFieldName = "retry".AsMemory();

    public ServerSentEventFieldKind FieldType { get; }

    // Note: don't expose UTF16 publicly
    public ReadOnlyMemory<char> Value { get; }

    internal ServerSentEventField(string line)
    {
        int colonIndex = line.AsSpan().IndexOf(':');

        ReadOnlyMemory<char> fieldName = colonIndex < 0 ?
            line.AsMemory() :
            line.AsMemory(0, colonIndex);

        FieldType = fieldName.Span switch
        {
            var x when x.SequenceEqual(s_eventFieldName.Span) => ServerSentEventFieldKind.Event,
            var x when x.SequenceEqual(s_dataFieldName.Span) => ServerSentEventFieldKind.Data,
            var x when x.SequenceEqual(s_lastEventIdFieldName.Span) => ServerSentEventFieldKind.Id,
            var x when x.SequenceEqual(s_retryFieldName.Span) => ServerSentEventFieldKind.Retry,
            _ => ServerSentEventFieldKind.Ignore,
        };

        if (colonIndex < 0)
        {
            Value = ReadOnlyMemory<char>.Empty;
        }
        else
        {
            Value = line.AsMemory(colonIndex + 1);

            // Per spec, remove a leading space if present.
            if (Value.Length > 0 && Value.Span[0] == ' ')
            {
                Value = Value.Slice(1);
            }
        }
    }
}
