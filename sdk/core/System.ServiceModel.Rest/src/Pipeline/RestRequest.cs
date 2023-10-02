// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.ServiceModel.Rest.Experimental;
using System.Text;

namespace System.ServiceModel.Rest.Core.Pipeline;

// This adds the Http dependency, and some implementation

public class RestRequest : PipelineRequest
{
    private HttpMethod? _method;
    private Uri? _uri;

    private ArrayBackedPropertyBag<IgnoreCaseString, object> _headers;

    public RestRequest()
    {
        _headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
    }

    public override void SetContent(BinaryData content)
    {
        throw new NotImplementedException();
    }

    public override void SetHeaderValue(string name, string value)
    {
        throw new NotImplementedException();
    }

    public override void SetMethod(string method)
        => _method = new HttpMethod(method);

    public virtual void SetMethod(HttpMethod method)
        => _method = method;

    public override Uri SetUri(Uri uri)
        => _uri = uri;

    #region Header implementation

    protected virtual void SetHeader(string name, string value)
    {
        _headers.Set(new IgnoreCaseString(name), value);
    }

    protected virtual void AddHeader(string name, string value)
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

    protected virtual IEnumerable<string> GetHeaderNames()
    {
        for (int i = 0; i < _headers.Count; i++)
        {
            _headers.GetAt(i, out var name, out var _);
            yield return name;
        }
    }

    protected virtual bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out var headerValue))
        {
            value = GetHttpHeaderValue(name, headerValue);
            return true;
        }

        value = default;
        return false;
    }

    protected virtual bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(new IgnoreCaseString(name), out var value))
        {
            values = value switch
            {
                string headerValue => new[] { headerValue },
                List<string> headerValues => headerValues,
                _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value.GetType()}")
            };
            return true;
        }

        values = default;
        return false;
    }

    protected virtual bool ContainsHeader(string name) => _headers.TryGetValue(new IgnoreCaseString(name), out _);

    protected virtual bool RemoveHeader(string name) => _headers.TryRemove(new IgnoreCaseString(name));

    private static string GetHttpHeaderValue(string headerName, object value) => value switch
    {
        string headerValue => headerValue,
        List<string> headerValues => string.Join(",", headerValues),
        _ => throw new InvalidOperationException($"Unexpected type for header {headerName}: {value?.GetType()}")
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
