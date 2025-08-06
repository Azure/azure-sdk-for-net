// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text;

namespace System.ClientModel.Primitives;

internal enum JsonPathTokenType
{
    Root,               // $
    PropertySeparator,  // . or [' or ["
    Property,           // propertyName
    ArrayIndex,         // [(\d+)]
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
    private const byte DollarSign = 36;   // '$'
    private const byte Dot = 46;          // '.'
    private const byte OpenBracket = 91;  // '['
    private const byte CloseBracket = 93; // ']'
    private const byte SingleQuote = 39;  // '\''
    private const byte DoubleQuote = 34;  // '"'
    private const byte Zero = 48;         // '0'
    private const byte Nine = 57;         // '9'

    private readonly ReadOnlySpan<byte> _jsonPath;
    private int _consumed;
    private int _length;

    public JsonPathToken Current { get; private set; }

    public JsonPathReader(string jsonPath)
        : this(Encoding.UTF8.GetBytes(jsonPath).AsSpan()) { }

    public JsonPathReader(ReadOnlySpan<byte> jsonPath)
    {
        _jsonPath = jsonPath;
        _consumed = 0;
        _length = jsonPath.Length;
    }

    public bool Read()
    {
        if (Current.TokenType == JsonPathTokenType.End)
            return false;

        if (_consumed >= _length)
        {
            Current = new JsonPathToken(JsonPathTokenType.End, _length - 1);
            return true;
        }

        byte current = _jsonPath[_consumed];

        switch (current)
        {
            case DollarSign:
                Current = new JsonPathToken(JsonPathTokenType.Root, _consumed++, _jsonPath.Slice(_consumed - 1, 1));
                return true;

            case Dot:
                Current = new JsonPathToken(JsonPathTokenType.PropertySeparator, _consumed++);
                return true;

            case OpenBracket:
                // if the next byte is '\'', or '"', it's a quoted string, otherwise it's an array start
                if (_consumed + 1 >= _length)
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed + 1}: expected a property or array index after '['");

                var next = _jsonPath[_consumed + 1];
                if (next == SingleQuote || next == DoubleQuote)
                {
                    Current = new JsonPathToken(JsonPathTokenType.PropertySeparator, _consumed++);
                    return true;
                }

                if (!IsDigit(next))
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed + 1}: expected a property or array index after '['");

                _consumed++; // Skip '['
                Current = ReadNumber();
                if (_consumed >= _length || _jsonPath[_consumed] != CloseBracket)
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed}: expected ']' after number");

                _consumed++; // Skip closing bracket
                return true;

            case SingleQuote or DoubleQuote:
                Current = ReadQuotedString();
                if (_consumed >= _length || _jsonPath[_consumed] != CloseBracket)
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed}: expected ']' after quoted string");

                _consumed++; // Skip closing bracket
                return true;

            default:
                // Read a property name
                Current = ReadProperty();
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

        if (Current.TokenType != JsonPathTokenType.PropertySeparator)
            return ReadOnlySpan<byte>.Empty;

        if (!Read())
            return ReadOnlySpan<byte>.Empty;

        switch (Current.TokenType)
        {
            case JsonPathTokenType.Property:
                return _jsonPath.Slice(0, _consumed);

            //should get first property return $[0] if its an array rooted jsonpath?
            //case JsonPathTokenType.ArrayIndex:
            default:
                return ReadOnlySpan<byte>.Empty;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private JsonPathToken ReadQuotedString()
    {
        var localJsonPath = _jsonPath;
        byte quote = localJsonPath[_consumed];
        int initial = ++_consumed; // Skip opening quote

        while (_consumed < _length && localJsonPath[_consumed] != quote)
            _consumed++;

        if (_consumed >= _length)
            throw new FormatException("Unterminated quoted string in JsonPath");

        var value = localJsonPath.Slice(initial, _consumed - initial);
        _consumed++; // Skip closing quote
        return new JsonPathToken(JsonPathTokenType.Property, initial, value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private JsonPathToken ReadNumber()
    {
        var localJsonPath = _jsonPath;
        int initial = _consumed;
        while (_consumed < _length && IsDigit(localJsonPath[_consumed]))
            _consumed++;

        return new JsonPathToken(JsonPathTokenType.ArrayIndex, initial, localJsonPath.Slice(initial, _consumed - initial));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private JsonPathToken ReadProperty()
    {
        var localJsonPath = _jsonPath;
        int initial = _consumed;
        while (_consumed < _length && localJsonPath[_consumed] is not Dot and not OpenBracket and not CloseBracket)
            _consumed++;

        return new JsonPathToken(JsonPathTokenType.Property, initial, localJsonPath.Slice(initial, _consumed - initial));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDigit(byte b) => b >= Zero && b <= Nine;
}
