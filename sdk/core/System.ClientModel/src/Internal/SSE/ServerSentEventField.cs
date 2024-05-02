// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal readonly struct ServerSentEventField
{
    public ServerSentEventFieldKind FieldType { get; }

    // TODO: we should not expose UTF16 publicly
    public ReadOnlyMemory<char> Value
    {
        get
        {
            if (_valueStartIndex >= _original.Length)
            {
                return ReadOnlyMemory<char>.Empty;
            }
            else
            {
                return _original.AsMemory(_valueStartIndex);
            }
        }
    }

    private readonly string _original;
    private readonly int _valueStartIndex;

    internal ServerSentEventField(string line)
    {
        _original = line;
        int colonIndex = _original.AsSpan().IndexOf(':');

        ReadOnlyMemory<char> fieldName = colonIndex < 0 ? _original.AsMemory(): _original.AsMemory(0, colonIndex);
        FieldType = fieldName.Span switch
        {
            var x when x.SequenceEqual(s_eventFieldName.Span) => ServerSentEventFieldKind.Event,
            var x when x.SequenceEqual(s_dataFieldName.Span) => ServerSentEventFieldKind.Data,
            var x when x.SequenceEqual(s_lastEventIdFieldName.Span) => ServerSentEventFieldKind.Id,
            var x when x.SequenceEqual(s_retryFieldName.Span) => ServerSentEventFieldKind.Retry,
            _ => ServerSentEventFieldKind.Ignored,
        };

        if (colonIndex < 0)
        {
            _valueStartIndex = _original.Length;
        }
        else if (colonIndex + 1 < _original.Length && _original[colonIndex + 1] == ' ')
        {
            _valueStartIndex = colonIndex + 2;
        }
        else
        {
            _valueStartIndex = colonIndex + 1;
        }
    }

    public override string ToString() => _original;

    private static readonly ReadOnlyMemory<char> s_eventFieldName = "event".AsMemory();
    private static readonly ReadOnlyMemory<char> s_dataFieldName = "data".AsMemory();
    private static readonly ReadOnlyMemory<char> s_lastEventIdFieldName = "id".AsMemory();
    private static readonly ReadOnlyMemory<char> s_retryFieldName = "retry".AsMemory();
}
