// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
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

/// <summary>
/// Reads a JsonPath expression and breaks it into tokens for processing.
/// Follows RFC 9535 minus the filter expressions and wildcards, which are not supported in this implementation.
/// </summary>
internal ref struct JsonPathReader
{
    private ref struct PeekedJsonPathToken
    {
        public JsonPathToken Token;
        public bool HasValue;
        public int Consumed;
    }

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
    private PeekedJsonPathToken _peeked;

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
        if (_peeked.HasValue)
        {
            Current = _peeked.Token;
            _consumed = _peeked.Consumed;
            _peeked.HasValue = false;
            return true;
        }

        if (Current.TokenType == JsonPathTokenType.End)
        {
            return false;
        }

        if (_consumed >= _length)
        {
            Current = new JsonPathToken(JsonPathTokenType.End, _length - 1);
            return true;
        }

        byte current = _jsonPath[_consumed];

        switch (current)
        {
            case DollarSign:
                var tokenSlice = _jsonPath.Slice(_consumed, 1);
                Current = new JsonPathToken(JsonPathTokenType.Root, _consumed++, tokenSlice);
                return true;

            case Dot:
                Current = new JsonPathToken(JsonPathTokenType.PropertySeparator, _consumed++);
                return true;

            case OpenBracket:
                // if the next byte is '\'', or '"', it's a quoted string, otherwise it's an array start
                if (_consumed + 1 >= _length)
                {
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed + 1}: expected a property or array index after '['");
                }

                var next = _jsonPath[_consumed + 1];
                if (next == SingleQuote || next == DoubleQuote)
                {
                    Current = new JsonPathToken(JsonPathTokenType.PropertySeparator, _consumed++);
                    return true;
                }

                if (!IsDigit(next))
                {
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed + 1}: expected a property or array index after '['");
                }

                _consumed++; // Skip '['
                Current = ReadNumber();
                if (_consumed >= _length || _jsonPath[_consumed] != CloseBracket)
                {
                    throw new FormatException($"Invalid JsonPath syntax at position {_consumed}: expected ']' after number");
                }

                _consumed++; // Skip closing bracket
                return true;

            case SingleQuote or DoubleQuote:
                if (Current.TokenType == JsonPathTokenType.PropertySeparator && _jsonPath[_consumed - 1] == Dot)
                {
                    Current = ReadProperty();
                }
                else
                {
                    Current = ReadQuotedString();
                    if (_consumed >= _length || _jsonPath[_consumed] != CloseBracket)
                    {
                        throw new FormatException($"Invalid JsonPath syntax at position {_consumed}: expected ']' after quoted string");
                    }

                    _consumed++; // Skip closing bracket
                }
                return true;

            default:
                // Read a property name
                Current = ReadProperty();
                return true;
        }
    }

    public JsonPathToken Peek()
    {
        if (Current.TokenType == JsonPathTokenType.End)
        {
            return Current;
        }

        if (_peeked.HasValue)
        {
            return _peeked.Token;
        }

        JsonPathReader local = this;
        local.Read();
        _peeked.HasValue = true;
        _peeked.Consumed = local._consumed;
        _peeked.Token = local.Current;

        return _peeked.Token;
    }

    public ReadOnlySpan<byte> GetFirstProperty()
    {
        if (_jsonPath.IsRoot())
        {
            return _jsonPath;
        }

        if (!Read())
        {
            return ReadOnlySpan<byte>.Empty;
        }

        if (Current.TokenType != JsonPathTokenType.Root)
        {
            return ReadOnlySpan<byte>.Empty;
        }

        if (!Read())
        {
            return ReadOnlySpan<byte>.Empty;
        }

        if (Current.TokenType == JsonPathTokenType.PropertySeparator && !Read())
        {
            return ReadOnlySpan<byte>.Empty;
        }

        switch (Current.TokenType)
        {
            case JsonPathTokenType.Property:
                return _jsonPath.Slice(0, _consumed);

            case JsonPathTokenType.ArrayIndex:
                return _jsonPath.Slice(0, _consumed);

            default:
                return ReadOnlySpan<byte>.Empty;
        }
    }

    public ReadOnlySpan<byte> GetNextArray()
    {
        while (Read())
        {
            if (Current.TokenType == JsonPathTokenType.ArrayIndex)
            {
                return _jsonPath.Slice(0, _consumed);
            }
        }

        return ReadOnlySpan<byte>.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private JsonPathToken ReadQuotedString()
    {
        var localJsonPath = _jsonPath;
        byte quote = localJsonPath[_consumed];
        Debug.Assert(quote == SingleQuote || quote == DoubleQuote, "ReadQuotedString should only be called if _consumed is pointing at a single or double quote character");
        int initial = ++_consumed; // Skip opening quote

        while (_consumed < _length)
        {
            if (localJsonPath[_consumed] == quote && _consumed + 1 < _length && localJsonPath[_consumed + 1] == ']')
            {
                break;
            }

            _consumed++;
        }

        if (_consumed >= _length)
        {
            throw new FormatException("Unterminated quoted string in JsonPath");
        }

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
        {
            _consumed++;
        }

        return new JsonPathToken(JsonPathTokenType.ArrayIndex, initial, localJsonPath.Slice(initial, _consumed - initial));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private JsonPathToken ReadProperty()
    {
        var localJsonPath = _jsonPath;
        int initial = _consumed;
        while (_consumed < _length && localJsonPath[_consumed] is not Dot and not OpenBracket and not CloseBracket)
        {
            _consumed++;
        }

        return new JsonPathToken(JsonPathTokenType.Property, initial, localJsonPath.Slice(initial, _consumed - initial));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsDigit(byte b) => b >= Zero && b <= Nine;

    public bool Advance(ReadOnlySpan<byte> prefix)
    {
        if (prefix.IsEmpty || _jsonPath.IsEmpty)
        {
            return false;
        }

        if (prefix.Length >= _length)
        {
            return false;
        }

        if (_jsonPath.StartsWith(prefix))
        {
            _consumed = prefix.Length;
            return true;
        }

        if (prefix[0] != DollarSign || _jsonPath[0] != DollarSign)
        {
            return false;
        }

        JsonPathReader prefixReader = new(prefix);

        while (Read() && prefixReader.Read())
        {
            if (!Current.ValueSpan.SequenceEqual(prefixReader.Current.ValueSpan))
            {
                return false;
            }
        }

        return prefixReader.Current.TokenType == JsonPathTokenType.End && Current.TokenType != JsonPathTokenType.End;
    }

    internal ReadOnlySpan<byte> GetParsedPath()
    {
        if (_consumed == 0)
        {
            return ReadOnlySpan<byte>.Empty;
        }

        return _jsonPath.Slice(0, _consumed);
    }

    public bool Equals(JsonPathReader other)
    {
        return JsonPathComparer.Default.NormalizedEquals(_jsonPath, other._jsonPath);
    }

    public override int GetHashCode()
    {
        return JsonPathComparer.Default.GetNormalizedHashCode(_jsonPath);
    }
}
