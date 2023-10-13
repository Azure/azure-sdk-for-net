// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.ChatProtocol;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal readonly struct SseLine
{
    private readonly string _original;
    private readonly int _colonIndex;
    private readonly int _valueIndex;

    public static SseLine Empty { get; } = new SseLine(string.Empty, 0, false);

    internal SseLine(string original, int colonIndex, bool hasSpaceAfterColon)
    {
        _original = original;
        _colonIndex = colonIndex;
        _valueIndex = colonIndex + (hasSpaceAfterColon ? 2 : 1);
    }

    public bool IsEmpty => _original.Length == 0;
    public bool IsComment => !IsEmpty && _original[0] == ':';

    public bool IsDone => _original.Equals("[DONE]");

    // TODO: we should not expose UTF16 publicly
    public ReadOnlyMemory<char> FieldName => _original.AsMemory(0, _colonIndex);
    public ReadOnlyMemory<char> FieldValue => _original.AsMemory(_valueIndex);

    public override string ToString() => _original;
}
