// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel.Rest.Internal;

namespace System.ServiceModel.Rest.Core.Pipeline;

internal class MessageRequestHeaders : MessageHeaders
{
    private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

    public override int Count => _headers.Count;

    public override bool Remove(string name)
        => _headers.TryRemove(new IgnoreCaseString(name));

    public override void Set(string name, string value)
        => _headers.Set(new IgnoreCaseString(name), value);

    public override void Add(string name, string value)
    {
        if (_headers.TryAdd(new IgnoreCaseString(name), value, out var existingValue))
        {
            return;
        }

        switch (existingValue)
        {
            case string stringValue:
                _headers.Set(new IgnoreCaseString(name), new List<string> { stringValue, value });
                break;
            case List<string> listValue:
                listValue.Add(value);
                break;
        }
    }

    public override bool TryGetHeader(string name, out string? value)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out var headerValue))
        {
            value = GetHeaderValueString(name, headerValue);
            return true;
        }

        value = null;
        return false;
    }

    public override bool TryGetHeaders(out IEnumerable<MessageHeader<string, object>> values)
    {
        values = EnumerateHeaders();
        return true;
    }

    private IEnumerable<MessageHeader<string, object>> EnumerateHeaders()
    {
        for (int i = 0; i < _headers.Count; i++)
        {
            _headers.GetAt(i, out IgnoreCaseString name, out object value);
            yield return new MessageHeader<string, object>(name, value);
        }
    }

    private static string GetHeaderValueString(string name, object value) => value switch
    {
        string s => s,
        List<string> l => string.Join(",", l),
        _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value?.GetType()}")
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
}