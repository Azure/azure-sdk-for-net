// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.Mocks;

public class MockRequestHeaders : PipelineRequestHeaders
{
    private readonly Dictionary<string, string> _headers;

    public MockRequestHeaders()
    {
        _headers = new Dictionary<string, string>();
    }

    public override void Add(string name, string value)
    {
        if (_headers.ContainsKey(name))
        {
            _headers[name] += string.Concat(",", value);
        }
        else
        {
            _headers[name] = value;
        }
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        IEnumerator<KeyValuePair<string, string>> enumerator = _headers.GetEnumerator();
        return enumerator;
    }

    public override bool Remove(string name)
    {
        return _headers.Remove(name);
    }

    public override void Set(string name, string value)
    {
        _headers[name] = value;
    }

    public override bool TryGetValue(string name, out string? value)
    {
        return _headers.TryGetValue(name, out value);
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        bool hasValue = _headers.TryGetValue(name, out string? dictionaryValue);

        if (!hasValue || string.IsNullOrEmpty(dictionaryValue))
        {
            values = null;
            return false;
        }

        values = dictionaryValue.Split(',');
        return true;
    }
}
