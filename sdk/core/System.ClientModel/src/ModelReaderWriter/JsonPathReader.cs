// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal enum JsonPathTokenType
{
    Root,               // $
    PropertySeparator,  // .
    Property,           // propertyName
    ArrayStart,         // [
    ArrayEnd,           // ]
    QuotedString,       // 'value' or "value"
    Number,             // 123
    End
}

internal readonly ref struct JsonPathToken
{
    public int TokenStartIndex { get; }
    public JsonPathTokenType TokenType { get; }
    public ReadOnlySpan<byte> ValueSpan { get; }

    public JsonPathToken(JsonPathTokenType tokenType, int tokenStartIndex, ReadOnlySpan<byte> valueSpan = default)
    {
        TokenType = tokenType;
        ValueSpan = valueSpan;
        TokenStartIndex = tokenStartIndex;
    }
}

internal ref struct JsonPathReader
{
    private readonly ReadOnlySpan<byte> _jsonPath;
    private int _consumed;

    public JsonPathToken Current { get; private set; }

    public JsonPathReader(ReadOnlySpan<byte> jsonPath)
    {
        _jsonPath = jsonPath;
        _consumed = 0;
    }

    public bool Read()
    {
        if (Current.TokenType == JsonPathTokenType.End)
            return false;

        if (_consumed >= _jsonPath.Length)
        {
            Current = new JsonPathToken(JsonPathTokenType.End, _jsonPath.Length - 1);
            return true;
        }

        byte current = _jsonPath[_consumed];

        switch (current)
        {
            case (byte)'$':
                Current = new JsonPathToken(JsonPathTokenType.Root, _consumed++, _jsonPath.Slice(_consumed - 1, 1));
                return true;

            case (byte)'.':
                Current = new JsonPathToken(JsonPathTokenType.PropertySeparator, _consumed++);
                return true;

            case (byte)'[':
                Current = new JsonPathToken(JsonPathTokenType.ArrayStart, _consumed++);
                return true;

            case (byte)']':
                Current = new JsonPathToken(JsonPathTokenType.ArrayEnd, _consumed++);
                return true;

            case (byte)'\'' or (byte)'"':
                Current = ReadQuotedString();
                return true;

            default:
                Current = IsDigit(current) ? ReadNumber() : ReadProperty();
                return true;
        }
    }

    public ReadOnlySpan<byte> GetFirstProperty()
    {
        if (!Read())
            return ReadOnlySpan<byte>.Empty;

        if (Current.TokenType != JsonPathTokenType.Root)
            return ReadOnlySpan<byte>.Empty;

        if (!Read())
            return ReadOnlySpan<byte>.Empty;

        if (Current.TokenType != JsonPathTokenType.PropertySeparator && Current.TokenType != JsonPathTokenType.ArrayStart)
            return ReadOnlySpan<byte>.Empty;

        if (!Read())
            return ReadOnlySpan<byte>.Empty;

        switch (Current.TokenType)
        {
            case JsonPathTokenType.Property:
                return _jsonPath.Slice(0, _consumed);

            case JsonPathTokenType.ArrayStart:
                if (!Read())
                    return ReadOnlySpan<byte>.Empty;

                if (Current.TokenType != JsonPathTokenType.QuotedString)
                    return ReadOnlySpan<byte>.Empty;

                return _jsonPath.Slice(0, _consumed);

            default:
                return ReadOnlySpan<byte>.Empty;
        }
    }

    private JsonPathToken ReadQuotedString()
    {
        byte quote = _jsonPath[_consumed];
        int start = ++_consumed; // Skip opening quote

        while (_consumed < _jsonPath.Length && _jsonPath[_consumed] != quote)
            _consumed++;

        if (_consumed >= _jsonPath.Length)
            throw new ArgumentException("Unterminated quoted string in JsonPath");

        var value = _jsonPath.Slice(start, _consumed - start);
        _consumed++; // Skip closing quote
        return new JsonPathToken(JsonPathTokenType.QuotedString, start, value);
    }

    private JsonPathToken ReadNumber()
    {
        int start = _consumed;
        while (_consumed < _jsonPath.Length && IsDigit(_jsonPath[_consumed]))
            _consumed++;

        return new JsonPathToken(JsonPathTokenType.Number, start, _jsonPath.Slice(start, _consumed - start));
    }

    private JsonPathToken ReadProperty()
    {
        int start = _consumed;
        while (_consumed < _jsonPath.Length &&
               _jsonPath[_consumed] != (byte)'.' &&
               _jsonPath[_consumed] != (byte)'[' &&
               _jsonPath[_consumed] != (byte)']')
        {
            _consumed++;
        }

        return new JsonPathToken(JsonPathTokenType.Property, start, _jsonPath.Slice(start, _consumed - start));
    }

    private static bool IsDigit(byte b) => b >= (byte)'0' && b <= (byte)'9';
}
