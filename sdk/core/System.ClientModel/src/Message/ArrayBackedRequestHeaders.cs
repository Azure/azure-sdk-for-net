// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

internal class ArrayBackedRequestHeaders : PipelineRequestHeaders
{
    private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

    public override bool Remove(string name)
        => _headers.TryRemove(new IgnoreCaseString(name));

    public override void Set(string name, string value)
        => _headers.Set(new IgnoreCaseString(name), value);

    public override void Add(string name, string value)
    {
        if (_headers.TryAdd(new IgnoreCaseString(name), value, out object? currentValue))
        {
            return;
        }

        switch (currentValue)
        {
            case string stringValue:
                _headers.Set(new IgnoreCaseString(name), new List<string> { stringValue, value });
                break;
            case List<string> listValue:
                listValue.Add(value);
                break;
        }
    }

    public override bool TryGetValue(string name, out string? value)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out object? headerValue))
        {
            value = GetHeaderValueString(name, headerValue);
            return true;
        }

        value = default;
        return false;
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out object? value))
        {
            values = GetHeaderValueEnumerable(name, value);
            return true;
        }

        values = default;
        return false;
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => GetHeadersStringValues().GetEnumerator();

    // Internal API provided to take advantage of performance-optimized implementation.
    internal bool GetNextValue(int index, out string name, out object value)
    {
        if (index >= _headers.Count)
        {
            name = default!;
            value = default!;
            return false;
        }

        _headers.GetAt(index, out IgnoreCaseString headerName, out object headerValue);
        name = headerName;
        value = headerValue;
        return true;
    }

    #region Implementation
    private IEnumerable<KeyValuePair<string, string>> GetHeadersStringValues()
    {
        for (int i = 0; i < _headers.Count; i++)
        {
            _headers.GetAt(i, out IgnoreCaseString name, out object value);
            string values = GetHeaderValueString(name, value);
            yield return new KeyValuePair<string, string>(name, values);
        }
    }

    private static string GetHeaderValueString(string name, object value)
        => value switch
        {
            string stringValue => stringValue,
            List<string> listValue => string.Join(",", listValue),
            _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value?.GetType()}")
        };

    private static IEnumerable<string> GetHeaderValueEnumerable(string name, object value)
        => value switch
        {
            string stringValue => new[] { stringValue },
            List<string> listValue => listValue,
            _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value.GetType()}")
        };

    private readonly struct IgnoreCaseString : IEquatable<IgnoreCaseString>
    {
        private readonly string _value;

        public IgnoreCaseString(string value)
        {
            _value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(IgnoreCaseString other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
        public override bool Equals(object? obj) => obj is IgnoreCaseString other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(IgnoreCaseString left, IgnoreCaseString right) => left.Equals(right);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(IgnoreCaseString left, IgnoreCaseString right) => !left.Equals(right);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(IgnoreCaseString ics) => ics._value;
    }
    #endregion
}
